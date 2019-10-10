namespace OmniWallet.Shared.Constants
{
    public static class RegexConstants
    {
        public const string StrongPassword = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,256})";
        public const string NonWhitespaces = @"^\S+$";
    }
}