Feature: Delete Result Prediction Testing

@mytag
Scenario: Deleting user result prediction
	Given the application is available for deleting user result predictions
	When I send a DELETE request to the delete result prediction endpoint with the following data:
	| PredictionId |
	| 1234-5678-ABCD-1234 |
	Then the response status code should be 200 OK for deleting user result predictions successfully