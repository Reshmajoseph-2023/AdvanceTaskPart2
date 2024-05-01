using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Pages.Components.Login;
using AdvancedtaskSpecflow.Steps;
using System;
using TechTalk.SpecFlow;

namespace AdvancedtaskSpecflow.StepDefinitions
{
    [Binding]
    public class ManageRequestFeatureStepDefinitions
    {

        LoginComponent LoginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ManageRequestSteps ManageRequestStepsObj;
        AssertionManageRequest assertionManageRequestObj;
        public ManageRequestFeatureStepDefinitions()
        {
            LoginPageObj = new LoginComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            ManageRequestStepsObj = new ManageRequestSteps();
            assertionManageRequestObj = new AssertionManageRequest();
        }
        [Given(@"User logs into Mars portal and navigate to manage request tab successfully")]
        public void GivenUserLogsIntoMarsPortalAndNavigateToManageRequestTabSuccessfully()
        {
            LoginPageObj.LoginSteps();
            profileTabPageStepsObj.clickManageRequest();
        }

        [When(@"user click on received request in manage request tab")]
        public void WhenUserClickOnReceivedRequestInManageRequestTab()
        {
            ManageRequestStepsObj.VerifyReceivedRequest();
        }

        [Then(@"user should be able to view received requests")]
        public void ThenUserShouldBeAbleToViewReceivedRequests()
        {
            assertionManageRequestObj.AssertionReceivedRequest();
        }

        [When(@"user click on sent request in manage request tab")]
        public void WhenUserClickOnSentRequestInManageRequestTab()
        {
            ManageRequestStepsObj.VerifySentRequest();
        }

        [Then(@"user should be able to view sent requests")]
        public void ThenUserShouldBeAbleToViewSentRequests()
        {
            assertionManageRequestObj.AssertionSentRequest();
        }
        [When(@"user accepts the request")]
        public void WhenUserAcceptsTheRequest()
        {
            ManageRequestStepsObj.VerifyCompleteRequest();
        }

        [Then(@"the requets should be marked as complete")]
        public void ThenTheRequetsShouldBeMarkedAsComplete()
        {
            assertionManageRequestObj. AssertionCompleteRequest();
        }
    }
}
