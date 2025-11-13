using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LinePrefabsManager : MonoBehaviour
{

    public List<Vector3> points=new List<Vector3>();

    [ColorUsage(true,true)] public Color color;
    public float width = 0.2f;
    LineRenderer lineRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        lineRenderer = GetComponent<LineRenderer>();
        points.Clear();
        lineRenderer.positionCount = 0;
        lineRenderer.enabled = false;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

    }



    bool Flag_First = true;


       public void AddPosition(Vector2 position)
    {

        points.Add(position);
        int last_count = points.Count;
        lineRenderer.positionCount = last_count;
        lineRenderer.SetPosition(last_count-1,position);
        if (Flag_First)
        {
            lineRenderer.enabled = true;
            Flag_First = false;
        }


    }

 

    public void PressDragLine(Vector2 position)
    {
  
        lineRenderer.positionCount = points.Count+ 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
        

    }
    
}
