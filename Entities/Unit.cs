using Common;
using Common.Enums;
using Entities.Base;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entities
{
    public class Unit : BaseClass
    {

        public string NameFa { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\_]+$", ErrorMessage = "فقط حروف انگلیسی و عدد قابل قبول می باشد")]
        public string Simbol { get; set; }
        public UnitType Type { get; set; }
        public RelationUnitTypes RelationType { get; set; }
        public int? ParentRef { get; set; }

        public List<ConvertFormula> ConvertFormulas { get; set; }
        
    }

    public class ConvertFormula
    {
        public FormulaType FormulaType { get; set; }
        public int UnitId { get; set; }
        public string Formula { get; set; }
        

        public virtual Unit Unit { get; set; }

        public void ValidateFormula(string formula)
        {

            if (formula.Where(a => a == '(').Count() != formula.Where(a => a == ')').Count())
                throw new CustomException(ExceptionType.BadArgs, "تعداد پرانتزها با یکدیگر هماهنگ نمی باشند.");

            var main = (".+-*/0123456789()aA").ToList();

            StringBuilder invalidChars = new StringBuilder();
            foreach (var item in formula)
            {
                if (main.Contains(item))
                    continue;

                invalidChars.Append(item);
            }
            if (invalidChars.ToString().Length > 0)
            {
                throw new CustomException(ExceptionType.BadArgs, $"کاراکترهای {invalidChars} در فرمول غیر مجاز می باشند.");
            }

        }
    }
}
