namespace API.DataModels
{
    public static class DbInitializer
    {
        public static void Initialize(MicroContext context)
        {
            context.Database.EnsureCreated();

        }      
    }
}