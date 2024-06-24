using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;


namespace AdvancedtaskSpecflow.Pages.Components.Profile
{
    public class ProfileDescriptionComponent : CommonDriver
    {
        private IWebElement DescriptionTextbox;
        private IWebElement SaveButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;
        public static WebDriver driver;
        public void renderComponents()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//textarea[@name='value']", 4);
                DescriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
                SaveButton = driver.FindElement(By.XPath("//button[@type='button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSuccessMessage()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 6);
                successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void enterDescription(DescriptionModel descriptionData)
        {
            renderComponents();
            DescriptionTextbox.Clear();
            Thread.Sleep(4000);
            DescriptionTextbox.SendKeys(descriptionData.Description);
            SaveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 6);
        }

        public string getMessage()
        {
            renderSuccessMessage();
            string message = successMessage.Text;
            closeMessageIcon.Click();
            Thread.Sleep(6000);
            return message;
        }
    }
}