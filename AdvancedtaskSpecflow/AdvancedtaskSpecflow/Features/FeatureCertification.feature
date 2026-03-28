Feature: Feature Certification

As a Skillswap user I would be able to show what CertificationI hold.
So that the people seeking for skills can know my certifications.
 
 Background: 
            Given  User logs into Mars portal and navigate to certification tab successfully
            When   User deletes the existing records

Scenario Outline: 01 - Add new certification with valid details
            When   User adds a new record with certification data "<AddJsonFilePath>"
            Then   Mars portal should save the new certification record 

 Examples:
      | AddJsonFilePath                                                                                                         |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\AddPositiveInputsCertification.json|

Scenario Outline: 02 - Add new certification with invalid details
           When    User adds a new record with invalid certification data "<AddJsonFilePath>"
           Then    Mars portal should save the new certification record 

 Examples:
      | AddJsonFilePath                                                                                                   |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\AddNegativeCertification.json|

Scenario Outline: 03 - Delete a certification record 
          When user adds an certification to delete "<AddJsonFilePath>"
          And  user delete the added certification record
          Then  the certification record should be deleted successfully

 Examples:
      | AddJsonFilePath                                                                                                         |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\AddPositiveInputsCertification.json|
