using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectorRenderer : MonoBehaviour
{
    [SerializeField]
    private Button carButtonTemplate;
    [SerializeField]
    private CatalogueSO listCars;
    [SerializeField]
    private ScrollRect scrollView;
    [SerializeField]
    private EmplacementController carEmplacement;

    // Start is called before the first frame update
    void Start()
    {
        Button currentButton;

        foreach (CarSO car in listCars.cars)
        {
            currentButton = Instantiate(carButtonTemplate, scrollView.content);
            currentButton.onClick.AddListener( () => ChangeCar(car));
            currentButton.GetComponent<RawImage>().texture = car.carPreviewTexture;
        }
    }

    private void ChangeCar(CarSO car)
    {
        carEmplacement.DisplayNewCar(car);
    }
}
