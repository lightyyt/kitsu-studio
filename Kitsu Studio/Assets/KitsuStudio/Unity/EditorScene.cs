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
		public Material transparentMaterial;
        
        [SerializeField] private GameObject dataModel; // Basically the Rbxl root

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            if (SelectedPlaceStorage.filePath == null)
            {
                Debug.LogError("File Path mustn't be null!");
            }
            if (dataModel == null)
            {
                Debug.LogError("DataModel mustn't be null! Wait... How did that even HAPPEN?!?!");
            }
            RBXL.XMLParser.ParseFile(SelectedPlaceStorage.filePath, dataModel);
        }
        
    }
}