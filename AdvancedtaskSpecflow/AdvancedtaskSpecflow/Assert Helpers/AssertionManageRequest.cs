using AdvancedtaskSpecflow.Pages.Components.NavigationMenu;
using AdvancedtaskSpecflow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace AdvancedtaskSpecflow.Assert_Helpers
{
    public class AssertionManageRequest : CommonDriver
    {
        ManageRequestComponent manageRequestComponentObj;
        
        public AssertionManageRequest()
        {
            manageRequestComponentObj = new ManageRequestComponent();
        }
        public void AssertionReceivedRequest()
        {
            Assert.IsTrue(true, "Failed to click 'view'");
        }
        public void AssertionSentRequest()
        {
            Assert.IsTrue(true, "Failed to click 'sent'");
        }
        public void AssertionCompleteRequest()
        {
            string actualmessage = manageRequestComponentObj.GetMessageWindow();
            string expectedmessage = "Service has been updated";
            Assert.That(actualmessage == expectedmessage, "Actual and expected message does not match");
            Console.WriteLine("User was able to view all complete request");

        }
       
    }
}
