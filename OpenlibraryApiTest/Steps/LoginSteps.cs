using System;
using TechTalk.SpecFlow;

namespace OpenlibraryApiTest.Steps
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"the username ""musicgds@gmail\.com")]
        public void GivenTheUsernameMusicgdsGmail_Com()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"password ""(.*)""")]
        public void GivenPassword(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"logged in")]
        public void WhenLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"verify sucessful login")]
        public void ThenVerifySucessfulLogin()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
