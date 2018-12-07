using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BRPChurch.Test
{
    public class AccountControllerTest
    {
       
        [Fact]
        public async Task Test1_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("login");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            }
                

        }
    }
}
