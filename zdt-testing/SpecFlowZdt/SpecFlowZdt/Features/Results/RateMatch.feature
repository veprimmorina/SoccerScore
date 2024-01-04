Feature: Rate Match Testing

@mytag
Scenario: Rating a match
	Given the application is available for rating a match
	When I send a POST request to the rate match endpoint with the user ID "user123", match ID "456", and rating "4.5"
	Then the response status code should be 200 OK for rating the match successfully