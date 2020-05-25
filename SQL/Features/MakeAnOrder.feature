Feature: MakeAnOrder
	In order to know how much money do I spent
	As a user
	I want to be told my order amount

Scenario: See my order amount

	When I get info about user [Sveta Kovalova] from table Orders
	Then user amount in DB is equal to 220