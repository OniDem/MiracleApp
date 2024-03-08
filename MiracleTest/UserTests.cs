using MiracleApi.Controllers;

namespace MiracleTest
{
    public class UserTests
    {
        UserController userController;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateUserTest()
        {
            Task.Run(async () =>
            {
                var user = await userController.CreateWithoutToken(new() { Phone = "+7 (111) 111-11-11", Email = "test@test", FIO = "test", Role = 0, Department = "test", StudentBranch = "test", CourseNumber = "1", Password = "test", Photo = "photo" });
                Assert.IsTrue(user.Id > 0);
            });
        }

        [Test]
        public void AuthUserTest()
        {
            Task.Run(async () =>
            {
                var user = await userController.Auth(new() { Phone = "+7 (111) 111-11-11", Password = "test" });
                Assert.IsTrue(user.Id > 0 && user.Token.Length > 0);
            });
        }

        [Test]
        public void UpdateUserTest()
        {
            Task.Run(async () =>
            {
                string updated_phone = "+7 (222) 222-22-22";
                string updated_pass = "tset";
                var user = await userController.Update(12, new() { Phone = updated_phone, Email = "test", FIO = "test", Role = 0, Department = "test", StudentBranch = "test", CourseNumber = "1", Password = updated_pass, Photo = "test" });
                Assert.IsTrue(user.Id == 12 && user.Phone == updated_phone && user.Password == updated_pass);
            });
        }

        [Test]
        public void ShowByIdTest()
        {
            Task.Run(async () =>
            {
                var user = await userController.ShowById(new() { id = 1 });
                Assert.IsTrue(user != null && user.Id == 1);
            });
        }

        [Test]
        public void ShowByPhone()
        {
            Task.Run(async () =>
            {
                var user = await userController.ShowByPhone(new() { Phone = "+7 (111) 111-11-11" });
                Assert.IsTrue(user != null && user.Phone == "+7 (111) 111-11-11");
            });
        }
    }
}