Feature: Get All Season Matches By League ID Testing

@mytag
Scenario: Retrieving all season matches by league ID
	Given the external API is available for all season matches by league ID
	When I send a GET request to the get all season matches by league ID endpoint with the league ID "456"
	Then the response status code should be 200 OK for retrieving all season matches by league ID