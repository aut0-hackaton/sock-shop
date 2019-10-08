Feature: MainUseCases


Background:
	Given I logged in as user1
	And I went to "Catalogue"
	When I choose socks "Colourful"
	   * I press button "Add to cart"
	   * I press button "in cart"


Scenario: Add 2 distinct items, pay, view order
	
	When I press button "Continue shopping"
	   * I choose socks "Crossed"
	   * I press button "Add to cart"
	   * I press button "in cart"
	Then total price is 40.31
	When I press button "Proceed to checkout"
	Then I am redirected to "customer-orders" page
	   * I see my latest order with a price of 40.31
	Then I remember latest order number
	When I press button "View" on my latest order
	Then I am redirected to "customer-order.html?order=/orders/<OrderNumber>"
	   * I see total price of 40.31
 

Scenario: Add 2 same items, delete, check pay button
	When I choose socks "Colourful"
	   * I press button "Add to cart"
	   * I press button "in cart"
	Then CartProduct has the following fields:
	   | Field     | Value |
	   | Total     | 36    |
	   | UnitPrice | 18    |
	   | Quantity  | 2     |
	When I delete from cart socks "Colourful"
	Then button "Proceed to checkout" is disabled



Scenario: Change shipping details
	When I change Payment
	   * I fill in payment details as follows:
	   | Field      | Value                |
	   | CardNumber | 01LV45UNLA4682853483 |
	   | Expires    | 09/21                |
	   | CCV        | 465                  |
	Then "Payment" details are equal to the following:
	   | Field      | Value                |
	   | CardNumber | 01LV45UNLA4682853483 |
	   | Expires    | 09/21                |
	   | CCV        | 465                  |
	


Scenario Outline: Add item, change quantity, update basket
	When I change quantity of socks "Colourful" to <Quantity>
	   * I press button "Update basket"
	Then total price is <Total>
	
	Examples: 
	| Case             | Quantity | Total |
	| Valid quantity   | 1000     | 18000 |
	| Invalid quantity | -1       | 0     |

	

		
