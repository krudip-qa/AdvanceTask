Feature: Description
	As a skill trader
	I want to be Add, Edit Description

@mytag
Scenario: Add Description
	Given I should click on pen button beside Description
	When I Enter details
	Then I should see details in text Field

Scenario: Edit Description
	Given I should click on pen button beside Description
	When I  Update details
	Then I should see updated details in text Field