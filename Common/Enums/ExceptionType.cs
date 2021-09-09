using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum ExceptionType
    {
        [Display(Name = "خطای ناشناس رخ داده است")]
        UnknownError =0,
        [Display(Name ="خطایی در سطح سرور رخ داده است")]
        ServerError=1,
        [Display(Name = "ورودی های تابع دارای خطا می باشد")]
        BadArgs =2,
        [Display(Name = "مقدار درخواست شده یافت نشد")]
        NotFound =3,
        [Display(Name = "خطای منطقی در سیستم رخ داده است")]
        LogicError =4
    }
}
