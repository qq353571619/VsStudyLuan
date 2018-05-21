using System;

namespace 特性
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class MyAttribute:Attribute
    {
        public int Index;

        public MyAttribute(int index)
        {
            Index = index;
        }
    }
}
