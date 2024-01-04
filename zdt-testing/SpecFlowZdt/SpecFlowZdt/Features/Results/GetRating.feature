Feature: Get Rating Testing

@mytag
Scenario: Retrieving rating for a match
	Given the application is available for retrieving ratings
	When I send a GET request to the get rating endpoint with the match ID "789"
	Then the response status code should be 200 OK for retrieving ratings successfully