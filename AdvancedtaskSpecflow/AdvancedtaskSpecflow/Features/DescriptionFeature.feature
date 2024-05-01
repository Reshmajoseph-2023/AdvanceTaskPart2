Feature: DescriptionFeature

As a user, 
I would like to enter description in the profile page


Scenario: 01 - Enter description in the profile page
	Given User logs into Mars portal and navigate to description icon successfully
	When Enter the description  "<AddJsonFilePath>"
	Then Description should be saved successfully

	Examples:
    | AddJsonFilePath                                                                                         |
    |C:\Users\reshm\source\repos\second\AdvancedtaskSpecflow\AdvancedtaskSpecflow\JsonData\AddDescription.json|
