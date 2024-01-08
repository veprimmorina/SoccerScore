Feature: Predict With Result Matches

@mytag
Scenario: Predicting with Result Matches
	Given the application is available for predicting with result matches
	When I send a POST request to the predict with result endpoint with the following data:
	| UserId | MatchId | HomeScore | AwayScore |
	| 123 | 144 | 2 | 1 |
	Then the response status code should be 200 OK for successful prediction with result