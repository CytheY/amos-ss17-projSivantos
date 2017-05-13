using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HelloWorld
{
    /// <summary>
    /// Unit of transfer by the RequestConnClient Class
    /// is only as a container for the two variables methodName and parameter
    /// note: this class uses the default contract namespace
    /// </summary>
    [DataContract]
    public class Request
    {
        public Request(Command command, Object parameter)
        {
            this.command = command;
            this.parameter = parameter;
        }

        [DataMember]
        public Command command;

        [DataMember]
        public Object parameter;
    }
}