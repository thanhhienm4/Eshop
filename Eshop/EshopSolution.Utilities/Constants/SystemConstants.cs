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
            public const string CartSession = "CartSession";
        }
        public static class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLastestProducts = 6;
            public const int NumberOfRelatedProducts = 6;
        }
        public static class ServerSettings
        {
            public const string ServerBackEnd = "https://localhost:5002";
        }
        public static class Token
        {
            public const string Issuer = "Asp.netcore111111111111111111";
        }
    }
}