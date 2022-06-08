using PracZaliczeniowa.FormValidator;
using Form;

namespace PracZaliczeniowa.Forms
{
    public class FormSocial : IForm
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public Validator Validator;
        public FormSocial()
        {
            Validator = new Validator();
            Validator.Error.FormName = "Formularz do portalu społecznościowego";

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
            Console.WriteLine("Podaj email: ");
            Email = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Podaj wiek: ");
            Age = Console.ReadLine();
            Console.Clear();
        }
        public void ValidateForm()
        {
            Validator.ValidateText("Imię", FirstName, 5);
            Validator.ValidateText("Nazwisko", LastName, 7);
            Validator.ValidateAge("Wiek", Age, 13, 100);
            Validator.ValidateEmail("Email", Email);
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
