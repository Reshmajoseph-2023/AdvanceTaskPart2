using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;

namespace AdvancedtaskSpecflow.Pages.Components.Profile
{
    public class ProfilePageTabsComponents : CommonDriver
    {

        private IWebElement educationTab;
        private IWebElement certificationTab;
        private IWebElement manageListings;
        private IWebElement UpdateshareSkillIcon;
        private IWebElement ElementToDelete;
        private IWebElement ClickDelete;
        private IWebElement UserTab;
        private IWebElement DescriptionTab;
        private IWebElement ManageRequest;
    
        public void renderComponents()
        {
            try
            {
                educationTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
                certificationTab = driver.FindElement(By.XPath("//a[text() = 'Certifications']"));
                manageListings = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public void renderUpdateShareSkillIcon()
        {
            try
            {
                UpdateshareSkillIcon = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteShareSkillIcon(string title)
        {
            try
            {

                ClickDelete = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderUserTab()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//*[starts-with(text(),'Hi')]", 4);
                UserTab = driver.FindElement(By.XPath("//*[starts-with(text(),'Hi')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void renderDescriptionComponents()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//h3[text()='Description']/span/i[@class='outline write icon']", 6);
                DescriptionTab = driver.FindElement(By.XPath("//h3[text()='Description']/span/i[@class='outline write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderManageRequest()
        {
            try
            {
               
                ManageRequest = driver.FindElement(By.XPath("/html/body/div[1]/div/section[1]/div/div[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void clickEducationTab()
        {
            renderComponents();
            educationTab.Click();
        }
        public void clickCertificationTab()
        {
            renderComponents();
            certificationTab.Click();
        }

        public void clickManageListings()
        {
            renderComponents();
            manageListings.Click();
            Thread.Sleep(5000);
        }

        public void clickOnManageRequest()
        {
            renderManageRequest();
            Thread.Sleep(5000);
            ManageRequest.Click();

        }
        public void clickupdateShareSkill()
        {
            renderUpdateShareSkillIcon();
            UpdateshareSkillIcon.Click();
            Thread.Sleep(3000);

        }
        public void clickDeleteShareSkill(ShareSkillModel deleteskill)
        {
            string title = deleteskill.title;
            renderDeleteShareSkillIcon(title);
            ClickDelete.Click();
            Thread.Sleep(3000);

        }
        public void clickUserTab()
        {
            renderUserTab();
            UserTab.Click();
        }
        public void clickDescription()
        {
            renderDescriptionComponents();
            DescriptionTab.Click();
            Thread.Sleep(4000);
        }
    }
}
