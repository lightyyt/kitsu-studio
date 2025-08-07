using System.Xml.Linq;
using KitsuStudio.RBXL;
using UnityEngine;

namespace KitsuStudio.Classes
{
    public class Camera : RBXBase
    {
        public override string Name { get; set; } = "Camera";
        public override bool Archivable { get; set; } = true;
        
        public RBXRef CameraSubject { get; set; }
        public CameraType CameraType;
        public CFrame CoordinateFrame;
        public float FieldOfView;
        public CFrame Focus;
        
        public override GameObject Parse(XElement itemNode, GameObject parent)
        {
            return null;
        }
    }
}