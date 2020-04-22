namespace SPD.Api.Authentication.Installer
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Auth
        {
            public const string SignIn = Base + "/signin";
            public const string SignUp = Base + "/register";
            public const string SignOut = Base + "/signout";
        }
    }
}
