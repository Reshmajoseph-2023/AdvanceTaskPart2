using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Pages.Components.Login;
using AdvancedtaskSpecflow.Pages.Components.NavigationMenu;
using AdvancedtaskSpecflow.Steps;
using System;
using TechTalk.SpecFlow;

namespace AdvancedtaskSpecflow.StepDefinitions
{
    [Binding]
    public class ManageListingStepDefinitions
    {

        LoginComponent LoginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ManageListingSteps manageListingStepsObj;
        AssertionManageListings assertionManageListingsObj;
        

        public ManageListingStepDefinitions()
        {
            LoginPageObj = new LoginComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            manageListingStepsObj = new ManageListingSteps();
            assertionManageListingsObj = new AssertionManageListings();
           
        }
        [Given(@"User logs into Mars portal and navigate to manage listings tab successfully")]
        public void GivenUserLogsIntoMarsPortalAndNavigateToManageListingsTabSuccessfully()
        {
            LoginPageObj.LoginSteps();
            profileTabPageStepsObj.clickManageListings();
        }

        [Given(@"User Add a Share Skill""([^""]*)""")]
        public void GivenUserAddAShareSkill(string AddJsonFilePath)
        {
            profileTabPageStepsObj.clickAddShareSkillIcon();
            manageListingStepsObj.AddShareSkill(AddJsonFilePath);
        }

        [When(@"User click to view listing")]
        public void WhenUserClickToViewListing()
        {
            manageListingStepsObj.verifyViewOption();
        }

        [Then(@"user should be able to view")]
        public void ThenUserShouldBeAbleToView()
        {

            assertionManageListingsObj.AssertionView();
        }

        [When(@"User click on edit and update the ""([^""]*)"" listing")]
        public void WhenUserClickOnEditAndUpdateTheListing(string UpdateJsonFilePath)
        {
            profileTabPageStepsObj.clickUpdateShareSkillIcon();
            manageListingStepsObj.verifyUpdateOption(UpdateJsonFilePath);
        }
        [Then(@"record should be updated successfully")]
        public void ThenRecordShouldBeUpdatedSuccessfully()
        {
           assertionManageListingsObj.AssertionUpdate();
        }
               
        [When(@"User deletes the listing")]
        public void WhenUserDeletesTheListing()
        {
            manageListingStepsObj.verifyDeleteOption();
        }
        [Then(@"that record should be deleted successfully")]
        public void ThenThatRecordShouldBeDeletedSuccessfully()
        {
            assertionManageListingsObj.AssertionDelete();
        }

        [When(@"User click to enable/disable")]
        public void WhenUserClickToEnableDisable()
        {
            manageListingStepsObj.verifyToggleOption();
        }

        [Then(@"Sevice should be activated")]
        public void ThenSeviceShouldBeActivated()
        {
            assertionManageListingsObj.AssertionEnable();
        }
    }
}
