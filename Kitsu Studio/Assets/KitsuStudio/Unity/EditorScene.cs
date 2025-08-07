using System;
using UnityEngine;

namespace KitsuStudio.Unity
{
    public class EditorScene : MonoBehaviour
    {
        public Texture2D defaultTexture;

        public static EditorScene instance;

        public Material decalMaterial;
        public Material defaultMaterial;
        
        [SerializeField] private GameObject dataModel; // Basically the Rbxl root

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            RBXL.XMLParser.ParseFile(SelectedPlaceStorage.filePath, dataModel);
        }
        
    }
}