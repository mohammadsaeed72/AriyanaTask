using Entities;

namespace Services
{
    public interface IConvertUnitService
    {
        double ConvertUnits(Unit fromUnit, Unit toUnit, double valueToconvert = 1);
    }
}