using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;


namespace AdvancedtaskSpecflow.Pages.Components.NavigationMenu
{
    public class ManageRequestComponent:CommonDriver
    {
        private IWebElement ClickReceive;
        private IWebElement ClickSent;
        private IWebElement ClickEnable;
        private IWebElement ClickSendRequest;
        private IWebElement SaveButton;
        private IWebElement messageBox;
        private IWebElement ClickAccept;
        private IWebElement ClickonStatusIcon;
      

        public void renderReceivedComponents()
        {
            try
            {


                ClickReceive = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]/div/a[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSentCompnents()
        {
            try
            {


                ClickSent = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]/div/a[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderStatusComponent()
        {
            try
            {


                ClickonStatusIcon = driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/thead/tr/th[5]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAcceptComponent()
        {
            try
            {


                ClickAccept = driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAddMessage()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 9);
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public bool VerifyReceivedRequest()
        {
            try
            {
                renderReceivedComponents();
                Thread.Sleep(6000);
                ClickReceive.Click();
                Thread.Sleep(6000);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool VerifySentRequest()
        {
            try
            {
                renderSentCompnents();
                Thread.Sleep(6000);
                ClickSent.Click();
                Thread.Sleep(6000);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }
        public void ClickOnAccept()
        {
            try
            {
                renderStatusComponent();
                ClickonStatusIcon.Click();
                Thread.Sleep(6000);
                renderAcceptComponent();
                ClickAccept.Click();
                Thread.Sleep(6000);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);

            }
        }
        public string GetMessageWindow()
        {

            renderAddMessage();
            //get the text of the message element
            return messageBox.Text;

        }
    }
}
