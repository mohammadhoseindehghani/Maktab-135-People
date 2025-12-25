namespace UI_MVC.Services;

public class Calculator2 : ICalculator
{
    public Calculator2(IRealNumbers realNumbers)
    {

    }

    public int Sum(int a, int b)
    {
        return a + b + b;
    }
}