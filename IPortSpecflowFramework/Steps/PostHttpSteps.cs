using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using IPortSpecflowFramework.PageObjects;
using Newtonsoft.Json;

namespace IPortSpecflowFramework.Steps
{
    [Binding]
    public class PostHttpSteps
    {
        HttpClient httpclient;
        HttpResponseMessage response;
        string responsebody;

        [Given(@"the user sends the post request with url as ""([^""]*)""")]
        public async Task GivenTheUserSendsThePostRequestWithUrlAs(string uri)
        {
            PostData postData = new PostData()
            {
                categoryId = "100",
                name = "FirstCategory",
                locked = "true"
            };
            
            string data = JsonConvert.SerializeObject(postData);
            var contentdata = new StringContent(data);
            response = await httpclient.PostAsync(uri, contentdata);
            responsebody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("post response is - " + responsebody);
        }

        [Then(@"user gets a success response")]
        public void ThenUserGetsASuccessResponse()
        {
            throw new PendingStepException();
        }

    }
}
