Feature: TopAds
	As an interviewer I want to see if the candidate
	can order by multiple columns and use distinct

Background: 
	Given I want to display TopAds ads

Scenario: Display top 5 brands
	Then I should see 5 ads a page

Scenario: Show top 5 ads by page coverage amount, distinct by brand, and sorted
	Then I should see the ads sorted by coverage amount and then brand
	And it should be distinct by brand