using AdvancedtaskSpecflow.Pages.Components.AccountMenu;
using AdvancedtaskSpecflow.Utilities;
using NUnit.Framework;


namespace AdvancedtaskSpecflow.Assert_Helpers
{
    public class ChangePasswordAssertion : CommonDriver
    {

        ChangePasswordComponent ChangePasswordComponentObj;
        public ChangePasswordAssertion()
        {
            ChangePasswordComponentObj = new ChangePasswordComponent();
        }
        public void assertionChangePassword()
        {

            //verify the expected message text
            string expectedMessage = "Password Changed Successfully";
            string actualmessage = ChangePasswordComponentObj.getMessage();
            Assert.That(actualmessage == expectedMessage, "Actual and expected message doesn't match");
        }
    } 
}