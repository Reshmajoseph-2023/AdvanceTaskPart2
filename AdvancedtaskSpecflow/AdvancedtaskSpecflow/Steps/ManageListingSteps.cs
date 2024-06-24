﻿using AdvancedtaskSpecflow.Assert_Helpers;
using AdvancedtaskSpecflow.Pages.Components.NavigationMenu;
using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;




namespace AdvancedtaskSpecflow.Steps
{
    public class ManageListingSteps : CommonDriver
    {
    
        ManageListingsComponent manageListingsComponentObj;
        AssertionManageListings assertionManageListingsObj;
        ProfileTabPageSteps profileTabPageStepsObj;
 
        public ManageListingSteps()
        {
            manageListingsComponentObj = new ManageListingsComponent();
            assertionManageListingsObj = new AssertionManageListings();
            profileTabPageStepsObj = new ProfileTabPageSteps();
         
        }
        public void verifyViewOption()
        {
            bool clickview = manageListingsComponentObj.VerifyClickView();
            Console.WriteLine("User was able to view listing");
        }
        public void verifyEditOption()
        {
            bool clickview = manageListingsComponentObj.VerifyClickEdit();
            Console.WriteLine("User was able to click on edit listing");
        }

        public void AddShareSkill(string AddJsonFilePath)
        {
            List<ShareSkillModel> ShareSkillModelList = JsonHelper.ReadTestDataFromJson<ShareSkillModel>(AddJsonFilePath);
            foreach (var adddata in ShareSkillModelList)
            {

                manageListingsComponentObj.addshareSkill(adddata);
               
            }
        }
        public void verifyUpdateOption(string AddJsonFilePath)
        {
            List<ShareSkillModel> ShareSkillModelList = JsonHelper.ReadTestDataFromJson<ShareSkillModel>(AddJsonFilePath);
            foreach (var updatedata in ShareSkillModelList)
            {

                manageListingsComponentObj.VerifyClickUpdate(updatedata);
                
            }
        }
        public void verifyDeleteOption()
        {
                
                profileTabPageStepsObj.clickDeleteShareSkillIcon();
                manageListingsComponentObj.VerifyClickDelete();
                string actualmessage = manageListingsComponentObj.GetMessageWindow();
                Console.WriteLine(actualmessage);
           
        }
        public void verifyToggleOption()
        {
            bool clickview = manageListingsComponentObj.VerifyClickEnable();
            Console.WriteLine("User was able to enable service");
        }
       
    }
}