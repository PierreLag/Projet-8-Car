using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSchemeSelectorRenderer : MonoBehaviour
{
    [SerializeField]
    private Button colourSchemeButtonTemplate;
    [SerializeField]
    private ScrollRect scrollView;

    private CarRenderer currentCar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadCarColourSchemes(CarSO car)
    {
        currentCar = car.modelPrefab.GetComponent<CarRenderer>();
        int currentCS = 0;

        foreach(ColourSchemeSO colourScheme in car.colourSchemeList)
        {
            Button currentButton = Instantiate(colourSchemeButtonTemplate, scrollView.content);
            currentButton.transform.localPosition = new Vector3();
        }
    }
}
