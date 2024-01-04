Feature: Get Prediction Testing

@mytag
Scenario: Retrieving predictions for a match
	Given the application is available for retrieving predictions
	When I send a GET request to the get prediction endpoint with the match ID "789"
	Then the response status code should be 200 OK for retrieving predictions successfully