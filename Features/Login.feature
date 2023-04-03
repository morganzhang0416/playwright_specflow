Feature: Login


Scenario: Login a user
	Given enter the email "stevenzhang416@gmail.com"
	And enter the password "stevenzhang"
	When click the login button
	Then the result should be successful

Scenario Outline: Add two numbers permutations
	Given enter the email <LoginEmail>
	And enter the password <LoginPassword>
	When click the login button
	Then the result should be successful

	Examples:
		| LoginEmail | LoginPassword | 
		| "simon.zhang416@gmail.com"         | "stevenzhang"           | 
		

