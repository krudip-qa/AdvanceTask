Feature: ProfileDetail
	In order to manage Seller's profile Details
	As a Turn Up portal admin
	I want to Add,Edit,Delete and view Seller's profile details like Name, Availability, Hour, Earn Target

@Automate @p1
Scenario:1 Check if the user able to 'View' Name
	When I View name 
	Then It Should has first name and last name
	

Scenario: Check if the user able to 'Edit' Name
	When I update Name
	Then Titlt name needs to be same as Updated name
    
@Automate @p2
Scenario:2 Check if the user is able to "Select" the Availability 
	When I select Availability
	Then I should see Confirmation pop up on screen
	

Scenario: Check if the user is able to "Edit" the Availablity
	When I Update selected Availability
	Then I should see Confirmation pop up on screen

@Automate @p3
Scenario:3 Check if the user is able to "Select" the Hours
	When I select an Hours
	Then I should see Confirmation pop up on screen

Scenario: Check if the user is able to "Edit" the Hours
	When I Update selected Hours
	Then I should see Confirmation pop up on screen

@Automate @p4
Scenario:4 Check if the user is able to "Select "the Earnings Target
	When I select an Earning Target
	Then I should see Confirmation pop up on screen	


Scenario: Check if the user is able to "Edit" the Earnings Target
	When I Update selected Earning Target 
	Then I should see Confirmation pop up on screen	
	 