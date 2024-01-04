Feature: Coomenting in a match

Scenario: Posting a comment in a match
	Given the application is available for commenting
	When I send a POST request to the commenting endpoint with the following data:
	| UserId | MatchId | Comment |
	| 123    | 141     | Test    |
	Then the response status code should be 200 OK for posting comment