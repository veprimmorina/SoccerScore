Feature: Register Testing

@mytag
Scenario: Registering a new user
    Given the registration endpoint is available
    When I send a POST request to the register endpoint with the following data:
      | Username | Email            | Password | ConfirmationPassword | PhoneNumber | Name | Surname |
      | testuser | test@example.com | P@ssw0rd | P@ssw0rd             | 1234567890  | Test | Test     |
    Then the response status code should be 200 OK