Feature: Get Players By Team ID Testing

@mytag
Scenario: Retrieving players by team ID
	Given the external API is available for players by team ID
	When I send a GET request to the get players by team ID endpoint with the team ID "456"
	Then the response status code should be 200 OK for retrieving players by team ID