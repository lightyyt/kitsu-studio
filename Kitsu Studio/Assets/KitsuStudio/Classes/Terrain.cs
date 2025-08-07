using System.Xml.Linq;
using KitsuStudio.Enums;
using KitsuStudio.RBXL;
using UnityEngine;
using Material = KitsuStudio.Enums.Material;

namespace KitsuStudio.Classes
{
    public class Terrain : RBXBase
    {
        public override string Name { get; set; } = "Terrain";
        public override bool Archivable { get; set; } = true;

        public bool Anchored = true;
        public float BackParamA = -0.5f;
        public float BackParamB = 0.5f;
        public Surface BackSurface;
        public SurfaceInput BackSurfaceInput;
        public float BottomParamA = -0.5f;
        public float BottomParamB = 0.5f;
        public Surface BottomSurface = Surface.Inlet;
        public SurfaceInput BottomSurfaceInput;
        public int brickColor = 194;
        public CFrame CFrame;
        public bool CanCollide = true;
        public string ClusterGridV2;
        public float Elasticity = 0.5f;
        public float FrontParamA = -0.5f;
        public float FrontParamB = 0.5f;
        public Surface FrontSurface = Surface.Smooth;
        public SurfaceInput FrontSurfaceInput;
        public float LeftParamA = -0.5f;
        public float LeftParamB = 0.5f;
        public Surface LeftSurface = Surface.Smooth;
        public SurfaceInput LeftSurfaceInput;
        public bool Locked = true;
        public Material Material = Material.Plastic;
        public float Reflectance = 0;
        public float RightParamA = -0.5f;
        public float RightParamB = 0.5f;
        public Surface RightSurface = Surface.Smooth;
        public SurfaceInput RightSurfaceInput;
        public Vector3 RotVelocity;
        public float TopParamA = -0.5f;
        public float TopParamB = 0.5f;
        public Surface TopSurface = Surface.Studs;
        public SurfaceInput TopSurfaceInput;
        public float Transparency = 0;
        public Vector3 Velocity;
        public Vector3 size;
        
        public override GameObject Parse(XElement itemNode, GameObject parent)
        {
            return null;
        }
    }
}