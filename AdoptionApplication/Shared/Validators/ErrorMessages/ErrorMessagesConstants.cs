namespace AdoptionApplication.Shared.Validators.ErrorMessages
{
    public static class ErrorMessagesConstants
    {
        public static string ValidationFailed = "Nieprawidłowo wypełniony formularz! Spróbuj ponownie.";
        public static string AlreadySentForm = "Formularz do adopcji tego zwierzęcia został już wysłany.";
        public static string EmailFormInfo = "Podaj email w prawidłowym formacie <nazwa@domena.com>";
        public static string IkonFormInfo = "Dodaj nazwę Ikony z font-awesome";
        public static string AgeFormInfo = "Wiek musi być liczbą dodatnią";
        public static string EmptyField = "To pole nie może być puste.";
        public static string InternalError = "Coś poszło nie tak...";
        public static string AdoptionDateInfo = "Data adopcji musi być późniejsza niz data urodzenia.";
        public static string PhoneNumberFormInfo = "Dodaj numer telefonu w poprawnym formacie. Np. : +48 6475843756";
    }
}
