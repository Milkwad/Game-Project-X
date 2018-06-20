using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Node : MonoBehaviour {
    public Color HighlightColor;
    private Renderer rend;
    public Color DefaultColor;
    public GameObject Unitprefab;
    private bool built;

    //temp
    public NavMeshSurface surface;
    private NavMeshModifier modifier;
    
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        DefaultColor = rend.material.color;
        modifier = GetComponent<NavMeshModifier>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (!built)
        {
            return;
        }
        if (built)
        {
            surface.BuildNavMesh();
            built = false;
        }
	}

    private void OnMouseDown()
    {
       GameObject Unit = (GameObject)Instantiate(Unitprefab, transform.position + new Vector3(0,0.5f,0), transform.rotation);
        Unit.transform.SetParent(transform);
        modifier.enabled = true;
        built = true;
    }

    private void OnMouseEnter()
    {
        rend.material.color = HighlightColor;
    }

    void OnMouseExit()
    {
        rend.material.color = DefaultColor;
    }
}
