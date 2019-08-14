using GST.Fake.Authentication.JwtBearer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CustomAuthScheme.Api.IntegrationTests.Controllers
{
    public class TestFixture<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private IWebHost _testHost;
        public TestFixture()
        {
            Client = CreateClient();
            Client.SetFakeBearerToken("admin", new[] { "ROLE_ADMIN", "ROLE_GENTLEMAN" });
        }
        public HttpClient Client { get; set; }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder(null)
                .UseStartup<TStartup>()
                .UseEnvironment("Test");
        }
        protected override TestServer CreateServer(IWebHostBuilder builder)
        {
            var server = base.CreateServer(builder);
            _testHost = server.Host;
            return server;
        }

    }
}
