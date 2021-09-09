using Entities;
using Entities.Enums;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestUnit
{
    public class TestConvertUnitService
    {
        private IConvertUnitService _UnitService;
        public TestConvertUnitService()
        {
            _UnitService = new ConvertUnitService(new StringToFormula());
        }

        [Fact]
        public void checkService_checkRatiotypeWorkFine()
        {
            Unit fromUnit = new Unit()
            {
                ConvertFormulas = new List<ConvertFormula>()
                {
                    new ConvertFormula()
                    {
                        Formula = "0.01",
                        FormulaType = FormulaType.convertToMain,
                        UnitId = 2
                        
                    },
                    new ConvertFormula()
                    {
                        Formula = "100",
                        FormulaType = FormulaType.ConvertFromMain,
                        UnitId = 2
                    }
                },
                Id = 2,
                Name = "centiMeter",
                NameFa = "سانتی متر",
                ParentRef = 1,
                Simbol = "cm",
                Type = new UnitType()
                {
                    Id = 1,
                    NameFa = "اندازه گیری طول"
                },
                RelationType = RelationUnitTypes.RatioUnit
            };

            Unit toUnit = new Unit()
            {
                ConvertFormulas = new List<ConvertFormula>()
                {
                    new ConvertFormula()
                    {
                        Formula = "0.1",
                        FormulaType = FormulaType.convertToMain,
                        UnitId = 3
                    },
                    new ConvertFormula()
                    {
                        Formula = "10",
                        FormulaType = FormulaType.ConvertFromMain,
                        UnitId = 3
                    }
                },
                Id = 3,
                Name = "deciMeter",
                NameFa = "دسی متر",
                ParentRef = 1,
                Simbol = "dm",
                Type = new UnitType()
                {
                    Id = 1,
                    NameFa = "اندازه گیری طول"
                },
                RelationType = RelationUnitTypes.RatioUnit
            };


            var convertedVal=_UnitService.ConvertUnits(fromUnit, toUnit, 100);
            Assert.Equal<double>(10, convertedVal);
        }

        [Fact]
        public void checkService_checkFormulatypeWorkFine()
        {
            Unit fromUnit = new Unit()
            {
                ConvertFormulas = new List<ConvertFormula>()
                {
                    new ConvertFormula()
                    {
                        Formula = "a-273",
                        FormulaType = FormulaType.convertToMain,
                        UnitId = 2

                    },
                    new ConvertFormula()
                    {
                        Formula = "a+273",
                        FormulaType = FormulaType.ConvertFromMain,
                        UnitId = 2
                    }
                },
                Id = 2,
                Name = "kelvin",
                NameFa = "کلوین",
                ParentRef = 1,
                Simbol = "K",
                Type = new UnitType()
                {
                    Id = 1,
                    NameFa = "اندازه گیری دما"
                },
                RelationType = RelationUnitTypes.FormulateUnit
            };

            Unit toUnit = new Unit()
            {
                ConvertFormulas = new List<ConvertFormula>()
                {
                    new ConvertFormula()
                    {
                        Formula = "(a-32)*5/9",
                        FormulaType = FormulaType.convertToMain,
                        UnitId = 3
                    },
                    new ConvertFormula()
                    {
                        Formula = "a*9/5+32",
                        FormulaType = FormulaType.ConvertFromMain,
                        UnitId = 3
                    }
                },
                Id = 3,
                Name = "Farenheit",
                NameFa = "فارنتهایت",
                ParentRef = 1,
                Simbol = "f",
                Type = new UnitType()
                {
                    Id = 1,
                    NameFa = "اندازه گیری دما"
                },
                RelationType = RelationUnitTypes.FormulateUnit
            };


            var convertedVal = _UnitService.ConvertUnits(fromUnit, toUnit, 274);
            Assert.Equal<double>(33.8, convertedVal);
        }

    }
}
