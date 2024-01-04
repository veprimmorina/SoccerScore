Feature: Get Player Stats By League ID Testing

@mytag
Scenario: Retrieving player stats by league ID
	Given the external API is available for player stats by league ID
	When I send a GET request to the get player stats by league ID endpoint with the league ID "789"
	Then the response status code should be 200 OK for retrieving player stats by league ID