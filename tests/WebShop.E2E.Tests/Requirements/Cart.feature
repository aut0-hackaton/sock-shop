Feature: CartTests
	Check if ui for cart works as intended

Scenario: Can add product to cart
	Given it is catalog page
		And product "Holy" is added to cart
	When I navigate to cart page
	Then there is new item named "Holy" in cart
