using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace HelperLayer
{
    public static class XmlHelper
    {
        public static XmlElement CreateRoot(XmlDocument doc, string name)
        {
            XmlElement result = null;

            if (doc != null && !string.IsNullOrEmpty(name))
            {
                result = doc.CreateElement(name);
                doc.AppendChild(result);
            }

            return result;
        }

        public static XmlElement CreateElement(XmlDocument doc, XmlElement parent, string name)
        {
            XmlElement result = null;

            if (doc != null && !string.IsNullOrEmpty(name))
            {
                result = doc.CreateElement(name);

                if (parent != null)
                {
                    parent.AppendChild(result);
                }
            }           

            return result;
        }

        public static XmlAttribute CreateAttribute(XmlDocument doc, XmlElement parent, string name, string value)
        {
            XmlAttribute result = null;

            if (doc != null && !string.IsNullOrEmpty(name))
            {
                result = doc.CreateAttribute(name);
                result.Value = value;

                if (parent != null)
                {
                    parent.Attributes.Append(result);
                }
            }

            return result;
        }

        public static XmlElement ToXmlElement(XmlNode input)
        {
            var temp = new List<XmlNode>();
            temp.Add(input);
            var result = temp.Cast<XmlElement>().ToList()[0];

            return result;
        }

        public static List<XmlElement> GetElements(XmlElement data, string elementName)
        {
            List<XmlElement> result = new List<XmlElement>();

            string xPath = "descendant::" + elementName;
            var temp = data.SelectNodes(xPath);
            if(temp != null) result = temp.Cast<XmlElement>().ToList();

            return result;
        }
    }
}
