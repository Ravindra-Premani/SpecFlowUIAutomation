Feature: FT_005_CreateTextAndGraphLayoutInCanvas
	As a user of IPORT Application
	I want to verify whether I can successfully create/drag a new text and graph layout in the drawing canvas area 
	in iport application or not

Background:
	Given I navigate to application
	When User enters UserName and Password
		| UserName                              | Password |
		| sarvesh.maurya.consultant@nielsen.com | iPort!23 |
	When User clicks login
	Then Verify Create iPort Now Button Is Visible
	Then User enters dashboard name "AutoTest"
	Then User clicks create new Iport button
	When User to click on My iPorts drop down
	Then User to verify the newly created dashboard in My iPorts dropdown

@smoke
Scenario: TS 011 User to verify the newly created/dragged text layout in drawing canvas area in My iPort App
	When User drags the mouse to create the text layout
	Then User to verify the newly created text layout in drawing canvas