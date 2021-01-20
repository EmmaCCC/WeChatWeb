using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Emma.WeChat.Extensions
{
    public static class XmlExtension
    {
        public static XElement CreateXml(this object o, string name = "xml")
        {
            var xele = new XElement(name ?? o.GetType().Name);
            if (o != null)
            {
                var props = o.GetType().GetProperties();
                foreach (var item in props)
                {
                    var propType = item.PropertyType;
                    if (propType.IsPrimitive || propType == typeof(string))
                    {
                        var value = item.GetValue(o)?.ToString() ?? string.Empty;
                        xele.Add(new XElement(item.Name, new XCData(value)));
                    }
                    else if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        var items = (IEnumerable<object>)item.GetValue(o);
                        if (items != null)
                        {
                            var listEle = new XElement(item.Name);
                            foreach (var obj in items)
                            {
                                listEle.Add(CreateXml(obj, "Item"));
                            }
                            xele.Add(listEle);
                        }
                       
                    }
                    else
                    {
                        xele.Add(CreateXml(item.GetValue(o), item.Name));
                    }
                }

            }
            return xele;
        }
    }
}
