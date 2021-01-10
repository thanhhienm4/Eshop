namespace EshopSolution.Utilities.Constants
{
    public static class SystemConstants
    {
        public const string MainConnectionString = "EshopSolutionDB";
        public const string NotAvailable = "N/A";
        public static class AppSettings
        {
            public const string DefaultLangaueId = "vi";
            public const string LanguageId = "DefaultLanguageId";
            public const string BaseAddress = "BaseAddress";
            public const string Token = "Token";
            public const string Bearer = "Bearer";
        }
        public static class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLastestProducts = 6;
        }
        public static class ServerSettings
        {
            public const string ServerBackEnd = "https://localhost:5002";
        }
    }
}