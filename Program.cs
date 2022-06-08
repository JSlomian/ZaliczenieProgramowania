using Form;
using PracZaliczeniowa.Forms;
using System.Text;

namespace PracZaliczeniowa
{
    internal class Program
    {
        static void Main()
        {
            Console.SetBufferSize(200, 200);
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                string Prompt = "Wybierz Formularz";
                string[] Options = { "Formularz do szkoły", "Formularz do pracy", "Formularz do portalu społecznościowego", "Zakończ" };
                var Option = new OptionsMenu(Prompt, Options).getOption();
                IForm[] Forms = { new FormSchool(), new FormWork(), new FormSocial() };
                if (Option == 3)
                {
                    Environment.Exit(0);
                }
                Forms[Option].GetData();
                Forms[Option].ValidateForm();
                Console.ReadKey();
            }
        }
    }
}