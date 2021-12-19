Feature: Cart

@AddToBag
Scenario: Search for an item
	Given User is on the main page
	When User types <Item> in the searchbar
	Then item is shown <Item>
	When User clicks on the button 'Add to bag'
	Then item is added
	Examples: 
	| Item   |
	| Dri-FIT Sport Clash Men's Woven Hooded Training Jacket |