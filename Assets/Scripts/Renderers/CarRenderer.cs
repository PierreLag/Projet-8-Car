using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRenderer : MonoBehaviour
{
    [SerializeField]
    private CarSO carData;
    [SerializeField]
    private MeshRenderer[] meshesToColour1;
    [SerializeField]
    private MeshRenderer meshToColour2;

    [SerializeField]
    private bool isRotating;
    [SerializeField]
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    public void ChangeColourScheme(ColourSchemeSO colourScheme)
    {
        foreach(MeshRenderer mesh in meshesToColour1)
            mesh.material = colourScheme.baseMaterial;

        meshToColour2.material = colourScheme.secondaryMaterial;
    }

    public void SetIsRotating(bool isRotating)
    {
        this.isRotating = isRotating;
    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
}
