using UnityEngine;



public class GameSettings : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] int fps_target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps_target;
        Cursor.visible = false;
        Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
    }
    
    

}
