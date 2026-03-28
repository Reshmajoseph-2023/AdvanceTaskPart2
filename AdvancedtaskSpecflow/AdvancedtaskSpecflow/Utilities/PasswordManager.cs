using AdvancedtaskSpecflow.Test_Model;
using AventStack.ExtentReports.Model;
using Gherkin.CucumberMessages.Types;
using Newtonsoft.Json;


namespace AdvancedtaskSpecflow.Utilities
{
    public class PasswordManager
    {
        public void UpdatePassword(string newPassword)
        {
            // Read existing JSON data including username and password from UserInformation.json
            string json = File.ReadAllText("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\UserLoginInformation.json");

            // Deserialize JSON to UserLoginModel object
            List<UserLoginModel> userDataList = JsonConvert.DeserializeObject<List<UserLoginModel>>(json);

            // Find the user with the specified username
            UserLoginModel user = userDataList.FirstOrDefault(u => u.UserName == "reshmajoseph1201@gmail.com");

           // Update the password
            user.Password = newPassword;

            // Serialize the updated data back to JSON(use userDataList instead of newPassword)
            string updatedJson = JsonConvert.SerializeObject(userDataList, Formatting.Indented); 

            // Write the updated JSON back to the file
            File.WriteAllText("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\UserLoginInformation.json", updatedJson);
           
        }
    }
}