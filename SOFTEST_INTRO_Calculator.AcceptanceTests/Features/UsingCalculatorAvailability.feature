@Availability

Feature:
UsingCalculatorAvailability
In order to calculate MTBF and Availability
As someone who struggles with maths
I want to be able to use my calculator to do this

Scenario Outline: Calculating MTBF
Given I have a calculator
When I have entered <operating time> and <number of failures> into the calculator and press MTBF
Then the result should be <expected>
Examples:
| operating time | number of failures | expected |
| 3600 | 2 | 1800 |
| 6000 | 5 | 1200 |
| 10 | 10 | 1 |
| 4 | 5 | 0.8 |

Scenario Outline: Calculating Availability
Given I have a calculator
When I have entered <mtbf> and <mttr> into the calculator and press Availability
Then the result should be <expected>
Examples:
| mtbf | mttr | expected |
| 800 | 2400 | 0.25 |
| 0.2 | 0.8 | 0.2 |
| 10 | 12 | 0.4545454545 |

Scenario: Calculating Availability from named reliability values
Given I have a calculator
And the reliability values are
| MTBF | MTTR |
|90 |10| 
When I calculate Availability from these values
Then the result should be 0.9
