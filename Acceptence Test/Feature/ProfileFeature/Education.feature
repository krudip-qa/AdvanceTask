Feature: Education
	As a skill trader 
	I want to be able to Add, Edit, Delete Education under profile page

@Automate @p1
Scenario:1 Add Education
	Given I should able to click on Education tab under profile
	When I add education
	Then I should be able to see added education in list

@Automate @p2
Scenario:2 Edit Education
	Given I should able to click on Education tab under profile
	When I edit education
	Then I should be able to see updated education in list

@Automate @p3
Scenario:3 Delete Education
	Given I should able to click on Education tab under profile
	When I delete education
	Then It should display a pop up message on screen