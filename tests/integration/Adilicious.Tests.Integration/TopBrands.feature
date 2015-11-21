Feature: TopBrands
	As an interviewer I want to see if the candidate
	can order by multiple columns and use group by
Background: 
	Given I want to display TopBrands ads

Scenario: Display top 5 brands
	Then I should see 5 ads a page

Scenario: Display top 5 brands by page coverage amount sorted
	Then the ads should be sorted by Brand Name and coverage amount