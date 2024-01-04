Feature: Get Player Information By Name Testing

@mytag
Scenario: Retrieving player information by name
	Given the external API is available for player information by name
	When I send a GET request to the get player information by name endpoint with the name "John Doe"
	Then the response status code should be 200 OK for retrieving player information by name