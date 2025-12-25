namespace UI_MVC.Services;

public class Calculator3 : ICalculator
{
    public Calculator3(IRealNumbers realNumbers)
    {

    }

    public int Sum(int a, int b)
    {
        return a + b + a;
    }
}