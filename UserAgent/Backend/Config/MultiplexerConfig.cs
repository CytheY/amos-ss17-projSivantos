using System.Collections.Generic;

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
            XPinConfig mux_config = HiXmlParser.getMultiplexerConfig(family, model);

            Dictionary<int, string> xToValueMap = mux_config.X_Pin_To_Value_Map;
            Dictionary<string, int> valueToYMap = _gpio_to_Y_map;

            foreach (int value_x in xToValueMap.Keys)
            {
                foreach (string y_value in valueToYMap.Keys)
                {
                    if (y_value.Equals(xToValueMap[value_x]))
                    {
                        x_to_y_map.Add(value_x, valueToYMap[y_value]);
                    }
                }
            }
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
