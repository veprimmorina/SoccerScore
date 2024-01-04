Feature: Confirm Email Testing

@mytag
Scenario: Confirming user email
	Given a user with a confirmation code
	When I send a GET request to the confirm email endpoint with the following data:
	| UserId | Code |
	| user1 | VGhpcyBpcyBhIGNvbmZpcm1lZCBjb2Rl |
	Then the response status code should be 200 OK for email confirmation