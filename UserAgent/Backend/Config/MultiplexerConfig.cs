using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RaspberryBackend
{

    /// <summary>
    /// Super class for <see cref="XPinConfig"/> and <see cref="YPinConfig"/>.
    /// </summary>
    public class MultiplexerConfig
    {
        //TODO: This fields might be better initialized by <see cref="XPinConfig"/> and <see cref="YPinConfig"/>.
        protected Dictionary<string, int> _gpio_to_Y_map;
        protected Dictionary<int, string> _x_pin_to_value_map;

        //Dictionary which will be used to connect pins
        private Dictionary<int, int> x_to_y_map = new Dictionary<int, int>();

        /// <summary>
        /// Current Hi Family which the Multiplexer is configured on
        /// </summary>
        public static string HiFamily { get; private set; }

        /// <summary>
        /// Current Hi HiModel which the Multiplexer is configured on
        /// </summary>
        public static string HiModel { get; private set; }


        public MultiplexerConfig()
        {

        }

        public MultiplexerConfig(string hiFamily, string hiModel)
        {
            HiFamily = hiFamily;
            HiModel = hiModel;

            XPinConfig xPinConfig = HiXmlParser.getMultiplexerConfig(hiFamily, hiModel);
            YPinConfig yPinConfig = new YPinConfig();

            _x_pin_to_value_map = xPinConfig._x_pin_to_value_map;
            _gpio_to_Y_map = yPinConfig._gpio_to_Y_map;

            Debug.WriteLine("\n====================================\n " +
                            "===== Multiplexer Configuration ====\n ");
            foreach (int value_x in _x_pin_to_value_map.Keys)
            {
                foreach (string y_value in _gpio_to_Y_map.Keys)
                {
                    if (y_value.Equals(_x_pin_to_value_map[value_x]))
                    {
                        x_to_y_map.Add(value_x, _gpio_to_Y_map[y_value]);

                        Debug.WriteLine("Pin {0} is connected to : {1} \n", value_x, y_value);

                        RaspberryPi.Instance.Control.Multiplexer.current_multiplexer_state.Add(value_x, new Tuple<int, string>(_gpio_to_Y_map[y_value], y_value));
                    }
                }
            }

            Debug.WriteLine("====================================\n ");
        }

        public Dictionary<int, int> getX_to_Y_Mapping()
        {
            return x_to_y_map;
        }

        /// <summary>
        /// Getter field for the Multiplexer configuration dictionary
        /// </summary>
        /// <returns>
        /// Returns a Dictionary<int,string> containing multiplexer configurations for the specific HI, e.g.: 1 = "RockerSW", 2 = "Ground", 3 = "PB", ...
        /// </returns>
        public Dictionary<int, string> X_Pin_To_Value_Map { get => _x_pin_to_value_map; }
    }
}
