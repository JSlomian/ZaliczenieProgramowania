using Form;
using PracZaliczeniowa.Forms;

namespace PracZaliczeniowa
{
    internal class Program
    {
        static void Main()
        {
            string Prompt = "Wybierz Formularz";
            string[] Options = { "Formularz do szkoły", "Formularz do pracy", "Formularz do portalu społecznościowego" };
            var Option = new OptionsMenu(Prompt, Options).getOption();
            IForm[] Forms = { new FormSchool() };
            Forms[Option].GetData();
            Forms[Option].ValidateForm();
        }
    }
}