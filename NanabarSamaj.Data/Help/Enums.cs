namespace NanabarSamaj.Data.Helpers
{
    public enum SocialLoginProviders
    {
        Google,
        Facebook
    }
    public enum ResponseCodes
    {
        NOT_VERIFIED = 10001,
        SUCCESS=200,
        INTERNALSERVERERROR = 500,
        FORBIDDEN = 403
    }
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Student = "Student";
    }
}
