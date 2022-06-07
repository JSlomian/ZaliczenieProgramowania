using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracZaliczeniowa.ErrorLogger
{
    internal class Logger
    {
        public string FormName { get; set; }
        private bool Valid { get; set; } = false;
        public List<string> Errors { get; set; }

        public Logger(string formName)
        {
            FormName = formName;
            Valid = false;
            Errors = new List<string>();
        }

        public bool getValid()
        {
            return this.Valid;
        }

        public void setValid(bool valid)
        {
            this.Valid = valid;
        }

        public void addError(string msg)
        {
            Errors.Add(msg);
        }

        public void listErrors()
        {
            foreach(string Error in Errors)
            {
                Console.WriteLine(Error);
            }
        }
    }
}
