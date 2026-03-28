using AdvancedtaskSpecflow.Pages.Components.Certifications;
using AdvancedtaskSpecflow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;



namespace AdvancedtaskSpecflow.Assert_Helpers
{
    public class AssertionCertification : CommonDriver
    {
        AddDeleteCertificationComponent addDeleteCertificationComponentObj;
        
        public AssertionCertification()
        {
            addDeleteCertificationComponentObj = new AddDeleteCertificationComponent();
        }
       
        public void assertionAddCertification()
        {
            
             //verify the expected message text
             string expectedMessage1 = "has been added to your certification";
             string expectedMessage2 = "This information is already exist.";
             string expectedMessage3 = "Please enter Certification Name, Certification From and Certification Year";
             string expectedMessage4 = "Duplicated data";
             string actualmessage = addDeleteCertificationComponentObj.GetMessageWindow();

            if (actualmessage.Contains(expectedMessage1) || actualmessage.Contains(expectedMessage2) || actualmessage.Contains(expectedMessage3) || actualmessage.Contains(expectedMessage4))
            {
                Assert.That(true, Is.True, "Actual and expected message match");

            }
            else
            {
                Assert.That(false, Is.True, "Actual and expected message does not match");
            }
        }
        public void assertionDeleteCertification()
        {
            string actualmessage = addDeleteCertificationComponentObj.GetMessageWindow();
            string expectedMessage = "has been deleted from your certification";

            if (actualmessage.Contains(expectedMessage))
            {
                Assert.That(true, Is.True, "Actual and expected message match");
            }
            else
            {
                Assert.That(false, Is.True, "Actual and expected message does not match");
            }
        }

    }
}
