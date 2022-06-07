using System.Text.RegularExpressions;
namespace PracZaliczeniowa.FormValidator
{
    static class Validator
    {
        private static void Validate(string name, bool condition, string errorMsg, ref List<string> Error)
        {
            if (name != null)
            {
                if (condition)
                {
                    Error.Add($"{name}: {errorMsg}");
                }
            }
        }
        
        public static List<string> ValidateFirstName(string FirstName)
        {
            List<string> Error = new List<string>();
            string nameOf = nameof(FirstName);
            if (FirstName == null)
            {
                Error.Add($"{nameOf} jest puste.");
                return Error;
            }
            Validate(nameOf,
                FirstName.Substring(0, 1).ToUpper() != FirstName.Substring(0, 1),
                "Nie zaczyna się z dużej litery.", ref Error);
            Validate(nameOf,
                FirstName.Length < 5,
                "Krótsze niż 5 znaków.", ref Error);
            Validate(nameOf,
                !Regex.IsMatch(FirstName, @"^[a-zA-Z]+$"),
                "Może zawierać tylko litery.", ref Error);
            return Error;
        }

        public static List<string> ValidateLastName(string LastName)
        {
            List<string> Error = new List<string>();
            string nameOf = nameof(LastName);
            if (LastName == null)
            {
                Error.Add($"{nameOf} jest puste.");
                return Error;
            }
            Validate(nameOf,
                LastName.Substring(0, 1).ToUpper() != LastName.Substring(0, 1),
                "Nie zaczyna się z dużej litery.", ref Error);
            Validate(nameOf,
                LastName.Length < 7,
                "Krótsze niż 5 znaków.", ref Error);
            Validate(nameOf,
                !Regex.IsMatch(LastName, @"^[a-zA-Z]+$"),
                "Może zawierać tylko litery.", ref Error);
            return Error;
        }

        public static List<string> ValidatePesel(string PESEL)
        {
            List<string> Error = new List<string>();
            string nameOf = nameof(PESEL);
            if (PESEL == null)
            {
                Error.Add($"{nameOf} jest puste.");
                return Error;
            }
            Validate(nameOf,
                PESEL.Length != 10,
                "Musi się składać z 10 znaków.", ref Error);
            Validate(nameOf,
                !Regex.IsMatch(PESEL, @"^[0-9]{10}$"),
                "Musi zawierać same cyfry.", ref Error);
            return Error;
        }

        public static void ValidateAge(string input, int min, int max)
        {

        }

        public static void ValidateGender(string input)
        {

        }

        public static void ValidateEducation(string input)
        {

        }

        public static void ValidateEmail(string input)
        {

        }
    }
}
