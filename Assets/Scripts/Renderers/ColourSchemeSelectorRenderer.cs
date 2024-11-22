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

    [SerializeField]
    private float marginAroundButtons;
    [SerializeField]
    private float spaceBetweenButtons;

    private CarRenderer currentCar;
    private List<Button> displayedButtons;

    // Start is called before the first frame update
    void Start()
    {
        displayedButtons = new List<Button>();
    }

    public void LoadCarColourSchemes(CarSO car, CarRenderer renderer)
    {
        foreach(Button button in displayedButtons)
        {
            GameObject.Destroy(button.gameObject);
        }
        displayedButtons.Clear();

        scrollView.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
            2 * marginAroundButtons + car.colourSchemeList.Length * (spaceBetweenButtons + ((RectTransform)colourSchemeButtonTemplate.transform).sizeDelta.x)); // Total size that'll be alloted to the contents.

        currentCar = renderer;
        int currentCS = 0;

        foreach(ColourSchemeSO colourScheme in car.colourSchemeList)
        {
            Button currentButton = Instantiate(colourSchemeButtonTemplate, scrollView.content);

            currentButton.onClick.AddListener(() => currentCar.ChangeColourScheme(colourScheme));
            currentButton.GetComponent<Image>().color = colourScheme.baseMaterial.color;
            ((RectTransform)currentButton.transform).localPosition = new Vector3(marginAroundButtons + currentCS * (((RectTransform)currentButton.transform).sizeDelta.x + spaceBetweenButtons), -(scrollView.content.sizeDelta.y /2), currentButton.transform.position.z);

            displayedButtons.Add(currentButton);
            currentCS++;
        }
    }
}
