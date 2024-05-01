using AdvancedtaskSpecflow.Pages.Components.Profile;
using AdvancedtaskSpecflow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace AdvancedtaskSpecflow.Assert_Helpers
{
    public class AssertionEducation : CommonDriver

    {
        AddDeleteEducationComponent addDeleteEducationComponentObj;
        public AssertionEducation()
        {
            addDeleteEducationComponentObj = new AddDeleteEducationComponent();
        }
        public void assertionDeleteAllEducation()
        {
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table//tbody")).Count;
            Assert.That(rowCount == 0, "Records Not Deleted Successfully");
            
        }
        public void assertionAddEducation()
        {

            //verify the expected message text
            string expectedMessage1 = "Education has been added";
            string expectedMessage2 = "This information is already exist.";
            string expectedMessage3 = "Education information was invalid";
            string expectedMessage4 = "Please enter all the fields";
            string expectedMessage5 = "Duplicated data";

            string actualmessage = addDeleteEducationComponentObj.GetMessageWindow();
            Assert.That(actualmessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4).Or.EqualTo(expectedMessage5));

        }
        public void assertionDeleteEducation()
        {
            string actualmessage = addDeleteEducationComponentObj.GetMessageWindow();
            string expectedMessage = "Education entry successfully removed";
            Assert.That(actualmessage == expectedMessage, "Actual and expected message do not match");
        }

    }
}