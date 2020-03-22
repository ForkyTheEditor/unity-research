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
            StartCoroutine(CreateChildren());

        }

    }

    private IEnumerator CreateChildren()
    {
        yield return new WaitForSeconds(0.5f);
        new GameObject("Fractal Child").AddComponent<Fractal>().InitializeChild(this, Vector3.up);
        yield return new WaitForSeconds(0.5f);
        new GameObject("Fractal Child").AddComponent<Fractal>().InitializeChild(this, Vector3.forward);
        yield return new WaitForSeconds(0.5f);
        new GameObject("Fractal Child").AddComponent<Fractal>().InitializeChild(this, Vector3.right);
        

    }

    private void InitializeChild(Fractal parent, Vector3 direction)
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
        transform.localPosition = direction * childScale;

    }

}
