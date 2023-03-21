using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingsman20.ClassHelper
{
    internal class EF
    {
        public static DataBase.Entities Context { get; } = new DataBase.Entities();
    }
}
