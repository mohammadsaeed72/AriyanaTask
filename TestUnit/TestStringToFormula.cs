using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestUnit
{
    public class TestStringToFormula
    {
        private StringToFormula formulaConvertor;
        public TestStringToFormula()
        {
             formulaConvertor = new StringToFormula();
        }

        [Fact]
        public void checkCalculateParenthesisWorks()
        {
            string formula = "1+2*(3-1)";
            var result = formulaConvertor.Eval(formula);

            Assert.Equal<double>(5, result);
        }

        [Fact]
        public void checkCalculateMultipleOverPlus()
        {
            string formula = "1+2*3";
            var result = formulaConvertor.Eval(formula);

            Assert.Equal<double>(7, result);
        }

        [Fact]
        public void checkCalculateWrongParenthesis()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                string formula = "1+2*3)";
                var result = formulaConvertor.Eval(formula);
            });
            

            
        }
    }
}
