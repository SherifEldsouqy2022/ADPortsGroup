using System.Threading.Tasks;
using ADPortsGroup.Models.TokenAuth;
using ADPortsGroup.Web.Controllers;
using Shouldly;
using Xunit;

namespace ADPortsGroup.Web.Tests.Controllers
{
    public class HomeController_Tests: ADPortsGroupWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}