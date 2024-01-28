using MiracleApi.Controllers;

namespace MiracleTest
{
    public class MailTests
    {
        MailController controller;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SendCodeOnMailTest()
        {
            Task.Run(async () =>
            {
                var mail_id = await controller.SendCodeOnMail(new() { Email = "test" });
                Assert.IsTrue(mail_id != 0);
            });
        }

        [Test]
        public void VerifyCodeTest()
        {
            Task.Run(async () =>
            {
                var result = await controller.VerifyCode(new() { Email = "test", Code = "test" });
                Assert.IsTrue(result);
            });
        }
    }
}
