using System;
using System.Collections.Generic;
using UnityEngine;

using System.Xml.Linq;
using KitsuStudio.Classes;
using KitsuStudio.Unity;

namespace KitsuStudio.RBXL
{
    public static class XMLParser
    {
        private static Dictionary<string, Type> RBXClasses = new()
        {
            { "Workspace", typeof(Workspace) },
            { "Part", typeof(Part) },
            { "SpawnLocation", typeof(SpawnLocation) },
            { "Decal", typeof(Decal) }
        };
        
        public static void ParseFile(string fileName, GameObject dataModel)
        {
            var document = XDocument.Load(fileName);
            var items = new List<RBXBase>();

            //foreach (var itemNode in document.Elements("Item"))
            //{
            ParseItemsRecursive(document.Root, dataModel);
            //}
        }

        private static void ParseItemsRecursive(XElement rootNode, GameObject parentObj)
        {
            foreach (var itemNode in rootNode.Elements("Item"))
            {
                var className = itemNode.Attribute("class")?.Value;
                if (!RBXClasses.TryGetValue(className, out var classType))
                {
                    Debug.LogWarning(className + " does not exist in my dumb list");
                    continue;
                }

                if (Activator.CreateInstance(classType) is not RBXBase rbxInstance)
                {
                    Debug.LogWarning("Failed to cast instance of " + className);
                    continue;
                }

                // Parse the current node, passing the parent GameObject
                GameObject currentGameObject = rbxInstance.Parse(itemNode, parentObj);

                if (className != "Decal")
                {
                    try
                    {
                        //currentGameObject.GetComponent<Renderer>().material = EditorScene.instance.defaultMaterial;
                    }
                    catch
                    {
                        Debug.LogWarning("Unable to Set Material for " + currentGameObject.name + " (className: " +
                                         className + ")");
                    }
                }

                //Set the parent and name here, as it should always happen and makes the rest of the code simpler
                currentGameObject.name = rbxInstance.Name;
                //currentGameObject.transform.parent = parentObj.transform;
                //THIS IS JUST TEMPORARY UNTIL EVERY PART SETS THEIR PARENT MANUALLY!
                if(className != "Part") currentGameObject.transform.SetParent(parentObj.transform, worldPositionStays: false);
                // Now recurse on this node's children (Items)
                ParseItemsRecursive(itemNode, currentGameObject);
            }
        }

        
        public static void SaveFile()
        {
            
        }
    }

}