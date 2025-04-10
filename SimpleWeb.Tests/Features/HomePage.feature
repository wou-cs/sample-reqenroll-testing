Feature: Home page content

  Scenario: Home page shows welcome text
    Given I open the home page
    Then I should see "Welcome"

  Scenario: Home page shows delayed content
    Given I open the home page
    Then I should see delayed text