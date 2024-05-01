Feature: ManageListingsFeature

As a Skillswap user I would be able to see what skills I hold.
So that the people seeking for skills can look at what details I hold.

Scenario:01 -View Manage Listings
	Given User logs into Mars portal and navigate to managelistings tab successfully
	When User click on view manage listings
	Then User should be able to view

	
Scenario:02 -Edit Manage Listings
	Given User logs into Mars portal and navigate to managelistings tab successfully
	When User click on edit listings
	Then User should be able to click
	
Scenario:03 -Update Manage Listings
	Given User logs into Mars portal and navigate to managelistings tab successfully
	Then User Updates a Skill from Manage Listings with data "<UpdateShareSkillJsonPath>"
	

	 Examples:
      | UpdateShareSkillJsonPath                                                                                  |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\UpdateShareSkill.json|

Scenario:04 -Delete Manage Listings
	Given User logs into Mars portal and navigate to managelistings tab successfully
	When User deletes the specific record "<DeleteJsonFilePath>"
	Then that record should be deleted successfully

	 Examples:
      | DeleteJsonFilePath                                                                                        |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\DeleteShareSkill.json|

	
Scenario:05 - Toggle Enable/disable 
	Given User logs into Mars portal and navigate to managelistings tab successfully
	When User click to enable the listings
	Then The sevice should be activated

Scenario:06 -Send Request from listings
	Given User logs into Mars portal and navigate to managelistings tab successfully
	When User attempt to send requests from the listings
	Then User should be able to send the requests
	
