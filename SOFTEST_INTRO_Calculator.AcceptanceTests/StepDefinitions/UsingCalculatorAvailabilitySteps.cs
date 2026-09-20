using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;
namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorAvailabilitySteps
{
    private readonly CalculatorContext _context;
    private readonly ReliabilityContext _reliability;
    public UsingCalculatorAvailabilitySteps(CalculatorContext context, ReliabilityContext reliability)
    {
        _context = context;
        _reliability = reliability;
    }
    [When("I have entered {double} and {double} into the calculator and press MTBF")]
    public void WhenIHaveEnteredAndPressMbtf(double operating_time, double num_failures)
    {
        _reliability.Mtbf = null;
        _context.Error = null;
        try
        {
            _context.Result = _context.Calculator.MtbfFunction(operating_time, num_failures);
            _reliability.Mtbf = _context.Result;
        }
        catch (Exception error)
        {
            _context.Result = null;
            _context.Error = error;
        }
    }

    [When("I have entered {double} and {double} into the calculator and press Availability")]
    public void WhenIHaveEnteredAndPressAvailability(double mbtf, double mttr)
    {
        _reliability.Mttr = mttr;
        _context.Error = null;

        try
        {
            _context.Result = _context.Calculator.AvailabilityFunction(mbtf, mttr);
        }
        catch (Exception error)
        {
            _context.Result = null;
            _context.Error = error;
        }
    }

    [When("I calculate Availability from these values")]
    public void WhenIHaveDataTableAndPressAvailability()
    {
        _context.Error = null;
        Assert.That(_reliability.Mtbf, Is.Not.Null, "MTBF was not set");
        Assert.That(_reliability.Mttr, Is.Not.Null, "MTTR was not set");
        double mtbf = _reliability.Mtbf!.Value;
        double mttr = _reliability.Mttr!.Value;

        try
        {
            _context.Result = _context.Calculator.AvailabilityFunction(mtbf, mttr);
        }
        catch (Exception error)
        {
            _context.Error = error;
        }
    }

    [Given("the reliability values are")]
    public void GivenTheReliabilityValuesAre(DataTable table)

    {
        var values = table.Rows[0];
        _reliability.Mtbf = double.Parse(values["MTBF"]);
        _reliability.Mttr = double.Parse(values["MTTR"]);
    }
}
