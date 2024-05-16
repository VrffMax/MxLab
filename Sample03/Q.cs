namespace Sample03;

public class Q
{
    private readonly Random random = new Random();

    private readonly int _energy;
    private readonly int _vectorsLength;
    private readonly int _measuresLength;
    private readonly int _maxCounter;

    public Q(int energy, int vectorsLength, int measuresLength, int maxCounter)
    {
        _energy = energy;
        _vectorsLength = vectorsLength;
        _measuresLength = measuresLength;
        _maxCounter = maxCounter;
    }

    public Task<(int energy, int measuredEnergy, int measureError, int counter)> MeasureAsync
    {
        get
        {
            var angle = (double)_energy / int.MaxValue;
            {
                var counter = 0;
                var draftEnergies = new int[_vectorsLength];
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

                        var touchAngle = (double)measuresSum / counter;
                        {
                            draftAngle += touchAngle;
                            draftEnergies[vectorIndex] = (int)(int.MaxValue * touchAngle);
                        }
                    }

                    draftEnergy = (int)(int.MaxValue * draftAngle / _vectorsLength);

                    ///*

                    var deltas = draftEnergies.Select(x => Math.Abs(draftEnergy - x)).ToArray();
                    var minDelta = deltas.Min();

                    var minDeltaVectorIndex = Array.IndexOf(deltas, minDelta);

                    for (var vectorIndex = 0; vectorIndex < _vectorsLength && vectorIndex != minDeltaVectorIndex; vectorIndex++)
                    {
                        for (var measureIndex = 0; measureIndex < _measuresLength; measureIndex++)
                        {
                            draftCounters[vectorIndex, measureIndex] = draftCounters[minDeltaVectorIndex, measureIndex];
                        }
                    }

                    //*/
                }
                while (draftEnergy != _energy && counter < _maxCounter);

                var measureError = _energy - draftEnergy;

                return Task.FromResult((_energy, draftEnergy, measureError, counter));
            }
        }
    }
}