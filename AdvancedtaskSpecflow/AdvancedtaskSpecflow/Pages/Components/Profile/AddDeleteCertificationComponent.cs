using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;

namespace AdvancedtaskSpecflow.Pages.Components.Certifications
{
    public class AddDeleteCertificationComponent:CommonDriver
    {
        
        private IWebElement CertificateorAward;
        private IWebElement CertifiedFrom;
        private IWebElement Title;
        private IWebElement messageBox;
        private IWebElement AddButton;
        private IWebElement certifiedYear;
        private IWebElement ElementToDelete;
        private IWebElement deletebutton;
        private IWebElement AddNew;
        public void renderAddComponents()
        {
            try
            {
                CertificateorAward = driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
                CertifiedFrom = driver.FindElement(By.Name("certificationFrom"));
                certifiedYear = driver.FindElement(By.Name("certificationYear"));
                AddButton = driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
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
        public void renderDeleteCertification()
        {
            try
            {
                ElementToDelete = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
                deletebutton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
     
        public void addNewCertification(CertificationModel data)
        {

            //renderComponents();

            //AddNew.Click();
            renderAddComponents();
            Thread.Sleep(2000);
            CertificateorAward.Click();
            CertificateorAward.SendKeys(data.certificateorAward);

            //Select the name of the Country
            Wait.WaitToBeVisible(driver, "Name", "certificationFrom", 3);
            CertifiedFrom.Click();
            CertifiedFrom.SendKeys(data.certifiedFrom);

            //Select the Title
            Wait.WaitToBeVisible(driver, "Name", "certificationYear", 3);
            certifiedYear.Click();
            certifiedYear.SendKeys(data.certifiedYear);

            //Click on Add button
            Wait.WaitToBeClickable(driver, "XPath", "//input [contains (@class, 'ui teal button')]", 3);
            AddButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 10);
        }
        public void DeleteCertification(CertificationModel deletecertification)
        {
            renderDeleteCertification();
            Thread.Sleep(2000);
            try
            {

                if (ElementToDelete.Text == deletecertification.certificateorAward)
                {

                    deletebutton.Click();
                    Thread.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

                Console.WriteLine("Element to delete not found");
            }


        }
        public string GetMessageWindow()
        {
            renderAddMessage();
            //get the text of the message element
            string Message = messageBox.Text;
            Thread.Sleep(4000);
            return Message;
        }
    }
}


