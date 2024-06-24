using AdvancedtaskSpecflow.Pages.Components.Profile;
using AdvancedtaskSpecflow.Test_Model;
using AdvancedtaskSpecflow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedtaskSpecflow.Steps
{
    public class ProfileTabPageSteps : CommonDriver

    {
        private ProfilePageTabsComponents profilePageTabsComponents;

        public ProfileTabPageSteps()
        {

            profilePageTabsComponents = new ProfilePageTabsComponents();
        }
        public void clickEducationTab()
        {
            profilePageTabsComponents.clickEducationTab();
        }

        public void clickCertificationTab()
        {
            profilePageTabsComponents.clickCertificationTab();
        }

        public void clickManageListings()

        {
            profilePageTabsComponents.clickManageListings();
        }
        public void clickManageRequest()

        {
            profilePageTabsComponents.clickOnManageRequest();
        }
        public void clickAddShareSkillIcon()
        {
            profilePageTabsComponents.clickAddShareSkill();
        }
        public void clickUpdateShareSkillIcon()
        {
            profilePageTabsComponents.clickupdateShareSkill();
        }
        public void clickDeleteShareSkillIcon()

        {
            profilePageTabsComponents.clickDeleteShareSkill();
        }
        public void clickUserTab()
        {
            profilePageTabsComponents.clickUserTab();
        }
        public void clickDescriptionIcon()
        {
            profilePageTabsComponents.clickDescription();
        }
        
    }
}