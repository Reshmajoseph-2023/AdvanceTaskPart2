using AdvancedtaskSpecflow.Pages.Components.NavigationMenu;
using AdvancedtaskSpecflow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace AdvancedtaskSpecflow.Assert_Helpers
{
    public class AssertionManageRequest 
    {
        
        public static void assertAcceptSuccessMessage(String expected, String actual)
            
        {
           
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertDeclineSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertCompleteSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
        public static void assertWithdrawSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
    }
}
