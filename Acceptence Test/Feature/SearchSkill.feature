Feature: SearchSkill
	As a Skill trader
	I want to search for skill and filter skill

@Automate @p1
Scenario:1 Search skill by Category
	Given I have entered skill in search Skill text box
	When I search skill by category and search user
	Then I should able to see search result on screen

@Automate @p2
Scenario:2 Search skill by Filters
	Given I have entered skill in search Skill text box
	When I search skill by filter
	Then I should able to see search result on screen