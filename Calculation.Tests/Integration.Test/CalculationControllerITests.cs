using Calculation.api;
using Calculation.Common.ResponseModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Calculation.Tests.Integration.Test
{
    public class CalculationControllerITests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public CalculationControllerITests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();

        }

        [Theory]
        [InlineData(null, 10, 10)]
        [InlineData("", 10, 10)]
        [InlineData("sd", 10, 10)]
        [InlineData("at", 0, 10)]
        [InlineData("at", -10, 10)]
        [InlineData("at", 40, 10)]
        [InlineData("at", 10, 0)]
        [InlineData("at", 13, 0)]
        [InlineData("at", 20, 0)]
        [InlineData("at", "sdfd", "kljlk")]
        [InlineData("at", "92233720368547758071", 10)]
        [InlineData("at", 20, -20)]
        public async Task GetAmmountCalculationFromNettoTest_MustFail(object country, object vatRate, object net)
        {
            var response = await _client.GetAsync($"/Calculation/{country}/{vatRate}/net/{net}");
            var responseStatus = response.StatusCode;
            Assert.True((int)responseStatus >= 400);

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.True(!string.IsNullOrEmpty(responseString));
        }

        [Theory]
        [InlineData(null, 10, 10)]
        [InlineData("", 10, 10)]
        [InlineData("sd", 10, 10)]
        [InlineData("at", 0, 10)]
        [InlineData("at", -10, 10)]
        [InlineData("at", 40, 10)]
        [InlineData("at", 10, 0)]
        [InlineData("at", 13, 0)]
        [InlineData("at", 20, 0)]
        [InlineData("at", "sdfd", "kljlk")]
        [InlineData("at", "92233720368547758071", 10)]
        [InlineData("at", 20, -20)]
        public async Task GetAmmountCalculationFromVatTest_MustFail(string country, object vatRate, object vat)
        {
            var response = await _client.GetAsync($"/Calculation/{country}/{vatRate}/vat/{vat}");
            var responseStatus = response.StatusCode;
            Assert.True((int)responseStatus >= 400);

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.True(!string.IsNullOrEmpty(responseString));
        }

        [Theory]
        [InlineData(null, 10, 10)]
        [InlineData("", 10, 10)]
        [InlineData("sd", 10, 10)]
        [InlineData("at", 0, 10)]
        [InlineData("at", -10, 10)]
        [InlineData("at", 40, 10)]
        [InlineData("at", 10, 0)]
        [InlineData("at", 13, 0)]
        [InlineData("at", 20, 0)]
        [InlineData("at", "sdfd", "kljlk")]
        [InlineData("at", "92233720368547758071", 10)]
        [InlineData("at", 20, -20)]
        public async Task GetAmmountCalculationFromGrossTest_MustFail(object country, object vatRate, object gross)
        {
            var response = await _client.GetAsync($"/Calculation/{country}/{vatRate}/gross/{gross}");
            var responseStatus = response.StatusCode;
            Assert.True((int)responseStatus >= 400);

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.True(!string.IsNullOrEmpty(responseString));
        }

        [Theory]
        [InlineData("at", 20, 10)]
        [InlineData("at", 10, 10)]
        [InlineData("at", 13, 10)]
        public async Task GetAmmountCalculationFromNettoTest_MustPass(string country, int vatRate, decimal net)
        {
            var response = await _client.GetAsync($"/Calculation/{country}/{vatRate}/net/{net}");
            var responseStatus = response.StatusCode;
            Assert.Equal(HttpStatusCode.OK, responseStatus);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<VatCalculationResponce>(responseString);
            Assert.True(responseModel != null);
            Assert.True(responseModel.Gross == responseModel.Net + responseModel.Vat);
            Assert.True(responseModel.Net == responseModel.Gross - responseModel.Vat);
            Assert.True(responseModel.Vat == responseModel.Gross - responseModel.Net);
            Assert.True(responseModel.Gross == responseModel.Net + Math.Round(responseModel.Net * responseModel.VatRate / 100, 2));
        }


        [Theory]
        [InlineData("at", 20, 10)]
        [InlineData("at", 10, 10)]
        [InlineData("at", 13, 10)]
        public async Task GetAmmountCalculationFromGrossTest_MustPass(string country, int vatRate, decimal gross)
        {
            var response = await _client.GetAsync($"/Calculation/{country}/{vatRate}/gross/{gross}");
            var responseStatus = response.StatusCode;
            Assert.Equal(HttpStatusCode.OK, responseStatus);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<VatCalculationResponce>(responseString);
            Assert.True(responseModel != null);
            Assert.True(responseModel.Gross == responseModel.Net + responseModel.Vat);
            Assert.True(responseModel.Net == responseModel.Gross - responseModel.Vat);
            Assert.True(responseModel.Vat == responseModel.Gross - responseModel.Net);
            Assert.True(responseModel.Gross == responseModel.Net + Math.Round(responseModel.Net * responseModel.VatRate / 100, 2));
        }


        [Theory]
        [InlineData("at", 20, 10)]
        [InlineData("at", 10, 10)]
        [InlineData("at", 13, 10)]
        public async Task GetAmmountCalculationFromVatTest_MustPass(string country, int vatRate, decimal vat)
        {
            var response = await _client.GetAsync($"/Calculation/{country}/{vatRate}/vat/{vat}");
            var responseStatus = response.StatusCode;
            Assert.Equal(HttpStatusCode.OK, responseStatus);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<VatCalculationResponce>(responseString);
            Assert.True(responseModel != null);
            Assert.True(responseModel.Gross == responseModel.Net + responseModel.Vat);
            Assert.True(responseModel.Net == responseModel.Gross - responseModel.Vat);
            Assert.True(responseModel.Vat == responseModel.Gross - responseModel.Net);
            Assert.True(responseModel.Gross == responseModel.Net + Math.Round(responseModel.Net * responseModel.VatRate / 100, 2));
        }
    }
}