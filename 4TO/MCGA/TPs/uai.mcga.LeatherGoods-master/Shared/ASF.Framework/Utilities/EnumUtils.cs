using System;

namespace ASF.Framework.Utilities
{
    public static class EnumUtils
    {
        public static T ReturnEnumValueFromString<T>(string enumValueAsString)
        {
            T returnVal;
            try
            {
                returnVal = (T)Enum.Parse(typeof(T), enumValueAsString, true);
            }
            catch (ArgumentException)
            {
                returnVal = default(T);
            }
            return returnVal;
        }
    }
}
