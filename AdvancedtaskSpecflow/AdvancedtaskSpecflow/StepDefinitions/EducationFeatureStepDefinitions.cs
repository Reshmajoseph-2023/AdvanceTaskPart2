using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Pages.Components.Login;
using AdvancedtaskSpecflow.Pages.Components.Profile;
using AdvancedtaskSpecflow.Steps;
using System;
using TechTalk.SpecFlow;

namespace AdvancedtaskSpecflow.StepDefinitions
{
    [Binding]
    public class EducationFeatureStepDefinitions

    {
        LoginComponent LoginPageObj;
        EducationStep educationStepsObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        AssertionEducation assertionEducationObj;
        AddDeleteEducationComponent addDeleteEducationComponentObj;
        public EducationFeatureStepDefinitions()
        {
        
            LoginPageObj = new LoginComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            assertionEducationObj = new AssertionEducation();
            educationStepsObj = new EducationStep();
            addDeleteEducationComponentObj = new AddDeleteEducationComponent();


        }
        [Given(@"User logs into Mars portal and navigate to education tab successfully")]
        public void GivenUserLogsIntoMarsPortalAndNavigateToEducationTabSuccessfully()
        {

            LoginPageObj.LoginSteps();
            profileTabPageStepsObj.clickEducationTab();
        }

        [When(@"User deletes existing records")]
        public void WhenUserDeletesExistingRecords()
        {
            educationStepsObj.DeleteExistingRecords();
        }

        [Then(@"education records deleted successfully")]
        public void ThenEducationRecordsDeletedSuccessfully()
        {
            assertionEducationObj.assertionDeleteAllEducation();
        }

        [When(@"User adds a new record with education data ""([^""]*)""")]
        public void WhenUserAddsANewRecordWithEducationData(string AddJsonFilePath)
        {
            educationStepsObj.AddEducation(AddJsonFilePath);
        }

        [Then(@"Mars portal should save the new education record")]
        public void ThenMarsPortalShouldSaveTheNewEducationRecord()
        {
            assertionEducationObj.assertionAddEducation();

        }

        [When(@"User deletes the speccific education record ""([^""]*)""")]
        public void WhenUserDeletesTheSpeccificEducationRecord(string AddJsonFilePath)
        {
            educationStepsObj.deleteEducation(AddJsonFilePath);
        }

        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            assertionEducationObj.assertionDeleteEducation();
        }
    }
}
