Feature: Education Feature

As a Skillswap user I would be able to show what education I hold.
So that the people seeking for skills can know my education.
 
Background: 
       Given  User logs into Mars portal and navigate to education tab successfully
       When   User deletes existing records

   
Scenario: 01 - Add new education with valid details
       When   User adds a new record with education data "<AddJsonFilePath>"
       Then   Mars portal should save the new education record 

       Examples:
      | AddJsonFilePath                                                                                       |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\AddEducation.json|


 Scenario: 02 - Delete a education record 
       When user adds an education to delete"<AddJsonFilePath>"
       And user delete the added education record
       Then the education should be deleted successfully

        Examples:       
      | AddJsonFilePath                                                                                                          |
      | C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\JsonData\\AddEducationToDelete.json |
     