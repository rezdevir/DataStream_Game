using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LinePrefabsManager : MonoBehaviour
{

    public List<Vector3> points;

    [ColorUsage(true,true)] public Color color;

    // [SerializeField] private GameObject OnEndshapePrefabs;
    public float width = 0.2f;
    LineRenderer lineRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;





    }

    
    // Update is called once per frame
    void Update()
    {
        // UpdateLine();
    }

    bool Flag_First = true;
    public void UpdateLine()
    {
        Vector3[] positions = points.ToArray();

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
        // foreach (var p in points)
        // {
        //     lineRenderer.SetPositions(positions);
        // }
    }

    public void AddPositions(Vector2 position)
    {

        points.Add(position);
        Vector3[] positions = points.ToArray();
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);

        if (Flag_First)
            lineRenderer.enabled = true;
        Flag_First = false;
    }
    
       public void AddPosition(Vector2 position)
    {

        points.Add(position);
        // Vector3[] positions = points.ToArray();
        int last_count = lineRenderer.positionCount;
        lineRenderer.positionCount = last_count+1;
        lineRenderer.SetPosition(last_count,position);

        if (Flag_First)
            lineRenderer.enabled = true;
        Flag_First = false;
    }

    public void AddPosition_Updata(Vector2 position)
    {
        
        AddPosition(position);
        UpdateLine();
    }

    public void PressDragLine(Vector2 position)
    {
  
        lineRenderer.positionCount = points.Count+ 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
        

    }
    
       public void ReleaseDragLine(Vector2 position)
    {
        lineRenderer.positionCount = lineRenderer.positionCount - 1;
        AddPosition_Updata(position);
        // lineRenderer.SetPosition(lineRenderer.positionCount-1,position);
    }
}
