using System.Linq;
using System.Xml.Linq;
using KitsuStudio.Helpers;
using KitsuStudio.RBXL;
using UnityEngine;

namespace KitsuStudio.Classes
{
    public class Workspace : RBXBase
    {
        public override string Name { get; set; } = "Workspace";
        public override bool Archivable { get; set; } = true;
        public RBXRef CurrentCamera { get; set; }
        public double DistributedGameTime { get; set; } = 0;
        public CFrame ModelInPrimary { get; set; }
        
        public RBXRef PrimaryPart { get; set; }
        
        public override GameObject Parse(XElement itemNode, GameObject parent)
        {
            obj = new GameObject();
            ReferenceStore.refs.Add(itemNode.Attribute("referent")?.Value, this);

            var properties = itemNode.Element("Properties");
            //Debug.Log(itemNode.Element("Ref").Value);
            var camRef = XML.getNamed(properties, "Ref", "CurrentCamera");
            CurrentCamera = new RBXRef("CurrentCamera", camRef.Value);
            

            DistributedGameTime = double.Parse(
                XML.getNamed(properties, "double", "DistributedGameTime")?.Value
                );
            
            ModelInPrimary = new CFrame(
                XML.getNamed(properties, "CoordinateFrame", "ModelInPrimary")
                );
            
            var priRef = XML.getNamed(properties, "Ref", "PrimaryPart");
            
            PrimaryPart = new RBXRef("PrimaryPart", priRef.Value);
            return obj;
        }
    }
}