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
}
