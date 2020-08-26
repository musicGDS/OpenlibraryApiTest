using NUnit.Framework;
using OpenlibraryApiTest.Handlers;
using TechTalk.SpecFlow;

namespace OpenlibraryApiTest.Steps
{
    [Binding]
    public class SearchBookSteps
    {
        private ApiActions api = new ApiActions();
        string _code;
        string _actualTitle;

        [Given(@"book code ""(.*)""")]
        public void GivenBookCode(string code)
        {
            _code = code;
        }
        
        [When(@"get the title")]
        public void WhenGetTheTitle()
        {
            _actualTitle = BookActions.GetTitle(api.GetBook(_code));
        }
        
        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string expectedTitle)
        {
            Assert.That(_actualTitle, Contains.Substring(expectedTitle));
        }
    }
}
