using PracZaliczeniowa.FormValidator;
using PracZaliczeniowa.ErrorLogger;

namespace PracZaliczeniowa
{
    public class FormSchool : IForm
    {
        private List<string> Error = new List<string>();
        private Logger logger = new Logger(nameof(FormSchool));
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL;
        public bool ValidateForm()
        {
            var FirstNameErrors = Validator.ValidateFirstName(this.FirstName);
            logger.Errors.AddRange(FirstNameErrors);
            if (logger.Errors.Count < 1)
            {
                logger.setValid(true);
            }
            else
            {
                foreach (var error in logger.Errors)
                {
                    Console.WriteLine($"{logger.FormName}: {error}");
                }
            }
            return true;
        }
    }
}
