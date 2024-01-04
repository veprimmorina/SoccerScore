Feature: Most Clicked Matches Testing

@mytag
Scenario: Retrieving most clicked matches
	Given the application is available for retrieving most clicked matches
	When I send a GET request to the get most clicked matches endpoint
	Then the response status code should be 200 OK for retrieving most clicked matches successfully