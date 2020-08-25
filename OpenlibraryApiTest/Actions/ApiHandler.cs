using OpenlibraryApiTest.Objects;
using RestSharp;
using System;


namespace OpenlibraryApiTest.Handlers
{
    class ApiHandler
    {
        string BaseUrl = ConfigurationReader.GetValue("url");

        readonly IRestClient _client;

        public ApiHandler()
        {
            _client = new RestClient(BaseUrl);
        }

        //Connection Handler
        public T Execute<T>(RestRequest request) where T : new()
        {
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
        public Book GetBook(string isbn)
        {
            var request = new RestRequest("api/books?bibkeys=ISBN:" + isbn + "&jscmd=data&format=json");
            request.AddParameter("isbn", isbn, ParameterType.UrlSegment);
            request.RootElement = "ISBN:" + isbn;
            var response = Execute<Book>(request);
            return response;
        }

        //Post
        public bool Login(string username, string password)
        {
            var request = new RestRequest("account/login", Method.POST);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            var response = _client.Execute(request);
            return (response.Cookies.Count != 0);
        }

        // Pasiaiaskinti koks skirtumas tarp tokio ir veikiancio varianto

        //request.RequestFormat = DataFormat.Json;
        //request.AddJsonBody(new { username = "Gediminas5629", password = "visma2020" });
    }
}

