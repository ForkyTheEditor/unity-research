using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    const float pi = Mathf.PI;


    public Transform pointPrefab;
    [Range(10, 200)]

    public int resolution;
    Transform[] points;

    public GraphFunctionName selectedFunction;

    static GraphFunction[] functions = { Sin2DFunction, SecondPolynomial, WavyCylinder };

  

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

    public static Vector3 Sin2DFunction(float x, float z, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t)) + Mathf.Sin(Mathf.PI * (z + t));
        y *= 0.5f;
        Vector3 returnVec = new Vector3(x, y, z);

        return returnVec;

    }

    public static Vector3 SecondPolynomial(float x, float z, float t)
    {

        float y = Mathf.Pow(x, 2);
        Vector3 returnVec = new Vector3(x, y, z);

        return returnVec;

    }

    public static Vector3 WavyCylinder(float x, float z, float t)
    {
        
        Vector3 returnVec;
        float radius = 1f + Mathf.Sin(2f * pi * z +t) * 0.25f;

        returnVec.x = radius * Mathf.Sin(pi * x);
        returnVec.y = z;
        returnVec.z = radius * Mathf.Cos(pi * x);



        return returnVec;
    }
}
