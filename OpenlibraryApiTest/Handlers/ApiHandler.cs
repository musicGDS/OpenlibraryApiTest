using OpenlibraryApiTest.Objects;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenlibraryApiTest.Handlers
{
    class ApiHandler
    {
        const string BaseUrl = "https://api.twilio.com/2008-08-01";

        readonly IRestClient _client;

        string _accountSid;

        public ApiHandler(string accountSid, string secretKey)
        {
            _client = new RestClient(BaseUrl);
            _client.Authenticator = new HttpBasicAuthenticator(accountSid, secretKey);
            _accountSid = accountSid;
        }

        //Connection Handler
        public T Execute<T>(RestRequest request) where T : new()
        {
            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request
            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new Exception(message, response.ErrorException);
                throw twilioException;
            }
            return response.Data;
        }

        //Get
        public Book GetBook(string callSid)
        {
            var request = new RestRequest("Accounts/{AccountSid}/Calls/{CallSid}");
            request.RootElement = "Call";

            request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

            return Execute<Book>(request);
        }

        //Post
        public Login Login()
        {
            var request = new RestRequest("Accounts/{AccountSid}/Calls", Method.POST);
            //request.RootElement = "Calls";
            request.AddJsonBody(new { username = "musicgds@gmail.com", password = "visma2020" });
            return Execute<Login>(request);
        }
    }
}
