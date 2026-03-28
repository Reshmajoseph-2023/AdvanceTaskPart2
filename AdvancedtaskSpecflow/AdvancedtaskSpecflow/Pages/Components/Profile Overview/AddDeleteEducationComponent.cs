using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



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
                CountryOfCollege = driver.FindElement(By.XPath("//select[@name='country']"));
                Title = driver.FindElement(By.XPath("//select[@name='title']"));
                Degree = driver.FindElement(By.Name("degree"));
                YearOfGraduation = driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
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
            SelectElement chooseCountryOfCollege = new SelectElement(CountryOfCollege);
            chooseCountryOfCollege.SelectByValue(data.CountryOfCollege);

            //Select the Title
            SelectElement chooseTitle = new SelectElement(Title);
            chooseTitle.SelectByValue(data.Title);

            //Enter the Degree
            Degree.SendKeys(data.Degree);

            //Select the year of graduation
            SelectElement chooseYearOfGraduation = new SelectElement(YearOfGraduation);
            chooseYearOfGraduation.SelectByValue(data.YearOfGraduation);

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
