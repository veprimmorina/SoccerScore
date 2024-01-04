Feature: Get Prediction With Result Matches Testing

@mytag
Scenario: Retrieving user predictions with results
	Given the application is available for retrieving user predictions with results
	When I send a GET request to the get user prediction with result matches endpoint with the following data:
	| UserId |
	| user1 |
	Then the response status code should be 200 OK for retrieving user predictions with results successfully