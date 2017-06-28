using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryBackend.Config
{
    class MultiplexerConfig
    {
        private Dictionary<int, string> X_to_value_map;
        private Dictionary<string, int> value_to_Y_map;

        private Dictionary<int, int> x_to_y_map = new Dictionary<int, int>();

        public MultiplexerConfig(string family, string model)
        {
            HiType mux_config = HiXmlParser.getMultiplexerConfig(family, model);
            X_to_value_map = mux_config.X_Pin_To_Value_Map;
            value_to_Y_map = GPIOConfig._gpio_to_Y_map;

            foreach (int value_x in X_to_value_map.Keys)
            {
                foreach (string y_value in value_to_Y_map.Keys)
                {
                    if (y_value.Equals(X_to_value_map[value_x]))
                    {
                        x_to_y_map.Add(value_x, value_to_Y_map[y_value]);
                    }
                }
            }
        }

        public Dictionary<int,int> getX_to_Y_Mapping()
        {
            return x_to_y_map;
        }
    }
}
