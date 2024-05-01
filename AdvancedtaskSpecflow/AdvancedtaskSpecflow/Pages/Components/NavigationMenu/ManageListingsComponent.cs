using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;


namespace AdvancedtaskSpecflow.Pages.Components.NavigationMenu
{
    public class ManageListingsComponent:CommonDriver

    {
        private IWebElement ClickView;
        private IWebElement ClickEdit;
        private IWebElement ClickEnable;
        private IWebElement ClickSendRequest;
        private IWebElement TitleTextbox;
        private IWebElement DescriptionTextbox;
        private IWebElement CategoryDropdown;
        private IWebElement SubcategoryDropdown;
        private IWebElement TagsTextbox;
        private IWebElement HourlyBasis;
        private IWebElement ClickOneOff;
        private IWebElement messageWindow;
        private IWebElement ClickOnsite;
        private IWebElement ClickOnline;
        private IWebElement StartDate;
        private IWebElement EndDate;
        private IWebElement SelectDay;
        private IWebElement StartTime;
        private IWebElement EndTime;
        private IWebElement ClickCredit;
        private IWebElement EnterCharge;
        private IWebElement ClearTag;
        private IWebElement SaveButton;
        private IWebElement messageBox;
        private IWebElement ElementToDelete;
        private IWebElement newTitle;
        private IWebElement ClickYes;
        
        public void renderViewCompnents()
        {
            try
            {


                ClickView = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEditCompnents()
        {
            try
            {


                ClickEdit = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
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
        public void renderTitle()
        {
            try
            {
                TitleTextbox = driver.FindElement(By.Name("title"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDescription()
        {
            try
            {
                DescriptionTextbox = driver.FindElement(By.Name("description"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderCategory()
        {
            try
            {
                CategoryDropdown = driver.FindElement(By.Name("categoryId"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSubCategory()
        {
            try
            {
                SubcategoryDropdown = driver.FindElement(By.Name("subcategoryId"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderTags()
        {
            try
            {
                TagsTextbox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderServiceType()
        {
            try
            {
                HourlyBasis = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
                ClickOneOff = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderLocationType()
        {
            try
            {
                ClickOnsite = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));
                ClickOnline = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAvailableDays()
        {
            try
            {
                StartDate = driver.FindElement(By.Name("startDate"));
                EndDate = driver.FindElement(By.Name("endDate"));
                SelectDay = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));
                StartTime = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
                EndTime = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSkillTrade()
        {
            try
            {
                ClickCredit = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderCredit()
        {
            try
            {
                EnterCharge = driver.FindElement(By.Name("charge"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderClearTag()
        {
            try
            {
                ClearTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span[2]/a[last()]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderSaveButton()
        {
            try
            {
                SaveButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteComponents()
        {
            try
            {

                ElementToDelete = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteYes()
        {
            try
            {

                ClickYes = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderNewTitle()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]", 9);
                newTitle = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEnableCompnents()
        {
            try
            {


                ClickEnable = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool VerifyClickView()
        {
            try
            {
                renderViewCompnents();
                Thread.Sleep(6000);
                ClickView.Click();
                Thread.Sleep(6000);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool VerifyClickEdit()
        {
            try
            {
                renderEditCompnents();
                Thread.Sleep(6000);
                ClickEdit.Click();
                Thread.Sleep(6000);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public void VerifyClickUpdate(ShareSkillModel updateShareSkill)
        {


            renderTitle();
            TitleTextbox.Clear();
            TitleTextbox.SendKeys(updateShareSkill.title);
            renderDescription();
            DescriptionTextbox.Clear();
            DescriptionTextbox.SendKeys(updateShareSkill.description);
            renderCategory();
            CategoryDropdown.Click();
            CategoryDropdown.SendKeys(updateShareSkill.category);
            CategoryDropdown.Click();
            renderSubCategory();
            SubcategoryDropdown.Click();
            SubcategoryDropdown.SendKeys(updateShareSkill.subcategory);
            SubcategoryDropdown.Click();
            renderTags();
            TagsTextbox.Click();
            TagsTextbox.SendKeys(updateShareSkill.tagone);
            TagsTextbox.SendKeys(Keys.Enter);
            renderServiceType();
            ClickOneOff.Click();
            renderLocationType();
            ClickOnsite.Click();
            renderAvailableDays();
            StartDate.Click();
            StartDate.SendKeys(updateShareSkill.startDate);
            EndDate.Click();
            EndDate.SendKeys(updateShareSkill.endDate);
            SelectDay.Click();
            StartTime.Click();
            StartTime.SendKeys(updateShareSkill.startTime);
            EndTime.Click();
            EndTime.SendKeys(updateShareSkill.endTime);
            renderSkillTrade();
            ClickCredit.Click();
            renderCredit();
            EnterCharge.Click();
            EnterCharge.SendKeys(updateShareSkill.charge);
            renderSaveButton();
            SaveButton.Click();

        }

        public void VerifyClickDelete(ShareSkillModel deleteskill)
        {

            renderDeleteYes();
            ClickYes.Click();

        }
        public bool VerifyClickEnable()
        {
            try
            {
                renderEnableCompnents();

                ClickEnable.Click();
                Thread.Sleep(6000);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public void VerifySendRequest()
        {

            try
            {

                // Attempt to find the element
                IWebElement element = driver.FindElement(By.Id("nonexistent-element"));

                // If the element is found, perform some action
                element.Click();
            }
            catch (NoSuchElementException ex)
            {
                // Handle the "no such element" exception
                Console.WriteLine("Element not found: " + ex.Message);
            }
        }
        public string GetMessageWindow()
        {

            renderAddMessage();
            //get the text of the message element
            return messageBox.Text;

        }
        public string getTitle()
        {

            renderNewTitle();
            return newTitle.Text;
        }
    }
}