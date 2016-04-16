using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowManager.Helpers {
    public static class EnumExtensions {
        public static string Name(this Enum value)
        {
            return Enum.GetName(value.GetType(), value);
        }
    }
}
