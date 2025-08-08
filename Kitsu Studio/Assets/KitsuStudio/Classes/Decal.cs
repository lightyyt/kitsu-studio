using System.Xml.Linq;
using KitsuStudio.Enums;
using KitsuStudio.Helpers;
using KitsuStudio.RBXL;
using KitsuStudio.Unity;
using UnityEngine;

namespace KitsuStudio.Classes
{
    public class Decal : RBXBase
    {
        public override string Name { get; set; } = "Decal";
        public override bool Archivable { get; set; } = true;
        public Face Face = Face.TOP;
        public float Shiny = 20;
        public float Specular = 0;
        public string Texture;
        public float Transparency = 0;
        public override GameObject Parse(XElement itemNode, GameObject parent)
        {
            ReferenceStore.refs.Add(itemNode.Attribute("referent")?.Value, this);
            
            var properties = itemNode.Element("Properties");
            obj = GameObject.CreatePrimitive(PrimitiveType.Quad);

            var faceTkn = int.Parse(XML.getNamed(properties, "token", "Face")?.Value);
            Face = (Face)faceTkn;

            Shiny = float.Parse(XML.getNamed(properties, "float", "Shiny")?.Value);
            Specular = float.Parse(XML.getNamed(properties, "float", "Specular")?.Value);
            Texture = XML.getNamed(properties, "Content", "Texture")?.Value;
            Transparency = float.Parse(XML.getNamed(properties, "float", "Transparency")?.Value);
            
            // SET DECAL TEXTURE

            var newTex = GameHelpers.LoadTextureFromPNG(
                GameHelpers.PathHandler(
                    XML.getNamed(properties, "Content", "Texture")
                )
            );
            
            //Fallback texture if Texture is null
            SetTex(obj.GetComponent<Renderer>(), newTex ?? EditorScene.instance.defaultTexture);
            
            
            // SET DECAL POSITION
            obj.transform.localPosition = DecalPositions.getFromFace(Face);
            obj.transform.eulerAngles = DecalRotations.getFromFace(Face);
            // Always Force Scale to Vector3.one
            obj.transform.localScale = Vector3.one;
            //Debug.Log(obj.transform.lossyScale);

            return obj;
        }
        
        private void SetTex(Renderer targetRenderer, Texture2D decalTexture)
        {
            if (targetRenderer != null && decalTexture != null)
            {
                
                // Clone the material so we don't affect shared material
                UnityEngine.Material mat = GameObject.Instantiate(EditorScene.instance.decalMaterial);

                targetRenderer.material = mat;

                // Set the texture
                mat.mainTexture = decalTexture;

                // Optional: change shader settings if needed
                mat.SetFloat("_Surface", 1); // 0 = Opaque, 1 = Transparent
                mat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");

                // Optional: enable alpha blending
                mat.SetFloat("_AlphaClip", 0); // Use 1 if you want hard cut-off
            }
            else
            {
                Debug.LogWarning("Renderer or decalTexture not set!");
            }
        }
    }
}