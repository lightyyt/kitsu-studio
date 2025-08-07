using System.Globalization;
using System.Linq;
using UnityEngine;
using System.Xml.Linq;
using KitsuStudio.Classes;

namespace KitsuStudio.Helpers
{
    public static class XML
    {
        /// <summary>
        /// Get an XML element by its name attribute
        /// </summary>
        /// <param name="root">Root XML Element</param>
        /// <param name="typeName">Type Name, e.g. <Ref></Ref></param>
        /// <param name="nameAttrib">Data inside name="***"</param>
        /// <returns></returns>
        public static XElement getNamed(XElement root, XName typeName, string nameAttrib)
        {
            return root.Elements(typeName).FirstOrDefault(
                e => e.Attribute("name")?.Value == nameAttrib
            );
        }

        public static Vector3 ToVector3(XElement element)
        {
            return new Vector3(
                float.Parse(element.Element("X")?.Value, CultureInfo.InvariantCulture),
                float.Parse(element.Element("Y")?.Value, CultureInfo.InvariantCulture),
                float.Parse(element.Element("Z")?.Value, CultureInfo.InvariantCulture)
                );
        }
    }
}