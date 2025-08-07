using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KitsuStudio.Unity
{
    public class SelectorScreen : MonoBehaviour
    {
        [SerializeField] private SelectPlaceButton baseButton;
        [SerializeField] private Transform placeSelectParent;
        private void Start()
        {
            //Get all places
            string dataFolder = Path.Combine(Application.persistentDataPath, "Places");
            if (!Directory.Exists(dataFolder))
            {
                MessageBox.instance.ShowWarning("Place Folder was not found!\nCreating place folder at:\n"+dataFolder);
                Directory.CreateDirectory(dataFolder);
            }
            foreach(var filePath in Directory.GetFiles(dataFolder))
            {
                string fileName = Path.GetFileName(filePath);
                CreatePlaceButton(fileName, filePath);
            }
            //MessageBox.instance.ShowMessage("This is a sample text to make sure everything works accordingly");
        }

        public void CreatePlaceButton(string placeFileName, string placeFilePath)
        {
            var placeName = placeFileName.Substring(0, placeFileName.Length - 5);

            var newButton = Instantiate(baseButton);
            //var text = newButton.GetComponentInChildren<TMP_Text>();
            newButton.textBox.text = placeName;
            newButton.button.transform.parent = placeSelectParent;
            newButton.button.transform.localScale = Vector3.one;
            newButton.filePath = placeFilePath;
            newButton.gameObject.SetActive(true);
        }
    }
}