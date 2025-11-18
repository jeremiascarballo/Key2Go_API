using System.Text.RegularExpressions;

namespace Application.Service.Helpers.Validations
{
    public static class CarValidations
    {
        public static bool LicensePlateValidation(string license)
        {
            //REGEX PATENTES AAA111 O AA111AA
            if (!Regex.IsMatch(license, @"^([A-Za-z]{3}\d{3}|[A-Za-z]{2}\d{3}[A-Za-z]{2})$"))
            {
                return false;
            }
            return true;
        }

        public static bool YearOfManufactureValidation(int yearOfManufacture)
        {
            var currentYear = DateTime.UtcNow.Year;
            if (yearOfManufacture < 1900 || currentYear < yearOfManufacture)
            {
                return false;
            }
            return true;
        }

        public static bool KmValidation(int km)
        {
            if (km < 0)
            {
                return false;
            }
            return true;
        }

        public static bool DailyPriceValidation(decimal price)
        {
            if (price <= 0)
            {
                return false;
            }
            return true;
        }

        public static bool StatusValidation(int status)
        {
            if (status < 1 || status > 2)
            {
                return false;
            }
            return true;
        }
    }
}
