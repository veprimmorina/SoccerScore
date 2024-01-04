Feature: Logout Testing

@mytag
Scenario: Logging out a user
	Given the user is logged in
	When I send a GET request to the logout endpoint
	Then the response status code should be 200 OK for logout