Feature: FT_002_CreateNewIPort
	As a user of IPORT Application
	I want to verify whether I can successfully create a new iPort in the application or not

Background:
	Given I navigate to application
	When User enters UserName and Password
		| UserName                              | Password |
		| sarvesh.maurya.consultant@nielsen.com | iPort!23 |
	When User clicks login
	Then Verify Create iPort Now Button Is Visible
	Then User enters dashboard name "AutoTest"
	Then User clicks create new Iport button

@smoke
Scenario: TS 004 User to verify the iPort logo on the landing page
	Then user verifies the iPort logo on the landing page

Scenario: TS 005 User to verify the newly created dashboard in My iPorts drop down
	When User to click on My iPorts drop down
	Then User to verify the newly created dashboard in My iPorts dropdown

Scenario: TS 006 User to verify the UserName in the My Details section
	When User clicks on My Details Section
	Then Verify the username