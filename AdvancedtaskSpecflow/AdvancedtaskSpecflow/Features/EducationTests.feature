Feature: Education Feature

As a Skillswap user I would be able to show what education I hold.
So that the people seeking for skills can know my education.
 
Scenario: 01 - Delete all existing education records
       Given  User logs into Mars portal and navigate to education tab successfully
       When   User deletes existing records
       Then   education records deleted successfully

Scenario: 02 - Add new education with valid details
       Given  User logs into Mars portal and navigate to education tab successfully
       When   User adds a new record with education data "<AddJsonFilePath>"
       Then   Mars portal should save the new education record 

       Examples:
      | AddJsonFilePath                                                                                       |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\AddEducation.json|

Scenario: 03 - Delete an existing education from the list 
       Given  User logs into Mars portal and navigate to education tab successfully
       When  User deletes the speccific education record "<AddJsonFilePath>"
       Then  the record should be deleted successfully

      Examples:       
      | AddJsonFilePath                                                                                          |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\DeleteEducation.json|