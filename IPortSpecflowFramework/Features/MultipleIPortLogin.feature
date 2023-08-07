Feature: FT_004_MultipleIPortLogin
	As a user of IPORT Application
	Fetching the data from Excel Sheet, user wants to verify whether I can successfully login to the IPORT application with multiple users or not
	by using valid credentials and throws an error if the credentials are invalid

@smoke
Scenario: TS 010 Read data from Excel Sheet XLS
	When User reads login credentials from excel sheet IPORT_Input_Sheet.xls
	When User clicks login
	Then Verify Create iPort Now Button Is Visible

Scenario: TS 011 Read multiple data from Excel Sheet XLS
	When User reads multiple login credentials from excel sheet IPORT_Input_Sheet.xls
	