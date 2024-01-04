Feature: Predict With Result Matches Testing

@mytag
Scenario: Predicting matches with results
	Given the application is available for predicting matches with results
	When I send a POST request to the predict with result matches endpoint with the following data:
	| UserId | MatchId | HomeScore | AwayScore |
	| user1 | 123 | 2 | 1 |
	| user2 | 456 | 0 | 2 |
	Then the response status code should be 200 OK for predicting matches with results successfully