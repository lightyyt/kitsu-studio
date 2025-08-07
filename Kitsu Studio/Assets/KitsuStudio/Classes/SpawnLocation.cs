using System.Xml.Linq;
using KitsuStudio.Enums;
using KitsuStudio.Helpers;
using KitsuStudio.RBXL;
using UnityEngine;
using Material = KitsuStudio.Enums.Material;

namespace KitsuStudio.Classes
{
    public class SpawnLocation : RBXBase
    {
        //TODO: add missing values
        public override string Name { get; set; } = "SpawnLocation";
        public override bool Archivable { get; set; } = true;

        public bool AllowTeamChangeOnTouch = false;
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
        public int Duration = 10;
        public float Elasticity = 0.5f;
        public float Friction = 0.300000012f;
        public float FrontParamA = -0.5f;
        public float FrontParamB = 0.5f;
        public Surface FrontSurface = Surface.Smooth;
        public SurfaceInput FrontSurfaceInput;
        public float LeftParamA = -0.5f;
        public float LeftParamB = 0.5f;
        public Surface LeftSurface = Surface.Smooth;
        public SurfaceInput LeftSurfaceInput;
        public bool Locked = true;
        public Material Material = Material.Plastic; //Todo: Figure out Material IDs
        public bool Neutral = true;
        public float Reflectance = 0;
        public float RightParamA = -0.5f;
        public float RightParamB = 0.5f;
        public Surface RightSurface = Surface.Smooth;
        public SurfaceInput RightSurfaceInput;
        public Vector3 RotVelocity;
        public int TeamColor = 194;
        public float TopParamA = -0.5f;
        public float TopParamB = 0.5f;
        public Surface TopSurface = Surface.Smooth;
        public SurfaceInput TopSurfaceInput;
        public float Transparency = 0;
        public Vector3 Velocity;
        public FormFactor formFactorRaw = FormFactor.Plate;
        public Shape shape = Shape.Block;
        public Vector3 size;
        
        public override GameObject Parse(XElement itemNode, GameObject parent)
        {
            var properties = itemNode.Element("Properties");
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            CFrame = new CFrame(
                XML.getNamed(properties, "CoordinateFrame", "CFrame")
            );
            CFrame.SetTransform(obj.transform);

            size = XML.ToVector3(
                XML.getNamed(properties, "Vector3", "size")
                );
            obj.transform.localScale = size;

            brickColor = int.Parse(XML.getNamed(properties, "int", "BrickColor")?.Value);
            //Apply brickColor
            var bc = new BrickColor(brickColor);
            bc.ApplyToMaterialOf(obj);
            return obj;
        }
    }
}