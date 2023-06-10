using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChange : MonoBehaviour
{
    [SerializeField] private GameObject canvasToHide;
    [SerializeField] private GameObject canvasToShow;
    public void SettingsOn()
    {
        canvasToHide.SetActive(false);
        canvasToShow.SetActive(true);
    }
    public void SettingsOff()
    {
        canvasToShow.SetActive(false);
        canvasToHide.SetActive(true);
    }
}
