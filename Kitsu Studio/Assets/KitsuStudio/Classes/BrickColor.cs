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

        public Color ToColor()
        {
            return new Color(r / 255f, g / 255f, b / 255f);
        }

        public void ApplyToMaterialOf(GameObject go)
        {
            Renderer ren = go.GetComponent<Renderer>();
            if (ren == null)
            {
                MessageBox.instance.ShowError("Renderer not found on GameObject: "+go.name);
                return;
            }

            ren.material = EditorScene.instance.defaultMaterial;
            ren.material.color = ToColor();
        }
    }
}