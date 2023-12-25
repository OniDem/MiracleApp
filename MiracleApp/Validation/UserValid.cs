namespace MiracleApp.Validation
{
    static public class UserValid
    {
        static public bool UserAuth()
        {
            var id = Task.Run(async () => await SecureStorage.Default.GetAsync("id")).Result;
            if (!string.IsNullOrEmpty(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
