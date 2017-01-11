Feature: BookingAPI
	In order to avoid mistakes
	I want to test booking API


Scenario: Verify that Apartment Bouchardon is available in search and price matches price in details
	Given I searched for products with parameters
	| From      | TO         | Currency | Guests |
	| current+3 | current+10 | USD      | 2      |
	When I look at Apartment Bouchardon product
	Then I can see price in results list is equal to price in product details

Scenario: Verify that price matches price in details for Apartment Miromesnil 2
	Given I searched for products with parameters
	| From      | TO         | Currency | Guests |
	| current+3 | current+10 | USD      | 2      |
	When I look at Apartment Miromesnil 2 product
	Then I can see price in results list is equal to price in product details