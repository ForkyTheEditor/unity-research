using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public enum GraphFunctionName { Sin2D, SecondPolynomial, WavyCylinder }

    public Transform pointPrefab;

    [Range(10, 100)]
    public int resolution;
     
    Transform[] points;

    public GraphFunctionName selectedFunction;

    static GraphFunction[] functions = { DefaultFunctions.Sin2DFunction, DefaultFunctions.SecondPolynomial, DefaultFunctions.WavyCylinder };

  
    private void Awake()
    {
        //Generate points 
        Vector3 pointPosition = Vector3.zero;
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;

        points = new Transform[resolution * resolution];

        for (int i = 0; i < points.Length; i++)
        {
            
            Transform point = Instantiate(pointPrefab);

            point.localPosition = pointPosition;
            point.localScale = scale;

            point.SetParent(this.transform);
            points[i] = point;
  

        }

    }

    private void Update()
    {
        GraphFunction fn = functions[(int)selectedFunction];
        float t = Time.time;
        float step = 2f / resolution;

        for (int i = 0, z = 0; z < resolution; z++)
        {
            float v = (z + 0.5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++)
            {
                float u = (x + 0.5f) * step - 1f;
                points[i].localPosition = fn(u, v, t);

            }

        }

    }

    
}
