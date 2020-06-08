Feature: Skill
	As a skill trader
	I want to Add, Edit and Delete Skill under Profile Tab

@Automate @p1
Scenario:1 Add Skill
	Given I click on skill tab under profile
	And I Add skill
	Then I should able to see entered skill display in list

@Automarte @p2
Scenario:2 Update Skill
	Given I click on skill tab under profile
	And I Edit Skill
	Then I should be able to see updated skill in skill list

Scenario:3 Delete Skill
	Given I click on skill tab under profile
	And I delete skill
	Then I should be able to see deleted skill in list 