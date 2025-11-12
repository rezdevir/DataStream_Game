using UnityEngine;

public class DrawLineHandler : MonoBehaviour
{
    [SerializeField] float Distance_Sample=3f;
    InputHandler input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = InputHandler.Instance;
        input.OnClickHandler += ClickHandler;
    }


    void ClickHandler(PressData data)
    {
        if (data.IsPressed)
        {
            OnStartLine();
        }
        else
        {
            OnEndLine();
        }
    }
    void OnStartLine()
    {

    }
    void OnEndLine()
    {
        
    }

    void DrawLine()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
