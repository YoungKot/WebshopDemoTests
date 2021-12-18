Feature: Filter

@SearchByBrand
Scenario: Search for female underwear
	Given The user is on the main page
	When the user clicks on 'Womens'
	Then the page for ladies is shown
	When the user selects leggings
	Then the legging page is shown
	When the user selects adidas brand
	Then only adidas items are visible