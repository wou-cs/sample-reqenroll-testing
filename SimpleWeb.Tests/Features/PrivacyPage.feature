Feature: Privacy content

    Scenario: Should see link to Privacy page
        Given I open the home page
        Then I should see "Privacy"

    Scenario: Should see Privacy page content
        Given I open the Privacy page
        Then I should see "privacy policy"