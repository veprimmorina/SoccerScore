Feature: Login with Username and Password Testing

@mytag
Scenario: Logging in with username and password
	Given the application is available for logging in with username and password
	When I send a POST request to the login endpoint with the following data:
	| Username | Password |
	| testuser1 | P@ssw0rd |
	Then the response status code should be 200 OK for successful login