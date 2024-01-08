Feature: Pin League Testing

@mytag
Scenario: Pinning a league for a user
	Given the application is available for pinning a league
	When I send a POST request to the pin league endpoint with the user ID "a9f9ccbf-3de4-4ae6-8f82-2459efcfbf0d" and league ID "789"
	Then the response status code should be 200 OK for pinning the league successfully