using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KitsuStudio.Unity
{
    public class SelectPlaceButton: MonoBehaviour
    {
        public TMP_Text textBox;
        public Button button;
        public string filePath;

        public void SelectPlaceClicked()
        {
            SelectedPlaceStorage.filePath = filePath;
            SceneManager.LoadScene( (int)Scenes.EDITOR_SCENE );
        }
    }
}