using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

namespace CarVisit
{
    public class CarSelectorRenderer : MonoBehaviour
    {
        [SerializeField]
        private Button carButtonTemplate;
        [SerializeField]
        private TextMeshProUGUI noInternetTMP;
        [SerializeField]
        private TextMeshProUGUI serverInaccessibleTMP;
        [SerializeField]
        private CatalogueSO listCars;
        [SerializeField]
        private ScrollRect scrollView;
        [SerializeField]
        private EmplacementController carEmplacement;
        [SerializeField]
        private ColourSchemeSelectorRenderer colourSchemeRenderer;

        [SerializeField]
        private float marginAroundButtons;
        [SerializeField]
        private float spaceBetweenButtons;

        // Start is called before the first frame update
        async void Start()
        {
            if (APIController.CheckInternetConnection())
            {
                StartCoroutine(APIController.GetAllCars());

                int numberWaiting = 0;
                while (APIController.GetLatestResponse() == null && numberWaiting < 10)
                {
                    await Task.Delay(100);
                    numberWaiting++;
                }

                List<Car> cars = (List<Car>)APIController.GetLatestResponse();
                if (cars == null)
                {
                    Instantiate(serverInaccessibleTMP, scrollView.transform.parent);
                }
                else
                {
                    APIController.ResetLatestResponse();

                    for (int i = 0; i < cars.Count; i++)
                    {
                        listCars.cars[i].UpdateFromRuntime(Car.ToScriptableObject(cars[i]));
                    }

                    Button currentButton;
                    int nbCar = 0;

                    foreach (CarSO car in listCars.cars)
                    {
                        currentButton = Instantiate(carButtonTemplate, scrollView.content);
                        currentButton.onClick.AddListener(() => ChangeCar(car));
                        currentButton.GetComponent<RawImage>().texture = car.carPreviewTexture;
                        ((RectTransform)currentButton.transform).localPosition = new Vector3(marginAroundButtons + nbCar * ((RectTransform)currentButton.transform).sizeDelta.x + spaceBetweenButtons * nbCar, 0, 0);
                        nbCar++;
                    }
                }
            }
            else
            {
                Instantiate(noInternetTMP, scrollView.transform.parent);
            }
        }

        private async void ChangeCar(CarSO car)
        {
            carEmplacement.DisplayNewCar(car);
            await Task.Delay(100);
            colourSchemeRenderer.LoadCarColourSchemes(car, carEmplacement.GetCurrentCarRenderer());
        }

        public ScrollRect GetScrollView()
        {
            return scrollView;
        }

        public ColourSchemeSelectorRenderer GetColourSchemePicker()
        {
            return colourSchemeRenderer;
        }
    }
}