Feature: Login
	Login to Trello web application

@smoke
Scenario: Perform Login of Trello Application site
	Given I launch the application
	And I click login link
	And I enter the following username
	| user                         | 
	| testio.hismahilova@gmail.com | 
	And I click Login With Atlassian button
	And I enter the following password
	| password |
	| test5A12!|
	When I click login button
	Then I should see Most popular templates text