using PracZaliczeniowa.FormValidator;
using Form;

namespace PracZaliczeniowa.Forms
{
    public class FormSchool : IForm
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PESEL { get; set; } = string.Empty;
        public Validator Validator;
        public FormSchool()
        {
            Validator = new Validator();
            Validator.Error.FormName = "Formularz do szkoły";

        }
        public void GetData()
        {
            Console.Clear();
            Console.WriteLine("Podaj imię: ");
            FirstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Podaj nazwisko: ");
            LastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Podaj numer PESEL: ");
            PESEL = Console.ReadLine();
            Console.Clear();
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
                Console.WriteLine($"{Validator.Error.FormName} wypełniono nieprawidłowo");
                Validator.Error.listErrors(Validator.Error.FormName);
            }
        }
    }
}
