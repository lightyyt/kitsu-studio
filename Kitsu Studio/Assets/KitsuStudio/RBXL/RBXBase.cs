using System.Xml.Linq;
using UnityEngine;

namespace KitsuStudio.RBXL
{
    public abstract class RBXBase
    {
        public GameObject obj;
        
        public string Referent; // Basically Roblox's Object IDs
        public abstract string Name { get; set; }
        public abstract bool Archivable { get; set; }

        public abstract GameObject Parse(XElement itemNode, GameObject parent);
    }
}