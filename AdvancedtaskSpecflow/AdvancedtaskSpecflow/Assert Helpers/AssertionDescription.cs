using AdvancedtaskSpecflow.Pages.Components.Profile;
using AdvancedtaskSpecflow.Utilities;
using NUnit.Framework;



namespace AdvancedtaskSpecflow.Assert_Helpers
{
    public class AssertionDescription : CommonDriver
    {

        ProfileDescriptionComponent DescriptionComponentObj;
        public AssertionDescription()
        {
            DescriptionComponentObj = new ProfileDescriptionComponent();
        }
        public void assertionDescription()
        {
            string ExpectedMessage = "Description has been saved successfully";
            string actualmessage = DescriptionComponentObj.getMessage();
            Assert.That(actualmessage == ExpectedMessage, "Actual and expected message doesn't match");
        }
    }
}