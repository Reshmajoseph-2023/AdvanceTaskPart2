using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Pages.Components.Login;
using AdvancedtaskSpecflow.Steps;
using System;
using TechTalk.SpecFlow;

namespace AdvancedtaskSpecflow.StepDefinitions
{
    [Binding]
    public class DescriptionFeatureStepDefinitions
    {
        DescriptionStep descriptionStepObj;
        AssertionDescription assertionDescriptionObj;
        LoginComponent loginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        public DescriptionFeatureStepDefinitions()
        {
            descriptionStepObj = new DescriptionStep();
            loginPageObj = new LoginComponent();
            assertionDescriptionObj = new AssertionDescription();
            profileTabPageStepsObj = new ProfileTabPageSteps();



        }
        [Given(@"User logs into Mars portal and navigate to description icon successfully")]
        public void GivenUserLogsIntoMarsPortalAndNavigateToDescriptionIconSuccessfully()
        {
            loginPageObj.LoginSteps();
            profileTabPageStepsObj.clickDescriptionIcon();
        }

        [When(@"Enter the description  ""([^""]*)""")]
        public void WhenEnterTheDescription(string AddJsonFilePath)
        {
            descriptionStepObj.AddDescription(AddJsonFilePath);
        }

        [Then(@"Description should be saved successfully")]
        public void ThenDescriptionShouldBeSavedSuccessfully()
        {
            assertionDescriptionObj.assertionDescription();
        }
    }
}
