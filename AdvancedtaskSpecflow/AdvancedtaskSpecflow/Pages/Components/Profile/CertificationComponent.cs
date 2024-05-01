using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedtaskSpecflow.Pages.Components.Certifications
{
    public class CertificationComponent : CommonDriver
    {
        private IWebElement AddNew;
       
        public void renderComponents()
        {
            try
            {
               
                AddNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAddCertification()
        {

            renderComponents();
            AddNew.Click();
        }

    }
}
