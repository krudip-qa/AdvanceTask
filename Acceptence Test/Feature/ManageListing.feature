Feature: ManageListing
	As a Skill trader
	I want to Add, Edit and Delete manage listing

@Automate @p1
Scenario:1 View manage listing
	Given I have click on manage listing tab
	When I view manage listing
	Then I should able to navigate to Service Detail page 

@Automate @p2
Scenario:2 Edit manage listing
	Given I have click on manage listing tab
	And I Edit manage listing  
	Then I should able to navigate to Service listing page 
	And I should able to see Edited skill details in manage listing page

@Automate @p3
Scenario:3 Delete manage listing
	Given I have click on manage listing tab
	When I Delete manage listing 
	Then I should able to see confirmation pop up on screen 
