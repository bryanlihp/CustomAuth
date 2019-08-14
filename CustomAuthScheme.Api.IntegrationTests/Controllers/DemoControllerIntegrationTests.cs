using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomAuthScheme.Api.IntegrationTests.Controllers
{
    public class DemoControllerIntegrationTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        public DemoControllerIntegrationTests(TestFixture<Startup> factory)
        {
            _client = factory.Client;
        }

        [Fact]
        public async Task Can_Get_Demo_Value_By_Hub_Id()
        {
            var httpResponse = await _client.GetAsync("/api/demo/5");
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
