using Newtonsoft.Json;
using NUnit.Framework;
using restful_booker.Models;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Serializers;
using System;
using System.Net;
using System.Text.Json;
using TechTalk.SpecFlow;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace restful_booker.Tests
{
    [Binding]
    public class UpdateBookingTests
    {
        private RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        private IRestResponse<BookingModel> response;
        private string token;
        private int bookingid;

        private void GetToken()
        {
            RestRequest request = new RestRequest("auth", Method.POST);
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            });
            request.AddJsonBody(new Dictionary<string, string> {
                { "username", "admin" },
                { "password", "password123" }
            });
            token = JsonSerializer.Deserialize<TokenModel>(client.Execute(request).Content).token;
            bookingid = JsonSerializer.Deserialize<List<BookingIdModel>>(client.Execute(new RestRequest("booking?firstname=Jim", Method.GET)).Content)[0].bookingid;
        }

        [When(@"I call an update request for the record")]
        public void WhenICallAnUpdateRequestForTheRecord()
        {
            GetToken();

            RestRequest request = new RestRequest($"booking/{bookingid}", Method.PUT);
            request.RequestFormat = DataFormat.Json;    
            request.AddJsonBody(new BookingModel()
            {
                bookingid = bookingid,
                firstname = "James",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new Bookingdates() { 
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            });
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Cookie", $"token={token}" }
            });
            response = client.Execute<BookingModel>(request);
        }

        [Then(@"I check whether the record is updated")]
        public void ThenICheckWhetherTheRecordIsUpdated()
        {
            Assert.That(response.Data.firstname, Is.EqualTo("James"));
        }
    }
}
