namespace Sample01;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello. This sample # 01.");

        var random = new Random();

        var angle = random.NextDouble();

        var byteValue = (byte)(byte.MaxValue * angle);
        var shortValue = (short)(short.MaxValue * angle);
        var intValue = (int)(int.MaxValue * angle);

        Console.WriteLine("{0}\t{1}\t{2}\t{3}", angle, byteValue, shortValue, intValue);

        Console.ReadKey(intercept: true);

        //

        double byteCounter = 0;
        var draftByteCounter = 0;

        byte draftByteValue;

        do
        {
            if (random.NextDouble() <= angle)
            {
                draftByteCounter++;
            }

            var draftAngle = draftByteCounter / ++byteCounter;

            draftByteValue = (byte)(byte.MaxValue * draftAngle);

            Console.WriteLine("{0}\t{1}\t{2}", byteCounter, byteValue, draftByteValue);
        }
        while (draftByteValue != byteValue);

        Console.ReadKey(intercept: true);

        //

        double shortCounter = 0;
        var draftShortCounter = 0;

        short draftShortValue;

        do
        {
            if (random.NextDouble() <= angle)
            {
                draftShortCounter++;
            }

            var draftAngle = draftShortCounter / ++shortCounter;

            draftShortValue = (short)(short.MaxValue * draftAngle);

            Console.WriteLine("{0}\t{1}\t{2}", shortCounter, shortValue, draftShortValue);
        }
        while (draftShortValue != shortValue);

        Console.ReadKey(intercept: true);

        //

        const int probabilityQuality = 3;

        int intCounter = 0;
        var draftIntCounter = new int[probabilityQuality];
        int draftIntValue;

        do
        {
            for (var index = 0; index < probabilityQuality; index++)
            {
                if (random.NextDouble() <= angle)
                {
                    draftIntCounter[index]++;
                }
            }

            var draftAngle = (double)draftIntCounter.Sum() / (draftIntCounter.Length * ++intCounter);

            draftIntValue = (int)(int.MaxValue * draftAngle);

            Console.WriteLine("{0}\t{1}\t{2}", intCounter, intValue, draftIntValue);
        }
        while (draftIntValue != intValue);

        Console.ReadKey(intercept: true);
    }
}