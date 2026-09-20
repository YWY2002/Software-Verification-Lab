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

Scenario Outline: Reject MTBF for negative operating time or non-positive failures
Given I have a calculator
When I have entered <operating time> and <number of failures> into the calculator and press MTBF
Then MTBF should be rejected
Examples:
| operating time | number of failures |
| -1 | 2 |
| -3600 | 5 |
| 3600 | 0 |
| 3600 | -2 |
| -100 | 0 |

Scenario Outline: Reject Availability for negative MTBF or MTTR
Given I have a calculator
When I have entered <mtbf> and <mttr> into the calculator and press Availability
Then availability should be rejected
Examples:
| mtbf | mttr |
| -1 | 10 |
| 10 | -1 |
| -5 | -5 |
| -0.2 | 0 |

Scenario: Reject Availability when MTBF and MTTR are both zero
Given I have a calculator
When I have entered 0 and 0 into the calculator and press Availability
Then availability should be undefined
