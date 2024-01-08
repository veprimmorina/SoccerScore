Feature: Confirm Email Testing

@mytag
Scenario: Confirming user email
	Given a user with a confirmation code
	When I send a GET request to the confirm email endpoint with the following data:
	| UserId | Code |
	| a9f9ccbf-3de4-4ae6-8f82-2459efcfbf0d | VGhpcyBpcyBhIGNvbmZpcm1lZCBjb2Rl |
	Then the response status code should be 200 OK for email confirmation