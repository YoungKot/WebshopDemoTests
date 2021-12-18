Feature: Country

@VerifyCountry
Scenario: Verify country 
	Given the user is on the main page
	When the user checks the current country name
	Then current country is Latvia