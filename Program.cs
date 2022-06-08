using PracZaliczeniowa.ErrorLogger;
using PracZaliczeniowa.FormValidator;

namespace PracZaliczeniowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var form = new FormSchool();
            form.FirstName = "aSSS";
            form.LastName = "dsa";
            form.ValidateForm();
        }
    }
}