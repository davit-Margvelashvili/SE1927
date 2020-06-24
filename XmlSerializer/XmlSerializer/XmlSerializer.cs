using System.Collections;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace XmlSerializer
{
    public static class XmlSerializer
    {
        public static XElement Serialize(object obj)
        {
            if (obj is null)
                return null;

            var type = obj.GetType();
            var properties = type.GetProperties().Where(p => CustomAttributeExtensions.GetCustomAttribute<XmlPropertyAttribute>((MemberInfo) p) != null);

            if (obj is IEnumerable enumerable && !(obj is string))
            {
                return FromEnumerable(enumerable);
            }

            XElement element = new XElement(type.Name);
            foreach (var property in properties)
            {
                element.Add(property.PropertyType.GetCustomAttribute<XmlObjectAttribute>() != null
                    ? Serialize(property.GetValue(obj))
                    : FromSimpleObject(property, obj));
            }

            return element;
        }

        private static XElement FromEnumerable(IEnumerable enumerable)
        {
            var first = enumerable.FirstOrDefault();
            var elementName = $"{first.GetType().Name}s";

            XElement resultElement = new XElement(elementName);
            foreach (var element in enumerable)
            {
                resultElement.Add(Serialize(element));
            }

            return resultElement;
        }

        public static XElement FromSimpleObject(PropertyInfo propertyInfo, object obj)
        {
            return new XElement(propertyInfo.Name, propertyInfo.GetValue(obj));
        }

        private static object FirstOrDefault(this IEnumerable source)
        {
            var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : default;
        }
    }
}