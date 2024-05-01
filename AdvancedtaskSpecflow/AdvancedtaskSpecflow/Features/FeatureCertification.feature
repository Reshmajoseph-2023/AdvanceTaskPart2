Feature: Certification Feature

As a Skillswap user I would be able to show what CertificationI hold.
So that the people seeking for skills can know my certifications.
 


Scenario Outline: 01 - Add new certification with valid details
            Given  User logs into Mars portal and navigate to certification tab successfully
            When   User deletes the existing records
            When   User adds a new record with certification data "<AddJsonFilePath>"
            Then   Mars portal should save the new certification record 

 Examples:
      | AddJsonFilePath                                                                                                         |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\AddPositiveInputsCertification.json|

Scenario Outline: 02 - Add new certification with invalid details
           Given   User logs into Mars portal and navigate to certification tab successfully
           When    User adds a new record with invalid certification data "<AddJsonFilePath>"
           Then    Mars portal should save the new certification record 

 Examples:
      | AddJsonFilePath                                                                                                   |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\AddNegativeCertification.json|

Scenario Outline: 03 - Delete an existing certification from the list 
          Given   User logs into Mars portal and navigate to certification tab successfully
          When    User deletes the speccific certification record "<AddJsonFilePath>"
          Then    the certification record should be deleted successfully

 Examples:
      | AddJsonFilePath                                                                                              |
      |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\DeleteCertification.json|