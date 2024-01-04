Feature: Get Comments Testing

@mytag
Scenario: Retrieving comments for a match
	Given the application is available for retrieving comments
	When I send a GET request to the get comments endpoint with the match ID "789"
	Then the response status code should be 200 OK for retrieving comments successfully