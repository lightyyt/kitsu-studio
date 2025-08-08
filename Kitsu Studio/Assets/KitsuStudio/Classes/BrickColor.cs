using System;
using UnityEngine;
using System.Linq;
using KitsuStudio.RBXL;
using KitsuStudio.Unity;

namespace KitsuStudio.Classes
{
    public class BrickColor
    {
        public int r;
        public int g;
        public int b;
        public BrickColor(string byName)
        {
            var bci = BrickColorList.BrickColors[byName];
            r = bci.colorR;
            g = bci.colorG;
            b = bci.colorB;
        }
        public BrickColor(int byId)
        {
            foreach (var bci in BrickColorList.BrickColors.Values.Where(bci => bci.brickColorId == byId))
            {
                r = bci.colorR;
                g = bci.colorG;
                b = bci.colorB;
            }
        }

        public Color ToColor(float transparency = 0)
        {
            return new Color(r / 255f, g / 255f, b / 255f, transparency);
        }

        public void ApplyToMaterialOf(GameObject go, float transparency)
        {
            Renderer ren = go.GetComponent<Renderer>();
            if (ren == null)
            {
                MessageBox.instance.ShowError("Renderer not found on GameObject: "+go.name);
                return;
            }
            
            if (transparency < 0.001) // Small threshold, just to be safe
            {
                ren.material = EditorScene.instance.defaultMaterial;
            }
            else
            {
                ren.material = EditorScene.instance.transparentMaterial;
            }
            
            ren.material.color = ToColor(transparency);
        }
    }
}