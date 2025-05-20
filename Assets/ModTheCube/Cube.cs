using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float rotationSpeed = 10.0f;
    private float materialAlpha;
    private float materialRed;
    private float materialGreen;
    private float materialBlue;
    
    void Start()
    {
        transform.position = new Vector3(0, 0, 2);
        transform.localScale = Vector3.one * 1.3f;
        
    }
    
    void Update()
    {
        materialAlpha = Random.Range(0.0f, 1.0f);
        materialRed = Random.Range(0.0f, 1.0f);
        materialGreen = Random.Range(0.0f, 1.0f);
        materialBlue = Random.Range(0.0f, 1.0f);

        Material material = Renderer.material;
        
        material.color = new Color(materialRed, materialGreen, materialBlue, materialAlpha);
        transform.Rotate( 0.0f, rotationSpeed * Time.deltaTime, 0.0f, Space.Self);
    }
}
