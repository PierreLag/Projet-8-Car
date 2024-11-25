using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;

[Serializable]
public class Car : MonoBehaviour
{
    public int id;
    public string model;
    public int horsepower;
    public int gears;

    public static Car FromJSON(string json)
    {
        return JsonUtility.FromJson<Car>(json);
    }

    public static List<Car> ListFromJSON(string json)
    {
        JArray jcars = JArray.Parse(json);
        List<Car> cars = jcars.ToObject<List<Car>>();

        return cars;
    }

    public static CarSO ToScriptableObject(Car car)
    {
        CarSO carSO = new CarSO();

        carSO.id = car.id;
        carSO.model = car.model;
        carSO.horsepower = car.horsepower;
        carSO.gears = car.gears;

        return carSO;
    }

    public override string ToString()
    {
        return model + ", " + horsepower + " chevaux, " + gears + "vitesses. ";
    }
}
