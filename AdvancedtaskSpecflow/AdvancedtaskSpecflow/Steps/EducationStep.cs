using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using AdvancedtaskSpecflow.Pages.Components.Profile;


namespace AdvancedtaskSpecflow.Steps
{
    public class EducationStep : CommonDriver
    {

        EducationComponent educationComponentObj;
        AddDeleteEducationComponent addDeleteEducationComponentObj;
        private static IWebElement CancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));
        public EducationStep()
        {
            educationComponentObj = new EducationComponent();
            addDeleteEducationComponentObj = new AddDeleteEducationComponent();
        }
        public void DeleteExistingRecords()
        {


            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                while (true)
                {
                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));

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
        public void AddEducation(string AddJsonFilePath)
        {
            List<EducationModel> EducationModelList = JsonHelper.ReadTestDataFromJson<EducationModel>(AddJsonFilePath);
            foreach (EducationModel data in EducationModelList)
            {
                educationComponentObj.clickAddEducation();
                addDeleteEducationComponentObj.addNewEducation(data);
                string actualmessage = addDeleteEducationComponentObj.GetMessageWindow();
                Console.WriteLine(actualmessage);

                //verify the expected message text
                string expectedMessage2 = "This information is already exist.";
                string expectedMessage3 = "Education information was invalid";
                string expectedMessage4 = "Please enter all the fields";
                string expectedMessage5 = "Duplicated data";

                
                if (actualmessage.Contains(expectedMessage2) || actualmessage.Contains(expectedMessage3) || actualmessage.Contains(expectedMessage4)|| actualmessage.Contains(expectedMessage5))
                {
                    CancelButton.Click();
                }
            }
        }
        public void deleteEducation(string AddJsonFilePath)
        {

            List<EducationModel> EducationModelList = JsonHelper.ReadTestDataFromJson<EducationModel>(AddJsonFilePath);
            foreach (var deleteeducation in EducationModelList)
            {
                addDeleteEducationComponentObj.DeleteEducation(deleteeducation);
                string actualmessage = addDeleteEducationComponentObj.GetMessageWindow();
                Console.WriteLine(actualmessage);
            }
        }
    }
}