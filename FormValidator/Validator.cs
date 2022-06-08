using System.Text.RegularExpressions;
using PracZaliczeniowa.ErrorLogger;
namespace PracZaliczeniowa.FormValidator
{
    public class Validator
    {
        public Error Error;
        public Validator()
        {
            Error = new Error();
        }

        private void Validate(string name, bool condition, string errorMsg)
        {
            if (name != null)
            {
                if (condition)
                {
                    Error.addError($"{name}: {errorMsg}");
                }
            }
        }

        public void ValidateText(string inputData, string inputName, int minChars = 5)
        {
            Validate(inputName, inputData == null, "Jest puste.");
            Validate(inputName, inputData.Substring(0, 1).ToUpper() != inputData.Substring(0, 1), "Nie zaczyna się z dużej litery.");
            Validate(inputName, inputData.Length < minChars, "Krótsze niż 5 znaków.");
            Validate(inputName, !Regex.IsMatch(inputData, @"^[a-zA-Z]+$"), "Może zawierać tylko litery.");
        }

        public void ValidatePesel(string inputData, string inputName)
        {
            Validate(inputName, inputData == null, "Jest puste.");
            Validate(inputName, inputData.Length != 10, "Musi się składać z 10 znaków.");
            Validate(inputName, !Regex.IsMatch(inputData, @"^[0-9]{10}$"), "Musi zawierać same cyfry.");
        }

        public void ValidateAge(string inputData, string inputName, int minAge, int maxAge)
        {
            Validate(inputName, inputData == null, "Jest puste.");
            Validate(inputName, !int.TryParse(inputData, out int age), "Nie jest liczbą.");
            Validate(inputName, age > maxAge, "Zbyt wysoki wiek.");
            Validate(inputName, age < minAge, "Zbyt niski wiek.");
        }

        public void ValidateGender(string inputData, string inputName)
        {
            Validate(inputName, inputData == null, "Jest puste.");
            Validate(inputName, inputData.ToLower() != "mężczyzna" || inputData.ToLower() != "kobieta",
                "Nie podano prawidłowej płci.");
        }

        public void ValidateEducation(string inputData, string inputName)
        {
            Validate(inputName, inputData == null, "Jest puste.");
            Validate(inputName,
                inputData.ToLower() != "podstawowe" ||
                inputData.ToLower() != "zawodowe" ||
                inputData.ToLower() != "średnie" ||
                inputData.ToLower() != "wyższe",
                "Nie podano prawidłowego wykształcenia");
            Validate(inputName,
                inputData.ToLower() != "średnie" ||
                inputData.ToLower() != "wyższe",
                "Brak wymaganego wykształcenia.");
        }

        public void ValidateEmail(string inputData, string inputName)
        {
            Validate(inputName, inputData == null, "Jest puste.");
            Validate(inputName, !Regex.IsMatch(inputData, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"),
                "Nieprawidłowy email.");
        }
    }
}
