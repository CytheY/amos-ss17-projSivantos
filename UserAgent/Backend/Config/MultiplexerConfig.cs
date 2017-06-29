using System.Collections.Generic;
using System.Diagnostics;

namespace RaspberryBackend
{

    /// <summary>
    /// Super class for <see cref="XPinConfig"/> and <see cref="YPinConfig"/>.
    /// </summary>
    public class MultiplexerConfig
    {
        protected Dictionary<string, int> _gpio_to_Y_map;
        protected Dictionary<int, string> _x_pin_to_value_map;


        private Dictionary<int, int> x_to_y_map = new Dictionary<int, int>();

        public MultiplexerConfig()
        {

        }

        public MultiplexerConfig(string family, string model)
        {
            XPinConfig xPinConfig = HiXmlParser.getMultiplexerConfig(family, model);
            YPinConfig yPinConfig = new YPinConfig();

            _x_pin_to_value_map = xPinConfig.X_Pin_To_Value_Map;
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
