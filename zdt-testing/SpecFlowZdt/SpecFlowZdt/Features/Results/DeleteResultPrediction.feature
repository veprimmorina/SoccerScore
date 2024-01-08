Feature: Delete Result Prediction Testing

@mytag
Scenario: Deleting user result prediction
	Given the application is available for deleting user result predictions
	When I send a DELETE request to the delete result prediction endpoint with the following data:
	| PredictionId |
	| 2C18F9C3-A054-464F-91CF-975B4718A35C |
	Then the response status code should be 200 OK for deleting user result predictions successfully