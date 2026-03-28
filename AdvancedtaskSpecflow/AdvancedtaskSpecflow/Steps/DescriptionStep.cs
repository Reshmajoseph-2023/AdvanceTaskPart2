using AdvancedtaskSpecflow.Pages.Components.Profile;
using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;

namespace AdvancedtaskSpecflow.Steps
{
    public class DescriptionStep
    {
        ProfileDescriptionComponent DescriptionComponentObj;
        public DescriptionStep()
        {
            DescriptionComponentObj = new ProfileDescriptionComponent();
        }
        public void AddDescription(string AddJsonFilePath)
        {

            List<DescriptionModel> DescriptionModelList = JsonHelper.ReadTestDataFromJson<DescriptionModel>(AddJsonFilePath);
            foreach (var data in DescriptionModelList)
            {
                DescriptionComponentObj.enterDescription(data);
                string actualmessage = DescriptionComponentObj.getMessage();
                Console.WriteLine(actualmessage);

            }

        }
    }
}
