using System;

namespace Repositorio
{
    public static class EnumParser<T>
    {
        public static T GetEnum(string name)
        {
            return (T)Enum.Parse(typeof(T), name, true);
        }
    }
}