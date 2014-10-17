Feature: BasketPrice
	In order to know the cost of my shopping
	As a shopper
	I want to be told the total price of my basket

Scenario: Empty Basket
	Given I have an empty basket
	When I check the price of my basket
	Then the result should be 0

Scenario: Single 'A' in basket
	Given my basket contains 'A'
	When I check the price of my basket
	Then the result should be 50
	
Scenario: Single 'B' in basket
	Given my basket contains 'B'
	When I check the price of my basket
	Then the result should be 30
	
Scenario: Single 'C' in basket
	Given my basket contains 'C'
	When I check the price of my basket
	Then the result should be 20
	
Scenario: Single 'D' in basket
	Given my basket contains 'D'
	When I check the price of my basket
	Then the result should be 15