Feature: Language
	As a skill trader
	I want to Add, Edit, Delete Language under profile

@Automate @p1
Scenario:1 Add Language
	Given I Click on Language tab under profile
	And I Add Language
	Then I should see Added language display in list

@Automate @p2
Scenario:2 Edit Language
	Given I Click on Language tab under profile
	And I Update Language
	Then I should see Updated language display in list

@Automate @p3
Scenario:3 Delete Language
	Given I Click on Language tab under profile
	And I Delete language
	Then I should see pop up message display on screen

