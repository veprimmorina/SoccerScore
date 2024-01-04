Feature: Clicked Match Testing

@mytag
Scenario: Clicking on a match
	Given the application is available for clicking on a match
	When I send a POST request to the click match endpoint with the match ID "123"
	Then the response status code should be 200 OK for clicking on the match successfully