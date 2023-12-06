Feature: User Registration
  In order to register a new user
  As a user
  I want to call the registration method of the UserController

  Scenario: Register a new user successfully
    Given a user with username "newuser" does not exist
    When I register a new user with the username "newuser" and valid details
    Then the registration should be successful