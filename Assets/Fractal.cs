using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    public float childScale = 0.5f;

    public static int maxDepth = 5;
    private int depth;

    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;

        if(depth <  Fractal.maxDepth)
        {
            new GameObject("Fractal Child").AddComponent<Fractal>().InitializeChild(this);
        }

    }

    private void InitializeChild(Fractal parent)
    {
        //Take all of the relevant attributes from the parent object
        mesh = parent.mesh;
        material = parent.material;
        childScale = parent.childScale;
        //Don't let the stack overflow!
        depth = parent.depth + 1;

        //Make the new child an actual child of the parent
        transform.parent = parent.transform;

        //Resize and do all the modifications to the child
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = Vector3.forward * childScale;

    }

}
