using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CarVisit;

public class UnitTests
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestSelectionVoiture()
    {
        SceneManager.LoadScene(0);
        yield return null;

        yield return new WaitForSeconds(0.5f);
        CarSelectorRenderer carSelector = GameObject.FindObjectOfType<CarSelectorRenderer>();
        EmplacementController emplacement = GameObject.FindObjectOfType<EmplacementController>();

        carSelector.GetScrollView().content.GetComponentInChildren<Button>().onClick.Invoke();
        yield return null;

        Assert.NotNull(emplacement.GetDisplayedCar());
    }

    [UnityTest]
    public IEnumerator TestSelectionCouleur()
    {
        SceneManager.LoadScene(0);
        yield return null;

        yield return new WaitForSeconds(0.5f);
        CarSelectorRenderer carSelector = GameObject.FindObjectOfType<CarSelectorRenderer>();
        EmplacementController emplacement = GameObject.FindObjectOfType<EmplacementController>();

        carSelector.GetScrollView().content.GetComponentInChildren<Button>().onClick.Invoke();
        yield return new WaitForSeconds(0.5f);

        Button colorPickingButton = carSelector.GetColourSchemePicker().GetScrollView().content.GetComponentInChildren<Button>();
        Color buttonColor = colorPickingButton.image.color;
        colorPickingButton.onClick.Invoke();
        yield return null;

        Assert.AreEqual(emplacement.GetCurrentCarRenderer().GetMeshOneColor(), buttonColor);
    }
}
