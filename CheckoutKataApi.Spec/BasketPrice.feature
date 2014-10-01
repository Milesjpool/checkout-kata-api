Feature: BasketPrice
	In order to know the cost of my shopping
	As a shopper
	I want to be told the total price of my basket

@InProgress
Scenario: Empty Basket
	Given I have an empty basket
	When I check the price of my basket
	Then the result should be 0
