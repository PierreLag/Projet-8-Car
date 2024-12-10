using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CarVisit
{
    public class EmplacementController : MonoBehaviour
    {
        [SerializeField]
        private float carsRotationSpeed;

        [SerializeField]
        private TextMeshProUGUI modelText;
        [SerializeField]
        private TextMeshProUGUI horsepowerText;
        [SerializeField]
        private TextMeshProUGUI gearsText;

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

            modelText.text = "Modèle : " + car.model;
            horsepowerText.text = "Chevaux : " + car.horsepower;
            gearsText.text = "Vitesses : " + car.gears;
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

        public GameObject GetDisplayedCar()
        {
            return displayedCar;
        }
    }
}