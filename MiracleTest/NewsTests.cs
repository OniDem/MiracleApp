using MiracleApi.Controllers;

namespace MiracleTest
{
    public class NewsTests
    {
        NewsController controller;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateNewsFullTest()
        {
            Task.Run(async () =>
            {
                var news = await controller.Create(new() { Name = "test", Content = "test", Image = {  } });
                Assert.IsTrue(news.Id > 0 && news != null);
            });
        }

        [Test]
        public void CreateNewsShortTest()
        {
            Task.Run(async () =>
            {
                var news = await controller.Create(new() { Name = "test", Content = "test" });
                Assert.IsTrue(news.Id > 0 && news != null);
            });
        }

        [Test]
        public void UpdateNewsTest()
        {
            Task.Run(async () =>
            {
                string updated_name = "tset";
                var news = await controller.Update(1, new() { Name = updated_name, Content = "test", Image = { } });
                Assert.IsTrue(news.Id == 1 && news.Name == updated_name);
            });
        }

        [Test]
        public void ShowAllNewsTest()
        {
            Task.Run(async () =>
            {
                var news = await controller.ShowAll();
                Assert.IsTrue(news.Count > 0);
            });
        }

        [Test]
        public void ShowByIdNewsTest()
        {
            Task.Run(async () =>
            {
                var news = await controller.ShowById(1);
                Assert.IsTrue(news != null && news.Id == 1);
            });
        }
    }
}
