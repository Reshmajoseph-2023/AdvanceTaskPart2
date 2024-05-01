using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Pages.Components.Login;
using AdvancedtaskSpecflow.Steps;
using System;
using TechTalk.SpecFlow;

namespace AdvancedtaskSpecflow.StepDefinitions
{
    [Binding]
    public class ManageListingsFeatureStepDefinitions
    {

        LoginComponent LoginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ManageListingSteps  manageListingStepsObj;
        AssertionManageListings assertionManageListingsObj;

        public ManageListingsFeatureStepDefinitions()
        {
            LoginPageObj = new LoginComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            manageListingStepsObj = new ManageListingSteps();
            assertionManageListingsObj = new AssertionManageListings();
        }

        [Given(@"User logs into Mars portal and navigate to managelistings tab successfully")]
        public void GivenUserLogsIntoMarsPortalAndNavigateToManagelistingsTabSuccessfully()
        {

            LoginPageObj.LoginSteps();
            profileTabPageStepsObj.clickManageListings();
        }

        [When(@"User click on view manage listings")]
        public void WhenUserClickOnViewManageListings()
        {
            manageListingStepsObj.verifyViewOption();
        }

        [Then(@"User should be able to view")]
        public void ThenUserShouldBeAbleToView()
        {
            assertionManageListingsObj.AssertionView();
        }

        [When(@"User click on edit listings")]
        public void WhenUserClickOnEditListings()
        {
            manageListingStepsObj.verifyEditOption();
        }

        [Then(@"User should be able to click")]
        public void ThenUserShouldBeAbleToClick()
        {
            assertionManageListingsObj.AssertionEdit();
        }
        [Then(@"User Updates a Skill from Manage Listings with data ""([^""]*)""")]
        public void ThenUserUpdatesASkillFromManageListingsWithData(string UpdateJsonFilePath)
        {

            profileTabPageStepsObj.clickUpdateShareSkillIcon();
            manageListingStepsObj.verifyUpdateOption(UpdateJsonFilePath);
        }
               
        
        [When(@"User deletes the specific record ""([^""]*)""")]
        public void WhenUserDeletesTheSpecificRecord(string DeleteJsonFilePath)
        {
            
            manageListingStepsObj.verifyDeleteOption(DeleteJsonFilePath);
        }

        [Then(@"that record should be deleted successfully")]
        public void ThenThatRecordShouldBeDeletedSuccessfully()
        {
            assertionManageListingsObj.AssertionDelete();
        }
        [When(@"User click to enable the listings")]
        public void WhenUserClickToEnableTheListings()
        {
            manageListingStepsObj.verifyToggleOption();
        }

        [Then(@"The sevice should be activated")]
        public void ThenTheSeviceShouldBeActivated()
        {
            assertionManageListingsObj.AssertionEnable();
        }

        [When(@"User attempt to send requests from the listings")]
        public void WhenUserAttemptToSendRequestsFromTheListings()
        {
            manageListingStepsObj.verifySendRequestOption();
        }

        [Then(@"User should be able to send the requests")]
        public void ThenUserShouldBeAbleToSendTheRequests()
        {
            assertionManageListingsObj.AssertionSendRequest();
        }
    }
}
