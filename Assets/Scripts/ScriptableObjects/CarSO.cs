using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CarVisit/CarSO")]
public class CarSO : ScriptableObject
{
    public int id;
    public string model;
    public int horsepower;
    public int gears;
    public GameObject modelPrefab;
    public ColourSchemeSO[] colourSchemeList;
    public RenderTexture carPreviewTexture;

    public void UpdateFromRuntime(CarSO runtimeCar)
    {
        id = runtimeCar.id;
        model = runtimeCar.model;
        horsepower = runtimeCar.horsepower;
        gears = runtimeCar.gears;
    }

    public override string ToString()
    {
        return model + ", " + horsepower + " chevaux, " + gears + "vitesses. ";
    }
}
