using AdvancedtaskSpecflow.Utilities;

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedtaskSpecflow.Pages.Components.Profile
{

    public class EducationComponent: CommonDriver
    {
        private IWebElement AddNew;
       
        public void renderComponents()
        {
            try
            {
                AddNew = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAddEducation()
        {
            renderComponents();
            AddNew.Click();
        }


    }
}
