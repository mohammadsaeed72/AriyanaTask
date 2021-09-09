using Entities;
using System.Collections.Generic;

namespace Data.Repository
{
    public interface IUnitRepository
    {
        List<Unit> GetAllUnits();
        Unit GetParentUnit(Unit unit);
    }
}