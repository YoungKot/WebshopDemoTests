Feature: Filter

@SearchByBrand
Scenario: Search for leggings
	Given The user is on the main page
	When the user clicks on 'Womens'
	Then the page for ladies is shown
	When the user selects leggings
	Then the legging page is shown
	When the user selects adidas brand
	Then only adidas items are visible
	When the user selects an item
	Then the item is shown <Item>
	When the user adds an item to a cart
	Then the item is added
	Examples: 
	| Item   |
	| 3 Stripe Legging |