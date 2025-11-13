using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class DrawLineHandler : MonoBehaviour
{
    [SerializeField] float Distance_Sample = 3f;

    [SerializeField] GameObject LinePrefab;
    InputHandler input;
    LinePrefabsManager Curren_LineManager;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = InputHandler.Instance;
        StartCoroutine(StartAfterDelay());
    }
    IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        input.OnClickHandler += ClickHandler;
    }

    Vector2 start_point;
    // Vector2 threshold_point;


    GameObject currecnt_line;

    bool IsClick = false;
    void ClickHandler(PressData data)
    {
        if (data.IsPressed)
        {
            OnStartLine( data);
        }
        else
        {
            OnEndLine(data);
        }
    }
    void OnStartLine(PressData data)
    {
        IsClick = true;
        currecnt_line = Instantiate(LinePrefab, transform);
        Curren_LineManager = currecnt_line.GetComponent<LinePrefabsManager>();
        start_point = data.Position;
        
        Curren_LineManager.AddPosition(start_point);
        // At frist asume click point is start point
        
    }
    void OnEndLine(PressData data)
    {
        IsClick = false;
        Curren_LineManager.AddPosition(input.mouse_position);
    }


    void GetSample()
    {
        if (Curren_LineManager && IsClick)
        {

            Curren_LineManager.PressDragLine(input.mouse_position);
            // input.mouse_position
            if (Vector2.Distance(input.mouse_position, start_point) >= Distance_Sample)
            {
                start_point = input.mouse_position;

                Curren_LineManager.AddPosition(start_point);
            }
        }
    }
    

    void DrawLine()
    {

    }


    // Update is called once per frame
    void LateUpdate()
    {
      
        GetSample();
    }
}
