using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CodingChallenge.Tests.Integration
{
    public class Tests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public Tests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Post_Does_Not_500()
        {
            // Initially I got a 500 back from the server.  Wrote this test to reproduce the 500 and let me know when it's fixed.

            var client = _factory.CreateClient();

            string newEntity = "{ \"firstName\": \"Matt\", \"lastName\": \"Lund\", \"email\": \"matt@lundfam.net\", \"phone\": \"555-555-5555\" }";
            StringContent stringContent = new StringContent(newEntity, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/contacts", stringContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
