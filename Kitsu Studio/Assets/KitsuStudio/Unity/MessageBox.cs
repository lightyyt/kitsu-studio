using TMPro;
using UnityEngine;

namespace KitsuStudio.Unity
{
    public class MessageBox : MonoBehaviour
    {
        public static MessageBox instance;

        [SerializeField] private TMP_Text titleField;
        [SerializeField] private TMP_Text infoField;
        [SerializeField] private GameObject uiRoot;
        private void Awake()
        {
            //Only allow one instance
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        public void ShowError(string info, string title="KitsuStudio Error")
        {
            titleField.text = title;
            infoField.text = info;
            Show();
        }
        
        public void ShowWarning(string info, string title="KitsuStudio Warning")
        {
            titleField.text = title;
            infoField.text = info;
            Show();
        }
        
        public void ShowMessage(string info, string title="KitsuStudio")
        {
            titleField.text = title;
            infoField.text = info;
            Show();
        }

        public void Close()
        {
            uiRoot.SetActive(false);
        }

        private void Show()
        {
            uiRoot.SetActive(true);
        }
    }
}