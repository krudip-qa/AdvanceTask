Feature: Certificate
	As a Skill trader
	I want to Add, Edit and Delete Certificate under profile 

@Automate @p1
Scenario:1 Add Certicate
	Given I should click on certificate tab under profile
	When I add Certidicate 
	Then I should able to see Added details Certificate in list 

@Automate @p2	
Scenario:2 Edit Certificate
	Given I should click on certificate tab under profile
	When I Edit certificate
	Then I should be able to see edit details Certificate in list 

@Automate @p3
Scenario:3 Delete Certificate
	Given I should click on certificate tab under profile
	When I Delete certificate
	Then I should be able to see conformation pop up message on screen