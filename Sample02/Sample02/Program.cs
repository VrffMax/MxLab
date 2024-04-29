namespace Sample02;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello. This sample # 01.");

        var random = new Random();

        var angle = random.NextDouble();

        var intValue = (int)(int.MaxValue * angle);

        Console.WriteLine("{0}\t{1}", angle, intValue);

        Console.ReadKey(intercept: true);

        //

        const int vectorsLength = 10;
        const int measuresLength = 10;

        var intCounter = 0;
        var draftIntCounters = new int[vectorsLength, measuresLength];

        int draftIntValue;

        do
        {
            for (var vectorIndex = 0; vectorIndex < vectorsLength; vectorIndex++)
            {
                for (var measureIndex = 0; measureIndex < measuresLength; measureIndex++)
                {
                    if (random.NextDouble() <= angle)
                    {
                        draftIntCounters[vectorIndex, measureIndex]++;
                    }
                }
            }

            intCounter += measuresLength;

            var draftAngle = 0d;
            for (var vectorIndex = 0; vectorIndex < vectorsLength; vectorIndex++)
            {
                var measuresSum = 0;
                for (var measureIndex = 0; measureIndex < measuresLength; measureIndex++)
                {
                    measuresSum += draftIntCounters[vectorIndex, measureIndex];
                }

                draftAngle += (double)measuresSum / intCounter;
            }

            draftIntValue = (int)(int.MaxValue * draftAngle / vectorsLength);

            Console.WriteLine("{0}\t{1}\t{2}", intCounter, intValue, draftIntValue);
        }
        while (draftIntValue != intValue);

        Console.ReadKey(intercept: true);
    }
}