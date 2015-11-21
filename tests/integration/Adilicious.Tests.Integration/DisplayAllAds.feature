Feature: Display Ads
	As an interviewer I want to see if the candidate
	can display simple data on a web page

Background: 
	Given I want to display All ads

Scenario: Display all ads paged	
	Then I should see 10 ads a page
	And there should be 10 pages

Scenario: Default sort order is the brand name
	Then the data should be sorted

Scenario Outline: Sort ads by column
	When I click the <ColumnName> column
	Then the data should be sorted

Examples: 
	| ColumnName |
	| Ad Id        |
	| Brand Id     |
	| Num Pages    |
	| Position    |