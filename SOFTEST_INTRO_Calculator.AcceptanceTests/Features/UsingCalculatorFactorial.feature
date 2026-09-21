@Factorial
Feature: UsingCalculatorFactorial
I want to get the factorial of a number

Scenario Outline: Factorial a number
Given I have a calculator
When I have entered <int> and press factorial
Then the integer result should be <expected>
Examples:

| int | expected |
| 0| 1|
| 1| 1|
| 5| 120|
| 20|2432902008176640000|


Scenario Outline: Reject number that is negative or more than 20
Given I have a calculator
When I have entered <int> and press factorial
Then factorial should be rejected
Examples:
| int |
| -1|
| 21|
