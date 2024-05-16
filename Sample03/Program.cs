namespace Sample03;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Hello. This sample # 03.");

        const int maxCounter = 100000000;

        var random = new Random();

        var noErrorCounters = new int[10, 10];

        for (var vectorIndex = 0; vectorIndex < 10; vectorIndex++)
        {
            for (var measureIndex = 0; measureIndex < 10; measureIndex++)
            {
                var vectorsLength = vectorIndex + 1;
                var measuresLength = measureIndex + 1;

                var noErrorCounter = 0;

                var qTasks = new List<Task<(int energy, int measuredEnergy, int measureError, int counter)>>(10);

                for (var measureCounter = 0; measureCounter < 10; measureCounter++)
                {
                    var energy = random.Next();
                    var q = new Q(energy, vectorsLength, measuresLength, maxCounter);

                    qTasks.Add(q.MeasureAsync);

                }

                await Task.WhenAll(qTasks);

                for (var measureCounter = 0; measureCounter < 10; measureCounter++)
                {
                    if (qTasks[measureCounter].Result.measureError == 0)
                    {
                        noErrorCounter++;
                    }
                }

                noErrorCounters[vectorIndex, measureIndex] = noErrorCounter;

                Console.Write("{0}\t", noErrorCounter);
            }

            var rowSum = Enumerable.Range(0, noErrorCounters.GetLength(1)).Select(x => noErrorCounters[vectorIndex, x]).Sum();

            Console.WriteLine(rowSum);
        }

        for (var measureIndex = 0; measureIndex < 10; measureIndex++)
        {
            var columnSum = Enumerable.Range(0, noErrorCounters.GetLength(0)).Select(x => noErrorCounters[x, measureIndex]).Sum();

            Console.Write("{0}\t", columnSum);
        }

        Console.ReadKey(intercept: true);
    }
}