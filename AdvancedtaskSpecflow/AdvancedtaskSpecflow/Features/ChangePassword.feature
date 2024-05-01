Feature: ChangePassword

As a user, 
I would like to change the new password


Scenario: 01 - Change the Password
    Given User logs into Mars portal and navigate to user tab successfully
	When User clicks Change Password and updates the new password with "<AddJsonFilePath>"
	Then New Password should be updated successfully

	Examples:
    | AddJsonFilePath                                                                                         |
    |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\ChangePassword.json|
