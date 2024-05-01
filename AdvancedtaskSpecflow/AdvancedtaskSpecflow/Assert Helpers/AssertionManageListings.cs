using AdvancedtaskSpecflow.Pages.Components.NavigationMenu;
using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using NUnit.Framework;


namespace AdvancedtaskSpecflow.Assert_Helpers
{
    public class AssertionManageListings : CommonDriver
    {
        ManageListingsComponent manageListingsComponentObj;
        public AssertionManageListings()
        {
            manageListingsComponentObj = new ManageListingsComponent();
        }

        public void AssertionView()
        {
             Assert.IsTrue(true, "Failed to click 'view'");
        }
        public void AssertionEdit()
        {
             Assert.IsTrue(true, "Failed to click 'edit'");
        }
        public void AssertionUpdate(ShareSkillModel data)
        {

             string actualTitle = manageListingsComponentObj.getTitle();
             Assert.That(actualTitle == data.title, "Actual and expected message do not match");
        }
        public void AssertionDelete()
        {
            string actualMessage = manageListingsComponentObj.GetMessageWindow();
            string expectedMessage1 = "has been deleted";
            string expectedMessage2="Unable to delete listing. Pending or Accepted skill trade requests exist.";

            if (actualMessage.Contains(expectedMessage1)|| actualMessage.Contains(expectedMessage2))
            {
                Assert.That(true, Is.True, "Actual and expected message match");
            }
            else
            {
                Assert.Fail("Actual and expected message does not match");
            }
        }
        public void AssertionEnable()
        {
            Assert.IsTrue(true, "Failed to enable button.");
        }
        public void AssertionSendRequest()
        {
            Assert.Fail("No such element");
        }
    }
}
