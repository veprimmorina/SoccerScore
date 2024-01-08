Feature: Delete Comment Testing

@mytag
Scenario: Deleting a comment by ID
	Given the application is available for deleting a comment
	When I send a DELETE request to the delete comment endpoint with the comment ID "950D33E6-010A-4EAA-E243-08DBF8B389C9"
	Then the response status code should be 200 OK for deleting the comment successfully