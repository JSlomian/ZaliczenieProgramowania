using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracZaliczeniowa.ErrorLogger
{
    public class Error
    {
        public string FormName { get; set; }
        private bool Valid { get; set; } = false;
        public List<string> Errors { get; set; }

        public Error()
        {
            FormName = "";
            Valid = false;
            Errors = new List<string>();
        }

        public bool getValid()
        {
            return Valid;
        }

        public void setValid(bool valid)
        {
            Valid = valid;
        }

        public void addError(string msg)
        {
            Errors.Add(msg);
        }

        public void listErrors(string formName)
        {
            foreach(string Error in Errors)
            {
                Console.WriteLine($"{formName}: Error[{Errors.IndexOf(Error)}] = \"{Error}\"");
            }
        }
    }
}
