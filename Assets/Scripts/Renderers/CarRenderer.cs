using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRenderer : MonoBehaviour
{
    [SerializeField]
    private CarSO carData;
    [SerializeField]
    private MeshRenderer meshToColour1;
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
        meshToColour1.material = colourScheme.baseMaterial;
        meshToColour2.material = colourScheme.secondaryMaterial;
    }
}
