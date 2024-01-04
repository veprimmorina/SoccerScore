Feature: Pin League Testing

@mytag
Scenario: Pinning a league for a user
	Given the application is available for pinning a league
	When I send a POST request to the pin league endpoint with the user ID "user123" and league ID "789"
	Then the response status code should be 200 OK for pinning the league successfully