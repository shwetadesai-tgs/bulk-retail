namespace Order.Core.Helper
{
    public static class EnumResult
    {
        public static string GetStringValue(this Enum value)
        {
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());

            var attribs = fieldInfo.GetCustomAttributes(
            typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 ? attribs[0].Value : string.Empty;
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class StringValueAttribute : Attribute
    {
        public string Value { get; set; }
        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
