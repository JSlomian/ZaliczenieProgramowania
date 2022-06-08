using PracZaliczeniowa.FormValidator;
using Form;

namespace PracZaliczeniowa.Forms
{
    public class FormWork : IForm
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public Validator Validator;
        public FormWork()
        {
            Validator = new Validator();
            Validator.Error.FormName = "Formularz do pracy";

        }
        public void GetData()
        {
            Console.Clear();
            Console.WriteLine("Podaj imię: ");
            FirstName = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            Console.WriteLine("Podaj nazwisko: ");
            LastName = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            Console.WriteLine("Podaj wiek: ");
            Age = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            string GenderPrompt = "Wybierz płeć:";
            string[] Genders = { "Mężczyzna", "Kobieta" };
            Gender = new OptionsMenu(GenderPrompt, Genders).getOptionString();
            string EduPrompt = "Wybierz wykształcenie:";
            string[] Edus = { "Podstawowe", "Zawodowe", "Średnie", "Wyższe" };
            Education = new OptionsMenu(EduPrompt, Edus).getOptionString();
            Console.Clear();
        }
        public void ValidateForm()
        {
            Validator.ValidateText("Imię", FirstName, 5);
            Validator.ValidateText("Nazwisko", LastName, 7);
            Validator.ValidateAge("Wiek", Age, 18, 65);
            Validator.ValidateGender("Płeć", Gender);
            Validator.ValidateEducation("Wykształcenie", Education);
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
