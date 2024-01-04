Feature: Get Top Scorers By League ID Testing

@mytag
Scenario: Retrieving top scorers by league ID
	Given the external API is available for top scorers by league ID
	When I send a GET request to the get top scorers by league ID endpoint with the league ID "654"
	Then the response status code should be 200 OK for retrieving top scorers by league ID