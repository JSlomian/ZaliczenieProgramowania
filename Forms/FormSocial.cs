using PracZaliczeniowa.FormValidator;
using Form;

namespace PracZaliczeniowa.Forms
{
    public class FormSocial : IForm
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PESEL { get; set; } = string.Empty;
        public Validator Validator;
        public FormSocial()
        {
            Validator = new Validator();
            Validator.Error.FormName = "Formularz do mediów społecznościowych";

        }
        public void GetData()
        {
            Console.WriteLine("Podaj Imię: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Podaj Nazwisko: ");
            LastName = Console.ReadLine();
            Console.WriteLine("Podaj numer PESEL: ");
            PESEL = Console.ReadLine();
        }
        public void ValidateForm()
        {
            Validator.ValidateText("Imię", FirstName, 5);
            Validator.ValidateText("Nazwisko", LastName, 7);
            Validator.ValidatePesel("PESEL", PESEL);
            if (Validator.Error.Errors.Count < 1)
            {
                Validator.Error.setValid(true);
            }
            else
            {
                Validator.Error.listErrors(Validator.Error.FormName);
            }
        }
    }
}
