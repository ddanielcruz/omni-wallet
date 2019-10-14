namespace OmniWallet.Shared.Constants
{
    public static class RegexConstants
    {
        public const string OnlyLetters = @"^[a-zA-Z]*$";
        public const string OnlyNumbers = @"^[0-9]*$";
        public const string OnlyNumbersAndLetters = @"^[a-zA-Z0-9]*$";
        public const string StrongPassword = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,})";
        public const string NonWhitespaces = @"^\S+$";
        public const string ValidCNPJ = @"^[0-9]{14}$";
    }
}