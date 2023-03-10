using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnEnableSetSelected : MonoBehaviour
{
    [SerializeField] GameObject FirstSelectedSettings;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstSelectedSettings);
    }
}
