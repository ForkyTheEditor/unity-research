using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFunctions : MonoBehaviour
{
    const float pi = Mathf.PI;


    public static Vector3 Sin2DFunction(float u, float v, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (u + t)) + Mathf.Sin(Mathf.PI * (v + t));
        y *= 0.5f;
        Vector3 returnVec = new Vector3(u, y, v);

        return returnVec;

    }

    public static Vector3 SecondPolynomial(float u, float v, float t)
    {
        Vector3 returnVec = Vector3.zero;
        returnVec.x = u;
        returnVec.y = Mathf.Pow(v, 2) + Mathf.Pow(u, 2) + ( Mathf.Sin(u+t) * 0.25f);
        returnVec.z = v;

        return returnVec;

    }

    public static Vector3 WavyCylinder(float u, float v, float t)
    {

        Vector3 returnVec;
        float radius = 1f + Mathf.Sin(2f * pi * v + t) * 0.25f;

        returnVec.x = radius * Mathf.Sin(pi * u);
        returnVec.y = v;
        returnVec.z = radius * Mathf.Cos(pi * u);



        return returnVec;
    }
}
