using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Pages.Components.Login;
using AdvancedtaskSpecflow.Steps;
using System;
using TechTalk.SpecFlow;

namespace AdvancedtaskSpecflow.StepDefinitions
{
    [Binding]
    public class ChangePasswordStepDefinitions
    {
        LoginComponent LoginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ChangePasswordStep ChangePasswordStepObj;
        ChangePasswordAssertion ChangePasswordAssertionObj;
        public ChangePasswordStepDefinitions()
        {
            LoginPageObj = new LoginComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            ChangePasswordStepObj = new ChangePasswordStep();
            ChangePasswordAssertionObj = new ChangePasswordAssertion();
        }
        [Given(@"User logs into Mars portal and navigate to user tab successfully")]
        public void GivenUserLogsIntoMarsPortalAndNavigateToUserTabSuccessfully()
        {
            ChangePasswordStepObj.PassswordChangeLoginSteps();
            profileTabPageStepsObj.clickUserTab();
        }

        [When(@"User clicks Change Password and updates the new password with ""([^""]*)""")]
        public void WhenUserClicksChangePasswordAndUpdatesTheNewPasswordWith(string AddJsonFilePath)
        {
            ChangePasswordStepObj.AddNChangePassword(AddJsonFilePath);
        }

        [Then(@"New Password should be updated successfully")]
        public void ThenNewPasswordShouldBeUpdatedSuccessfully()
        {
            ChangePasswordAssertionObj.assertionChangePassword();
        }
    }
}
