using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly AppDbContext _dbContext;
        public readonly DbSet<Unit> _entities;

        public UnitRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            _entities = _dbContext.Set<Unit>();
        }

        public List<Unit> GetAllUnits()
        {
            return _entities.ToList();
        }

        public Unit GetParentUnit(Unit unit)
        {
            return _entities.AsNoTracking()
                .Where(a => a.RelationType == Entities.Enums.RelationUnitTypes.MainUnit && a.Type.Id == unit.Type.Id)
                .FirstOrDefault();
        }
    }
}
