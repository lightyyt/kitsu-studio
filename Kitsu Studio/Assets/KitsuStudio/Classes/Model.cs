using System.Linq;
using System.Xml.Linq;
using KitsuStudio.Helpers;
using KitsuStudio.RBXL;
using UnityEngine;

namespace KitsuStudio.Classes
{
    public class Model : RBXBase
    {
        public override string Name { get; set; } = "Model";
        public override bool Archivable { get; set; } = true;
        public int Controller = 0;
        public bool ControllerFlagShown = true;
        public CFrame ModelInPrimary;
        public RBXRef PrimaryPart;
        public override GameObject Parse(XElement itemNode, GameObject parent)
        {
            obj = new GameObject();
            ReferenceStore.refs.Add(itemNode.Attribute("referent")?.Value, this);

            var properties = itemNode.Element("Properties");
            
            Name = XML.getNamed(properties, "string", "Name")?.Value;
            
            
            ModelInPrimary = new CFrame(
                XML.getNamed(properties, "CoordinateFrame", "ModelInPrimary")
            );
            var priRef = XML.getNamed(properties, "Ref", "PrimaryPart");
            
            PrimaryPart = new RBXRef("PrimaryPart", priRef.Value);
            return obj;
        }
    }
}