using NUnit.Framework;
using OpenlibraryApiTest.Handlers;
using OpenlibraryApiTest.Objects;
using System;
using TechTalk.SpecFlow;

namespace OpenlibraryApiTest.Steps
{
    [Binding]
    public class LoginSteps
    {
        private ApiHandler _apiHandler = new ApiHandler();
        private string _userName;
        private string _password;
        private bool _gotcookie;

        [Given(@"the username ""(.*)""")]
        public void GivenTheUsername(string userName)
        {
            _userName = userName;
        }
        
        [Given(@"password ""(.*)""")]
        public void GivenPassword(string password)
        {
            _password = password;
        }
        
        [When(@"logged in")]
        public void WhenLoggedIn()
        {
            _gotcookie = _apiHandler.Login(_userName, _password);
        }
        
        [Then(@"verify sucessful login")]
        public void ThenVerifySucessfulLogin()
        {
            Assert.That(_gotcookie);
        }
    }
}
