namespace Sample03;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello. This sample # 03.");

        const int vectorsLength = 2;
        const int measuresLength = 3;

        var random = new Random();

        var energy = random.Next();

        var q = new Q(energy, vectorsLength, measuresLength);

        var measuredEnergy = q.Measure;
    }
}