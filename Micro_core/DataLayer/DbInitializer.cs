namespace Micro_core.DataLayer
{
    public class DbInitializer
    {
        public static void Initialize(MicroContext context)
        {
            context.Database.EnsureCreated();

        }      
    }
}