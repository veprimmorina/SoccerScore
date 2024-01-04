Feature: Top Rated Matches Testing

@mytag
Scenario: Retrieving top-rated matches
	Given the application is available for retrieving top-rated matches
	When I send a GET request to the get top-rated matches endpoint
	Then the response status code should be 200 OK for retrieving top-rated matches successfully