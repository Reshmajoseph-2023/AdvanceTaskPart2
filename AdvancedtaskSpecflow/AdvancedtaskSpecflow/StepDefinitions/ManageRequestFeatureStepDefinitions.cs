using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Pages.Components.Login;
using AdvancedtaskSpecflow.Pages.Components.NavigationMenu;
using AdvancedtaskSpecflow.Steps;
using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using Newtonsoft.Json;
using System;
using TechTalk.SpecFlow;

namespace AdvancedtaskSpecflow.StepDefinitions
{
    [Binding]
    public class ManageRequestFeatureStepDefinitions
    {

        LoginComponent LoginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ManageRequestComponent ManageRequestComponentObj;
        AssertionManageRequest assertionManageRequestObj;
        ManageRequestOverviewComponent ManageRequestOverviewComponentObj;

        public ManageRequestFeatureStepDefinitions()
        {
            LoginPageObj = new LoginComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            assertionManageRequestObj = new AssertionManageRequest();
            ManageRequestComponentObj = new ManageRequestComponent();
            ManageRequestOverviewComponentObj = new ManageRequestOverviewComponent();
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
            ManageRequestOverviewComponentObj.clickReceivedRequests();
        }


        [When(@"User accepts the received requests with '([^']*)' in the Manage Requests")]
        public void WhenUserAcceptsTheReceivedRequestsWithInTheManageRequests(int id)
        {
            ReceivedRequestsDataModel receivedRequestsData = JsonHelper.ReadTestDataFromJson<ReceivedRequestsDataModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\ReceivedRequestsData.json").FirstOrDefault(x => x.Id == id);
            ManageRequestComponentObj.ClickOnAccept(receivedRequestsData);
            
        }

        [Then(@"The accept requests with '([^']*)' are accepted successfully")]
        public void ThenTheAcceptRequestsWithAreAcceptedSuccessfully(int id)
        {
            ReceivedRequestsDataModel receivedRequestsData = JsonHelper.ReadTestDataFromJson<ReceivedRequestsDataModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\ReceivedRequestsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = ManageRequestComponentObj.GetMessageWindow();
            AssertionManageRequest.assertAcceptSuccessMessage(receivedRequestsData.ExpectedMessage, actualMessage);
        }
        [When(@"User declines the received requests with '([^']*)' in the Manage Requests")]
        public void WhenUserDeclinesTheReceivedRequestsWithInTheManageRequests(int id)
        {
            ReceivedRequestsDataModel receivedRequestsData = JsonHelper.ReadTestDataFromJson<ReceivedRequestsDataModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\ReceivedRequestsData.json").FirstOrDefault(x => x.Id == id);
            ManageRequestComponentObj.clickDeclineButton(receivedRequestsData);
        }

        [Then(@"The decline requests with '([^']*)' are declined successfully")]
        public void ThenTheDeclineRequestsWithAreDeclinedSuccessfully(int id)
        {
            ReceivedRequestsDataModel receivedRequestsData = JsonHelper.ReadTestDataFromJson<ReceivedRequestsDataModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\ReceivedRequestsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = ManageRequestComponentObj.GetMessageWindow();
            AssertionManageRequest.assertDeclineSuccessMessage(receivedRequestsData.ExpectedMessage, actualMessage);
        }
        [When(@"user accepts and completes the received requests with '([^']*)' in the Manage Requests")]
        public void WhenUserAcceptsAndCompletesTheReceivedRequestsWithInTheManageRequests(int id)
        {
            ReceivedRequestsDataModel receivedRequestsData = JsonHelper.ReadTestDataFromJson<ReceivedRequestsDataModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\ReceivedRequestsData.json").FirstOrDefault(x => x.Id == id);
            ManageRequestComponentObj.ClickOnAccept(receivedRequestsData);
            ManageRequestComponentObj.clickCompleteButton(receivedRequestsData);
        }

        [Then(@"The received requests with '([^']*)' are completed successfully")]
        public void ThenTheReceivedRequestsWithAreCompletedSuccessfully(int id)
        {
            ReceivedRequestsDataModel receivedRequestsData = JsonHelper.ReadTestDataFromJson<ReceivedRequestsDataModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\ReceivedRequestsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = ManageRequestComponentObj.GetMessageWindow();
            AssertionManageRequest.assertCompleteSuccessMessage(receivedRequestsData.ExpectedMessage, actualMessage);
        }

        [When(@"User clicks sent requests")]
        public void WhenUserClicksSentRequests()
        {
            ManageRequestOverviewComponentObj.clickSentRequests();
        }

        [When(@"User withdraw the sent requests with '([^']*)' in the Manage Requests")]
        public void WhenUserWithdrawTheSentRequestsWithInTheManageRequests(int id)
        {
            SentRequestsDataModel sentRequestsData = JsonHelper.ReadTestDataFromJson<SentRequestsDataModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\SentRequestData.json").FirstOrDefault(x => x.Id == id);
            ManageRequestComponentObj.clickWithdrawButton(sentRequestsData);
        }

        [Then(@"The withdraw requests with '([^']*)' are withdrawn successfully")]
        public void ThenTheWithdrawRequestsWithAreWithdrawnSuccessfully(int id)
        {
            SentRequestsDataModel sentRequestsData = JsonHelper.ReadTestDataFromJson<SentRequestsDataModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\SentRequestData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = ManageRequestComponentObj.GetMessageWindow();
            AssertionManageRequest.assertWithdrawSuccessMessage(sentRequestsData.ExpectedMessage, actualMessage);
        }
    }
}


