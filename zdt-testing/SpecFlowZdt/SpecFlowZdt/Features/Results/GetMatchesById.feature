Feature: Get Matches By ID Testing

@mytag
Scenario: Retrieving matches by ID
	Given the external API is available for matches by ID
	When I send a GET request to the get matches by ID endpoint with the ID "123"
	Then the response status code should be 200 OK for retrieving matches by ID