Feature: Get Team Information Testing

@mytag
Scenario: Retrieving team information by team name
	Given the external API is available for team information by team name
	When I send a GET request to the get team information endpoint with the team name "ExampleTeam"
	Then the response status code should be 200 OK for retrieving team information