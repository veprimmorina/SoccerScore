Feature: Coomenting in a match

Scenario: Posting a comment in a match
	Given the application is available for commenting
	When I send a POST request to the commenting endpoint with the following data:
	| UserId | MatchId | Comment |
	| a9f9ccbf-3de4-4ae6-8f82-2459efcfbf0d    | 141     | Test    |
	Then the response status code should be 200 OK for posting comment