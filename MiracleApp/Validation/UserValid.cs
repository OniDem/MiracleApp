namespace MiracleApp.Validation
{
    static public class UserValid
    {
        static public bool UserAuth()
        {
            if (!string.IsNullOrEmpty(Task.Run(async () => await SecureStorage.Default.GetAsync("id")).Result))
                return true;
            return false;

        }
    }
}
