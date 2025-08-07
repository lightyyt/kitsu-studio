using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace KitsuStudio.Helpers
{
    public class GameHelpers
    {
        public static void SetGlobalScale(Transform transform, Vector3 targetGlobalScale)
        {
            // Calculate the required local scale by undoing the parent’s scale
            var parent = transform.parent;

            if (parent == null)
            {
                // No parent = local scale is global scale
                transform.localScale = targetGlobalScale;
            }
            else
            {
                // Divide target scale by parent's lossy scale to get correct local scale
                Vector3 parentScale = parent.lossyScale;
                transform.localScale = new Vector3(
                    targetGlobalScale.x / parentScale.x,
                    targetGlobalScale.y / parentScale.y,
                    targetGlobalScale.z / parentScale.z
                );
            }
        }
        
        /// <summary>
        /// Loads a PNG texture from a given relative subdirectory inside persistent data path.
        /// </summary>
        /// <param name="fullPath">File path</param>
        /// <returns>Loaded Texture2D or null if failed</returns>
        public static Texture2D LoadTextureFromPNG(string fullPath)
        {

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning($"File not found at path: {fullPath}");
                return null;
            }

            try
            {
                byte[] fileData = File.ReadAllBytes(fullPath);
                Texture2D tex = new Texture2D(2, 2, TextureFormat.RGBA32, false);

                if (tex.LoadImage(fileData)) // Loads and auto-resizes texture
                {
                    return tex;
                }
                else
                {
                    Debug.LogWarning("Failed to load image data from PNG bytes.");
                    return null;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Exception while loading texture: {e}");
                return null;
            }
        }

        public static string PathHandler(XElement path)
        {
            if(path.Element("url")!=null)
            {
                var content = path.Element("url")?.Value;
                if (content.StartsWith("rbxasset://"))
                {
                    var assetpath = content.Substring("rbxasset://".Length);
                    return Path.Combine(Application.persistentDataPath, "Roblox Content", assetpath);
                }
            }

            return null;
        }
        
    }
}