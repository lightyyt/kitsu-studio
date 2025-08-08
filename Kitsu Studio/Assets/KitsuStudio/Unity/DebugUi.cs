using KitsuStudio.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugUi : MonoBehaviour
{
    private string Log = "";
    private bool LogEnabled = false;

    private static DebugUi instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Application.logMessageReceived += HandleLog;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Append the message to your log string
        Log += $"[{type}] {logString}\n";

        // Optionally, include stack traces for errors and exceptions
        if (type is LogType.Error or LogType.Exception)
        {
            Log += $"StackTrace:\n{stackTrace}\n";
        }
    }
    
    private void OnGUI()
    {
        var width = Screen.width;
        var height = Screen.height / 2;
        
        if(LogEnabled) GUI.Box(new Rect(10, 10, width-20, height-20), Log);

        if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height - 25, 100, 25), "Toggle Console"))
            LogEnabled ^= true;

        if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height - 50, 100, 25), "Clear Console"))
            Log = "";
        
        if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height - 75, 100, 25), "Go To Menu")) 
            SceneManager.LoadScene((int)Scenes.SELECT_PLACE_SCENE);
    }
}
