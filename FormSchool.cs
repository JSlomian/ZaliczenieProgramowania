using PracZaliczeniowa.FormValidator;
using PracZaliczeniowa.ErrorLogger;

namespace PracZaliczeniowa
{
    public class FormSchool : IForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL;
        public Validator Validator;
        public FormSchool()
        {
            Validator = new Validator();
            Validator.Error.FormName = "Formularz szkolny";

        }
        public void GetData()
        {

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

            Validator.Error.listErrors(Validator.Error.FormName);
        }
    }
}
