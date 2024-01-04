Feature: Get League Standings By ID Testing

@mytag
Scenario: Retrieving league standings by ID
	Given the external API is available for league standings by ID
	When I send a GET request to the get league standings by ID endpoint with the league ID "987"
	Then the response status code should be 200 OK for retrieving league standings by ID