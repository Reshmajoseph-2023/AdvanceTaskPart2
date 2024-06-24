using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;


namespace AdvancedtaskSpecflow.Pages.Components.NavigationMenu
{
    public class ManageRequestComponent:CommonDriver
    {
      
        private IWebElement SaveButton;
        private IWebElement ClickAccept;
        private IWebElement successMessage;
        private IWebElement DeclineButton;
        private IWebElement CompleteButton;
        private IWebElement WithdrawButton;
        private IWebElement closeMessageIcon;

      
        
        public void renderAcceptComponent(string title)
        {
            try
            {

                ClickAccept = driver.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Accept']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeclineComponent(string title)
        {
            try
            {
                DeclineButton = driver.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Decline']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderCompleteComponent(string title)
        {
            try
            {
                CompleteButton = driver.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Complete']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderWithdrawComponent(string title)
        {
            try
            {
                WithdrawButton = driver.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Withdraw']   "));
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
                successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ClickOnAccept(ReceivedRequestsDataModel receivedRequestsData)
        {
            
                Thread.Sleep(30000);
                string title = receivedRequestsData.Title;
                renderAcceptComponent(title);
                ClickAccept.Click();
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
     
        }
        public void clickDeclineButton(ReceivedRequestsDataModel receivedRequestsData)
        {
               Thread.Sleep(30000);
               string title = receivedRequestsData.Title;
               renderDeclineComponent(title);
               DeclineButton.Click();
               Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
        public void clickCompleteButton(ReceivedRequestsDataModel receivedRequestsData)
        {
              Thread.Sleep(30000);
              string title = receivedRequestsData.Title;
              renderCompleteComponent(title);
              CompleteButton.Click();
              Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
        public void clickWithdrawButton(SentRequestsDataModel sentRequestsData)
        { 
             Thread.Sleep(4000);
             string title = sentRequestsData.Title;
             renderWithdrawComponent(title);
             WithdrawButton.Click();
             Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }

        public string GetMessageWindow()
        {

            renderSuccessMessage();
            string message = successMessage.Text;
            closeMessageIcon.Click();
            Thread.Sleep(6000);
            return message;
            
        }
    }
}
