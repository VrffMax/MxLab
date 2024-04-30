namespace Sample03;

public class Q
{
    private readonly int _energy;
    private readonly int _vectorsLength;
    private readonly int _measuresLength;

    public Q(int energy, int vectorsLength, int measuresLength)
    {
        _energy = energy;
        _vectorsLength = vectorsLength;
        _measuresLength = measuresLength;
    }

    public (int energy, int counter) Measure
    {
        get
        {
            var random = new Random();

            var angle = (double)_energy / int.MaxValue;
            {
                var counter = 0;
                var draftCounters = new int[_vectorsLength, _measuresLength];

                int draftEnergy;

                do
                {
                    for (var vectorIndex = 0; vectorIndex < _vectorsLength; vectorIndex++)
                    {
                        for (var measureIndex = 0; measureIndex < _measuresLength; measureIndex++)
                        {
                            if (random.NextDouble() <= angle)
                            {
                                draftCounters[vectorIndex, measureIndex]++;
                            }
                        }
                    }

                    counter += _measuresLength;

                    var draftAngle = 0d;
                    for (var vectorIndex = 0; vectorIndex < _vectorsLength; vectorIndex++)
                    {
                        var measuresSum = 0;
                        for (var measureIndex = 0; measureIndex < _measuresLength; measureIndex++)
                        {
                            measuresSum += draftCounters[vectorIndex, measureIndex];
                        }

                        draftAngle += (double)measuresSum / counter;
                    }

                    draftEnergy = (int)(int.MaxValue * draftAngle / _vectorsLength);
                }
                while (draftEnergy != _energy);

                return (draftEnergy, counter);
            }
        }
    }
}