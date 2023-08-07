Feature: FT_003_DeleteExistingDashboards
	As a user of IPORT Application
	I want to verify whether I can successfully delete all the existing dashboards in the application or not

@smoke
Scenario: TS 007 Delete all the existing dashboards
	Given I navigate to application
	When User enters UserName and Password
		| UserName                              | Password |
		| sarvesh.maurya.consultant@nielsen.com | iPort!23 |
	When User clicks login
	Then Verify Create iPort Now Button Is Visible	
	Then Delete all the existing dashboards