Feature: ManageRequestFeature

As a user, 
I would like to receive, sent and complete requests in the Manage Requests

Background: 
    
	Given  User logs into Mars portal and navigate to manage request tab successfully

    Scenario: 01 - Accept the received requests in the Manage Requests
    When user click on received request in manage request tab
	And User accepts the received requests with '<id>' in the Manage Requests
	Then The accept requests with '<id>' are accepted successfully

	Examples: 
       | id |
       | 1  |

	Scenario Outline: 02 - Decline the received requests in the Manage Requests
	When user click on received request in manage request tab
	And User declines the received requests with '<id>' in the Manage Requests
	Then The decline requests with '<id>' are declined successfully
	
	Examples: 
       | id |
       | 3  |


    Scenario: 03 - Complete the received requests in the Manage Requests
   	When user click on received request in manage request tab
	And user accepts and completes the received requests with '<id>' in the Manage Requests
	Then The received requests with '<id>' are completed successfully

	Examples: 
       | id |
       | 2  |


	Scenario Outline: 04 - Withdraw the sent requests in the Manage Requests
    When User clicks sent requests 
	And  User withdraw the sent requests with '<id>' in the Manage Requests
	Then The withdraw requests with '<id>' are withdrawn successfully

	Examples: 
       | id |
       | 1  |


