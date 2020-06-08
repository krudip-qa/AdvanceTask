Feature: ShareSkill
	As a skill trader 
	I want to be Enter skill details in share skill 

@Automate @p1
Scenario:1 Enter share skill
	Given I click on share skill tab
	When I Enter share skill
	Then I should able to see entered skill in manage listing 

@Automate @p2
Scenario:2 Edit share skill
	Given I click on share skill tab
	When I Edit share skill
	Then I should able to see Edited skill in manage listing 