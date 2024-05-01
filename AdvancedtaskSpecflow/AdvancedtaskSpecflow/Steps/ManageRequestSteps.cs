using AdvancedtaskSpecflow.Pages.Components.NavigationMenu;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;



namespace AdvancedtaskSpecflow.Steps
{
    public class ManageRequestSteps : CommonDriver
    {
        ManageRequestComponent manageRequestComponentObj;
       
        public  ManageRequestSteps()
        { 
        manageRequestComponentObj=new ManageRequestComponent();
        }
        public void VerifyReceivedRequest()
        {
            bool clickview = manageRequestComponentObj.VerifyReceivedRequest();
            Console.WriteLine("User was able to view received request listing");
        }
        public void VerifySentRequest()
        {
            bool clickview = manageRequestComponentObj.VerifySentRequest();
            Console.WriteLine("User was able to view sent request");
        }
        public void VerifyCompleteRequest()
        {
            manageRequestComponentObj.ClickOnAccept();
            Console.WriteLine("User was able to view all complete request");
        }
    }
}