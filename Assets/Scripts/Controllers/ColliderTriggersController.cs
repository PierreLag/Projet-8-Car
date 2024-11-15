using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ColliderTriggersController : MonoBehaviour
{
    [Serializable]
    private class TriggeredEvent : UnityEvent { }

    [SerializeField]
    private TriggeredEvent OnTriggerEnterCustom;
    [SerializeField]
    private TriggeredEvent OnTriggerExitCustom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CharacterController>(out CharacterController controller))
            OnTriggerEnterCustom.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
            OnTriggerExitCustom.Invoke();
    }
}
