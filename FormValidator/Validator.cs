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

        private void Validate(string name, string data, bool condition, string errorMsg)
        {
            if (data != null)
            {
                if (condition)
                {
                    Error.addError($"{name}: {errorMsg}");
                }
            }
        }

        public void ValidateText(string inputName, string inputData, int minChars = 5)
        {
            Validate(inputName, inputData, inputData == null, "Jest puste.");
            Validate(inputName, inputData, char.IsLetter(inputData, 0) && inputData.Substring(0, 1).ToUpper() != inputData.Substring(0, 1), "Nie zaczyna się z dużej litery.");
            Validate(inputName, inputData, inputData.Length < minChars, $"Krótsze niż {minChars} znaków.");
            Validate(inputName, inputData, !Regex.IsMatch(inputData, @"^[a-zA-Z]+$"), "Może zawierać tylko litery.");
        }

        public void ValidatePesel(string inputName, string inputData)
        {
            Validate(inputName, inputData, inputData == null, "Jest puste.");
            Validate(inputName, inputData, inputData.Length != 10, "Musi się składać z 10 znaków.");
            Validate(inputName, inputData, !Regex.IsMatch(inputData, @"^[0-9]{10}$"), "Musi zawierać same cyfry.");
        }

        public void ValidateAge(string inputName, string inputData, int minAge, int maxAge)
        {
            Validate(inputName, inputData, inputData == null, "Jest puste.");
            Validate(inputName, inputData, !int.TryParse(inputData, out int age), "Nie jest liczbą.");
            Validate(inputName, inputData, age > maxAge, "Zbyt wysoki wiek.");
            Validate(inputName, inputData, age < minAge, "Zbyt niski wiek.");
        }

        public void ValidateGender(string inputName, string inputData)
        {
            Validate(inputName, inputData, inputData == null, "Jest puste.");
            Validate(inputName, inputData, inputData.ToLower() != "mężczyzna" || inputData.ToLower() != "kobieta",
                "Nie podano prawidłowej płci.");
        }

        public void ValidateEducation(string inputName, string inputData)
        {
            Validate(inputName, inputData, inputData == null, "Jest puste.");
            Validate(inputName, inputData,
                inputData.ToLower() != "podstawowe" ||
                inputData.ToLower() != "zawodowe" ||
                inputData.ToLower() != "średnie" ||
                inputData.ToLower() != "wyższe",
                "Nie podano prawidłowego wykształcenia");
            Validate(inputName, inputData,
                inputData.ToLower() != "średnie" ||
                inputData.ToLower() != "wyższe",
                "Brak wymaganego wykształcenia.");
        }

        public void ValidateEmail(string inputName, string inputData)
        {
            Validate(inputName, inputData, inputData == null, "Jest puste.");
            Validate(inputName, inputData, !Regex.IsMatch(inputData, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"),
                "Nieprawidłowy email.");
        }
    }
}
