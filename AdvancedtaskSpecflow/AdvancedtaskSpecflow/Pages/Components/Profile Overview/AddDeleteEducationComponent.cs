using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;



namespace AdvancedtaskSpecflow.Pages.Components.Profile
{

    public class AddDeleteEducationComponent : CommonDriver
    {
        private IWebElement CollegeName;
        private IWebElement CountryOfCollege;
        private IWebElement Title;
        private IWebElement Degree;
        private IWebElement YearOfGraduation;
        private IWebElement AddButton;
        private IWebElement messageBox;
        private IWebElement deletebutton;
        private IWebElement ElementToDelete;
     
       

        public void renderAddComponents()
        {
            try
            {
                CollegeName = driver.FindElement(By.Name("instituteName"));
                CountryOfCollege = driver.FindElement(By.Name("country"));
                Title = driver.FindElement(By.Name("title"));
                Degree = driver.FindElement(By.Name("degree"));
                YearOfGraduation = driver.FindElement(By.Name("yearOfGraduation"));
                AddButton = driver.FindElement(By.XPath("//input [contains (@class, 'ui teal button')]"));

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
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteEducation()
        {
            try
            {
                ElementToDelete = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]"));
                deletebutton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void addNewEducation(EducationModel data)
        {
            renderAddComponents();
          
            CollegeName.Click();
            Thread.Sleep(4000);
            CollegeName.SendKeys(data.UniversityName);
           
            //Select the name of the Country
            Wait.WaitToBeVisible(driver, "Name", "country", 3);
            CountryOfCollege.Click();
            CountryOfCollege.SendKeys(data.CountryOfCollege);

            //Select the Title
            Wait.WaitToBeVisible(driver, "Name", "title", 3);
            Title.Click();
            Title.SendKeys(data.Title);

            //Enter the Degree
            Wait.WaitToBeVisible(driver, "Name", "degree", 3);
            Degree.SendKeys(data.Degree);

            //Select the year of graduation
            Wait.WaitToBeClickable(driver, "Name", "yearOfGraduation", 3);
            YearOfGraduation.Click();
            YearOfGraduation.SendKeys(data.YearOfGraduation);

            //Click on Add button
            Wait.WaitToBeClickable(driver, "XPath", "//input [contains (@class, 'ui teal button')]", 3);
            AddButton.Click();
            Thread.Sleep(2000);
        }
        public void DeleteEducation()
        {
            renderDeleteEducation();
            Thread.Sleep(2000);
            try
            {
                    deletebutton.Click();
                    Thread.Sleep(3000);
                
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
            return Message;
        }
    }

}
