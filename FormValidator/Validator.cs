using System.Text.RegularExpressions;
using PracZaliczeniowa.Enums;
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

        public static List<string> ValidateAge(string Age, int min, int max)
        {
            List<string> Error = new List<string>();
            string nameOf = nameof(Age);
            if (Age == null)
            {
                Error.Add($"{nameOf} jest puste.");
                return Error;
            }
            Validate(nameOf,
                !int.TryParse(Age, out int age),
                "Nie jest liczbą.", ref Error);
            Validate(nameOf,
                age > max,
                "Zbyt wysoki wiek.", ref Error);
            Validate(nameOf,
                age < min,
                "Zbyt niski wiek.", ref Error);
            return Error;
        }

        public static List<string> ValidateGender(string Gender)
        {
            List<string> Error = new List<string>();
            string nameOf = nameof(Gender);
            if (Gender == null)
            {
                Error.Add($"{nameOf} jest puste.");
                return Error;
            }
            Validate(nameOf,
                Gender.ToLower() != "mężczyzna" || Gender.ToLower() != "kobieta",
                "Nie podano prawidłowej płci.", ref Error);
            return Error;
        }

        public static List<string> ValidateEducation(string Education)
        {
            List<string> Error = new List<string>();
            string nameOf = nameof(Education);
            if (Education == null)
            {
                Error.Add($"{nameOf} jest puste.");
                return Error;
            }
            Validate(nameOf,
                Education.ToLower() != "podstawowe" ||
                Education.ToLower() != "zawodowe" ||
                Education.ToLower() != "średnie" ||
                Education.ToLower() != "wyższe",
                "Nie podano prawidłowego wykształcenia", ref Error);
            Validate(nameOf,
                Education.ToLower() != "średnie" ||
                Education.ToLower() != "wyższe",
                "Brak wymaganego wykształcenia.", ref Error);
            return Error;
        }

        public static List<string> ValidateEmail(string Email)
        {
            List<string> Error = new List<string>();
            string nameOf = nameof(Email);
            if (Email == null)
            {
                Error.Add($"{nameOf} jest puste.");
                return Error;
            }
            Validate(nameOf,
                !Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"),
                "Nieprawidłowy email.", ref Error);
            return Error;
        }
    }
}
