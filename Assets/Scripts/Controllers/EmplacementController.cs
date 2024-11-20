using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmplacementController : MonoBehaviour
{
    [SerializeField]
    private float carsRotationSpeed;

    private GameObject displayedCar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayNewCar(CarSO car)
    {
        if (displayedCar != null)
        {
            Destroy(displayedCar);
        }

        displayedCar = Instantiate(car.modelPrefab, transform);

        CarRenderer carRenderer = displayedCar.GetComponent<CarRenderer>();
        carRenderer.SetIsRotating(true);
        carRenderer.SetRotationSpeed(carsRotationSpeed);
    }

    public void StopCarRotation()
    {
        if (displayedCar != null)
        {
            CarRenderer carRenderer = displayedCar.GetComponent<CarRenderer>();
            carRenderer.SetIsRotating(false);
        }
    }

    public void StartCarRotation()
    {
        if (displayedCar != null)
        {
            CarRenderer carRenderer = displayedCar.GetComponent<CarRenderer>();
            carRenderer.SetIsRotating(true);
        }
    }

    public CarRenderer GetCurrentCarRenderer()
    {
        return displayedCar.GetComponent<CarRenderer>();
    }
}
