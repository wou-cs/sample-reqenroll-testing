namespace SimpleWeb.Tests;

[TestFixture]
public class HomeControllerTests
{
    [Test]
    public void Index_Returns_View()
    {
        var controller = new SimpleWeb.Controllers.HomeController();
        var result = controller.Index();
        Assert.IsNotNull(result);
    }
}