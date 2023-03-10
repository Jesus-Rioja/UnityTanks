using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CactusDisplayerScript : MonoBehaviour
{
    TMP_Text CactusDisplay;

    private void Awake()
    {
        CactusDisplay = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        GameManager.Instance.GetComponent<SingleGamemode>().OnCactusDestroyed.AddListener(DisplayDestroyedCactus);
        DisplayDestroyedCactus(0);
    }

    void DisplayDestroyedCactus(int CactusDestroyed)
    {
        CactusDisplay.text = "" + CactusDestroyed;
    }
}
