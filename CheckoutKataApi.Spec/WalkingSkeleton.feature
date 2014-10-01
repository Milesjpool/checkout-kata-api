Feature: WalkingSkeleton
	In order to get an 'OK' response from the API
	As a developer of the API
	I want to make a request to the API

Scenario: Ensure the Api is responding correctly
	When I make a generic request to the API
	Then the API should respond with an OK status code
