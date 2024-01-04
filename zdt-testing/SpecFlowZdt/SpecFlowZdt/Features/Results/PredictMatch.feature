Feature: Predict Match Testing

@mytag
Scenario: Predicting a match
	Given the application is available for predicting a match
	When I send a POST request to the predict match endpoint with the user ID "user123", match ID "456", and prediction "2"
	Then the response status code should be 200 OK for predicting the match successfully