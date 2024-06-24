using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;


namespace AdvancedtaskSpecflow.Pages.Components.Login
{
    public class LoginComponent:CommonDriver
    {
        public IWebElement emailField;
        public IWebElement passwordField;
        public IWebElement loginButton;
        public IWebElement signInButton;
  
        public void renderAddComponents()
        {
            try
            {

                emailField = driver.FindElement(By.Name("email"));
                passwordField = driver.FindElement(By.Name("password"));
                loginButton = driver.FindElement(By.XPath("//button[text()='Login']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSignInComponent()
        {
            try
            {
                signInButton = driver.FindElement(By.XPath("//a[text()='Sign In']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void LoginSteps()
        {
            renderSignInComponent();
            signInButton.Click();
            renderAddComponents();
            List<UserLoginModel> UserInformationList = JsonHelper.ReadTestDataFromJson<UserLoginModel>("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\UserLoginInformation.json");
            foreach (var logindata in UserInformationList)
            {
                emailField.SendKeys(logindata.UserName);
                passwordField.SendKeys(logindata.Password);

            }
            loginButton.Click();
            Thread.Sleep(5000);

        }
    }
}

