namespace MiracleApp.Entity
{
    internal class UserEntity
    {
        public int Id { get; set; } 
        public string UserName { get; set; }    

        public List<string> Role {  get; set; }

        //Мб сменить название 
        public string Course { get; set; }

    }
}
