using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Steps;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using TechTalk.SpecFlow;
using AdvancedtaskSpecflow.Pages.Components.Certifications;
using AdvancedtaskSpecflow.Pages.Components.Login;
using AdvancedtaskSpecflow.Pages.Components.Profile;

namespace AdvancedtaskSpecflow.StepDefinitions
{
    [Binding]
    public class CertificationsFeatureStepDefinitions
    {

        LoginComponent LoginPageObj;
        CertificationStep certificationStepsObj;
        CertificationComponent certificationComponentObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        AssertionCertification assertionCertificationObj;
        AddDeleteEducationComponent addDeleteEducationComponentObj;
        public CertificationsFeatureStepDefinitions()
        {

            LoginPageObj = new LoginComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            assertionCertificationObj = new AssertionCertification();
            certificationStepsObj = new CertificationStep();
            addDeleteEducationComponentObj = new AddDeleteEducationComponent();
            certificationComponentObj = new CertificationComponent();

        }
        [Given(@"User logs into Mars portal and navigate to certification tab successfully")]
        public void GivenUserLogsIntoMarsPortalAndNavigateToCertificationTabSuccessfully()
        {
            LoginPageObj.LoginSteps();

            profileTabPageStepsObj.clickCertificationTab();
        }



        [When(@"User deletes the existing records")]
        public void WhenUserDeletesTheExistingRecords()
        {
            certificationStepsObj.DeleteExistingRecords();
        }

        [When(@"User adds a new record with certification data ""([^""]*)""")]
        public void WhenUserAddsANewRecordWithCertificationData(string AddJsonFilePath)
        {

            certificationStepsObj.AddCertification(AddJsonFilePath);

        }

        [Then(@"Mars portal should save the new certification record")]
        public void ThenMarsPortalShouldSaveTheNewCertificationRecord()
        {

            assertionCertificationObj.assertionAddCertification();
        }

        [When(@"User adds a new record with invalid certification data ""([^""]*)""")]
        public void WhenUserAddsANewRecordWithInvalidCertificationData(string AddJsonFilePath)
        {

            certificationStepsObj.AddCertification(AddJsonFilePath);
        }


        [When(@"user adds an certification to delete ""([^""]*)""")]
        public void WhenUserAddsAnCertificationToDelete(string AddJsonFilePath)
        {
            certificationStepsObj.AddCertification(AddJsonFilePath);
        }

        [When(@"user delete the added certification record")]
        public void WhenUserDeleteTheAddedCertificationRecord()
        {
            certificationStepsObj.DeleteCertification();
        }
        [Then(@"the certification record should be deleted successfully")]
        public void ThenTheCertificationRecordShouldBeDeletedSuccessfully()
        {
            assertionCertificationObj.assertionDeleteCertification();
        }
    }
}