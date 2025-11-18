namespace Application.Service.Helpers.Validations
{
    public static class TripValidations
    {
        public static bool ReservationNumberValidation(int reservationNumber)
        {
            if (reservationNumber <= 0)
            {
                return false;
            }
            return true;
        }

        public static bool StartDateValidation(DateTime startDate)
        {
            if (startDate < DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }

        public static bool EndDateValidation(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                return false;
            }
            return true;
        }

        public static bool FinalKmValidation(int? initialKm, int? finalKm)
        { 
             if (finalKm < initialKm)
            {
                return false;
            }
            return true;
        }
    }
}
