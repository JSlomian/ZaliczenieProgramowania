using PracZaliczeniowa.ErrorLogger;
using PracZaliczeniowa.FormValidator;

namespace PracZaliczeniowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <IForm> form = new List<IForm>();
            IForm forma = new FormSchool();
            forma.FirstName = "aSSS";
            forma.LastName = "dsa";
            forma.ValidateForm();
        }
    }
}