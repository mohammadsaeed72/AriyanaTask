using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Base
{
    public abstract class BaseClass<Tkey>
    {
        public Tkey Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public abstract class BaseClass:BaseClass<int>
    {
    }
}
