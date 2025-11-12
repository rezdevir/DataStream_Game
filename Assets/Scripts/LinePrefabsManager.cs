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
    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();

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
    
    public void AddPosition(Vector2 position)
    {
        points.Add(position);
        Vector3[] positions = points.ToArray();
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}
