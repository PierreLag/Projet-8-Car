using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmplacementController : MonoBehaviour
{
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

        displayedCar = Instantiate(car.modelPrefab);

        CarRenderer carRenderer = displayedCar.GetComponent<CarRenderer>();
        carRenderer.SetIsRotating(true);
        carRenderer.SetRotationSpeed(5f);
    }
}
