using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using AdvancedtaskSpecflow.Assert_Helpers;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using AdvancedtaskSpecflow.Pages.Components.Certifications;
using TechTalk.SpecFlow;


namespace AdvancedtaskSpecflow.Steps
{

    public class CertificationStep : CommonDriver
    {

        CertificationComponent certificationComponentObj;
        AddDeleteCertificationComponent addDeleteCertificationComponentObj;
        AssertionCertification assertionCertificationObj;
        private IReadOnlyCollection<IWebElement> deleteButtons => driver.FindElements(By.XPath("//div[@data-tab='fourth']//i[@class='remove icon']"));
        private static IWebElement CancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[2]"));
        public CertificationStep()
        {
            certificationComponentObj = new CertificationComponent();
            addDeleteCertificationComponentObj = new AddDeleteCertificationComponent();
            assertionCertificationObj = new AssertionCertification();
        }
        public void DeleteExistingRecords()
        {
                            
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                while (true)
                {
                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));

                    if (deleteButtons.Count == 0)
                    {
                        break;
                    }
                    foreach (var button in deleteButtons)
                    {
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(button)).Click();
                            Thread.Sleep(5000);
                        }
                        catch (StaleElementReferenceException)
                        {
                            // Handle the exception by re-checking the element 
                        }
                    }
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No items to delete");
            }
           
        }

        public void AddCertification(string AddJsonFilePath)
        {
       
            List<CertificationModel> CertiificationModelList = JsonHelper.ReadTestDataFromJson<CertificationModel>(AddJsonFilePath);
            foreach (var data in CertiificationModelList)
            {
                certificationComponentObj.clickAddCertification();
                addDeleteCertificationComponentObj.addNewCertification(data);

                string actualmessage = addDeleteCertificationComponentObj.GetMessageWindow();

                Console.WriteLine(actualmessage);
                string expectedMessage2 = "This information is already exist.";
                string expectedMessage3 = "Please enter Certification Name, Certification From and Certification Year";
                string expectedMessage4 = "Duplicated data";
                if (actualmessage.Contains(expectedMessage2) || actualmessage.Contains(expectedMessage3) || actualmessage.Contains(expectedMessage4))
                {
                    CancelButton.Click();
                }

            }

        }
        public void DeleteCertification(string AddJsonFilePath)
        {

            List<CertificationModel> CertiificationModelList = JsonHelper.ReadTestDataFromJson<CertificationModel>(AddJsonFilePath);
            foreach (var deletecertification in CertiificationModelList)
            {
                addDeleteCertificationComponentObj.DeleteCertification(deletecertification);
                string actualmessage = addDeleteCertificationComponentObj.GetMessageWindow();
                Console.WriteLine(actualmessage);
            }
        }
    }

}