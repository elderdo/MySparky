namespace Sparky;

public class Calculator
{
    public List<int> NumberRanage { get; set; } = new();

    public int AddNumbers(int a, int b)
    {
        return a + b;
    }

    public double AddNumbersDouble(double a, double b)
    {
        return a + b;
    }

    public bool IsOddNumber(int a)
    {
        return a % 2 != 0;
    }

    public List<int> GetOddRanage(int min, int max)
    {
        NumberRanage.Clear();
        for (int i = min; i < max; i++)
        {
            if (i % 2 != 0)
            {
                NumberRanage.Add(i);
            }
        }
        return NumberRanage;
    }
}

