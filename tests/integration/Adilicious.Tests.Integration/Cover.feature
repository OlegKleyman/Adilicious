Feature: Cover
	As an interviewer I want to see if the candidate
	can display display filtered data

Background: 
	Given I want to display Cover ads

Scenario: Display cover ads paged	
	Then I should see 10 ads a page
	And there should be 8 pages

Scenario: All results should have a cover position
	Then all results should have a cover position

Scenario: Default sort order is the brand name
	Then the data should be sorted

Scenario Outline: Sort ads by column
	When I click the <ColumnName> column
	Then the data should be sorted

Examples: 
	| ColumnName |
	| Ad Id      |
	| Brand Id   |
	| Num Pages  |