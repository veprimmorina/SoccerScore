Feature: Edit Comment Testing

@mytag
Scenario: Editing a comment by ID
	Given the application is available for editing a comment
	When I send a PUT request to the edit comment endpoint with the comment ID "123" and new comment content "Updated Comment"
	Then the response status code should be 200 OK for editing the comment successfully