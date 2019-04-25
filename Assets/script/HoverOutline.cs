using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOutline : MonoBehaviour {
    public Shader shader;
    public float width = 0.02f;
    public Color color;
    Shader beginShader;
	// Use this for initialization
	void Start () {
        beginShader = GetComponentInChildren<MeshRenderer>().material.shader;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseOver()
    {

        GetComponentInChildren<MeshRenderer>().material.shader = shader;
        GetComponentInChildren<MeshRenderer>().material.SetFloat("_OutlineWidth", width);
        GetComponentInChildren<MeshRenderer>().material.SetColor("_OutlineColor", color);
    }
    private void OnMouseExit()
    {
        GetComponentInChildren<MeshRenderer>().material.shader = beginShader;
    }
}
