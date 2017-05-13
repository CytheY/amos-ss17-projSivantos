using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{

    /**
     * <summary>executes the requested command</summary>
     * */
    class RequestController
    {
        protected static GPIOinterface gpio = new GPIOinterface(); //Singleton? GPIOinterface needs to be only one instance

        public static void handleRequest(Request r)
        {
            if (r != null)
            {
                try
                {
                    Command req = r.command;
                    req.execute(r.parameter);
                }
                catch (Exception)
                {
                    Debug.WriteLine("Something went wrong :( ");
                }
            }
        }
    }

    public interface Command
    {
        void execute(Object parameter);

        void undo();
    }

    class LightLED : RequestController, Command
    {
        public void execute(Object parameter)
        {
            string par = parameter.ToString();

            if (par.Equals("1"))
            {
                //Execute appropiate method in GPIOinterface like e.g. gpio.led(1);
                Debug.WriteLine("LED switched On");
            }

            else if (par.Equals("0"))
            {
                //Execute appropiate method in GPIOinterface like e.g. gpio.led(0);
                Debug.WriteLine("LED switched Off");
            }

            else
            {
                Debug.WriteLine("no valid parameter");
            }
        }

        public void undo()
        {
            throw new NotImplementedException();
        }
    }



    /*last try to parse string to type unsuccessfully
          string name = r.methodName;
          Object parameter = r.parameter;

          Type type = Type.GetType(name,true);

          Command req = (Command)Activator.CreateInstance(type);

          req.execute(parameter);
          */
}
