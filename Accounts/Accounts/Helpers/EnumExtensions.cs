using System;

namespace CashFlowManager.Helpers
{
    public static class EnumExtensions
    {
        public static string Name(this Enum value)
        {
            return Enum.GetName(value.GetType(), value);
        }
    }
}