Feature: Get Player Information By ID Testing

@mytag
Scenario: Retrieving player information by ID
	Given the external API is available for player information by ID
	When I send a GET request to the get player information by ID endpoint with the player ID "12345"
	Then the response status code should be 200 OK for retrieving player information by ID