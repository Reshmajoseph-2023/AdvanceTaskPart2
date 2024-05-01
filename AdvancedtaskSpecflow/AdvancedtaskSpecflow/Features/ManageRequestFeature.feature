Feature: ManageRequestFeature

As a user, 
I would like to view received,sent and completed requests


Scenario: 01 - Manage received user request
	Given  User logs into Mars portal and navigate to manage request tab successfully
	When user click on received request in manage request tab
	Then user should be able to view received requests

	
Scenario: 02 - Manage sent request
	Given  User logs into Mars portal and navigate to manage request tab successfully
	When user click on sent request in manage request tab
	Then user should be able to view sent requests

Scenario: 03 - Manage completed request
    Given  User logs into Mars portal and navigate to manage request tab successfully
	When user click on received request in manage request tab
	And user accepts the request
	Then the requets should be marked as complete



