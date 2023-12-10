Feature: GetMatchesByDate

@tag1
Scenario: Get matches by date
	Given the main application is available
	When I send a GET request to the get matches by date endpoint with specified date "2023-12-10"
	Then the response status code should be 200 OK