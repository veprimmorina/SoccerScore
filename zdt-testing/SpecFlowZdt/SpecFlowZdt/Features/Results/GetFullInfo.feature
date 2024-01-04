Feature: Get Full Information Testing

@mytag
Scenario: Retrieving full information
	Given the external API is available
	When I send a GET request to the get full information endpoint
	Then the response status code should be 200 OK for retrieving full information