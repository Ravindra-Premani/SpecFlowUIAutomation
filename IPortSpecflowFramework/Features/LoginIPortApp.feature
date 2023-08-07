Feature: FT_001_LoginIPortApp
	As a user of IPORT Application
	I want to verify whether I can successfully login to the IPORT application or not only using the valid credentials

@smoke
Scenario: TS 001 Login user with Valid Credentials
	Given I navigate to application
	When User enters UserName and Password
		| UserName                             | Password |
		| sarvesh.maurya.consultant@nielsen.com | iPort!23 |
	When User clicks login
	Then Verify Create iPort Now Button Is Visible

Scenario: TS 002 Login user with InValid UserName
	Given I navigate to application
	When User enters UserName and Password
		| UserName                             | Password |
		| sarvesh.marya.consultant@nielsen.com | iPort!23 |
	When User clicks login
	Then Verify the wrong username and password message

Scenario: TS 003 Login user with InValid Password
	Given I navigate to application
	When User enters UserName and Password
		| UserName                              | Password |
		| sarvesh.maurya.consultant@nielsen.com | iPort23  |
	When User clicks login
	Then Verify the wrong username and password message

Scenario: TS 004 Create Excel Sheet XLS
	When User creates excel sheet "IPORT_Input_Sheet.xls"
		| IPORT URL                                       | UserName                              | Password |
		| https://dashboard-eu-iport.nielsen-iwatch.com/# | sarvesh.maurya.consultant@nielsen.com | iPort!23 |