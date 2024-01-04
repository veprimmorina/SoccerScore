Feature: Get League Information Testing

@mytag
Scenario: Retrieving league information by ID
	Given the external API is available for league information by ID
	When I send a GET request to the get league information endpoint with the ID "789"
	Then the response status code should be 200 OK for retrieving league information