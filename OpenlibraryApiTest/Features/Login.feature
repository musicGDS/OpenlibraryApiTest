Feature: Login
	

@mytag
Scenario: Login to the page
	Given the username "musicgds@gmail.com"
	And password "visma2020"
	When logged in 
	Then verify sucessful login 

