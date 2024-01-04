Feature: Delete Comment Testing

@mytag
Scenario: Deleting a comment by ID
	Given the application is available for deleting a comment
	When I send a DELETE request to the delete comment endpoint with the comment ID "456"
	Then the response status code should be 200 OK for deleting the comment successfully