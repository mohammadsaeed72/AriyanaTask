using Common;
using Common.Enums;
using Data.Repository;
using Entities;
using Entities.Enums;
using System;
using System.Linq;

namespace Services
{
    public class ConvertUnitService : IConvertUnitService
    {
        private readonly IStringToFormula _stringToFormula;

        public ConvertUnitService(IStringToFormula stringToFormula)
        {
            this._stringToFormula = stringToFormula;
        }
        public double ConvertUnits(Unit fromUnit, Unit toUnit, double valueToconvert = 1)
        {
            if (fromUnit.Type.Id != toUnit.Type.Id)
            {
                throw new CustomException(ExceptionType.LogicError, "دو واحد انتخابی قابل تبدیل به بکدیگر نمی باشند");
            }

            var formulaFromUnit = ConvertToMain(fromUnit, valueToconvert);
            var formulaToUnit = ConvertFromMain(toUnit, formulaFromUnit);

            return formulaToUnit;

        }

        private double ConvertToMain(Unit unit, double valuetoconvert)
        {
            double returnVal = 1;
            switch (unit.RelationType)
            {
                case RelationUnitTypes.MainUnit:
                    returnVal = valuetoconvert ;
                    break;
                case RelationUnitTypes.RatioUnit:
                    returnVal = valuetoconvert  * Convert.ToDouble(unit.ConvertFormulas.
                        FirstOrDefault(a => a.FormulaType == FormulaType.convertToMain)
                        .Formula ?? "1");
                    break;
                case RelationUnitTypes.FormulateUnit:
                    returnVal = _stringToFormula.Eval(unit.ConvertFormulas.
                        FirstOrDefault(a => a.FormulaType == FormulaType.convertToMain)
                        .Formula.Replace("a", valuetoconvert.ToString()) ?? "1");
                    break;
                default:
                    returnVal = valuetoconvert ;
                    break;
            }

            return returnVal;
        }

        private double ConvertFromMain(Unit unit, double a)
        {
            double returnVal = 1;
            switch (unit.RelationType)
            {
                case RelationUnitTypes.MainUnit:
                    returnVal = a;
                    break;
                case RelationUnitTypes.RatioUnit:
                    returnVal = a * Convert.ToDouble(unit.ConvertFormulas.
                        FirstOrDefault(a => a.FormulaType == FormulaType.ConvertFromMain)
                        .Formula ?? "1");
                    break;
                case RelationUnitTypes.FormulateUnit:
                    returnVal = _stringToFormula.Eval(unit.ConvertFormulas.
                        FirstOrDefault(a => a.FormulaType == FormulaType.ConvertFromMain)
                        .Formula.Replace("a", a.ToString()) ?? "1");
                    break;
                default:
                    returnVal = a ;
                    break;
            }

            return returnVal;
        }
    }
}
