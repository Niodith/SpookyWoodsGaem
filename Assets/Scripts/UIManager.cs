using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public RectTransform staminaBar;
    public float maxStaminaBarWidthPercent = 0.75f;
    public float maxStaminaBarHeightPixels = 20;
    private float _maxStaminaPixelWidth = 500;
    IEnumerator Start()
    {
        UIManager.instance = this;
        yield return new WaitForEndOfFrame();
        _maxStaminaPixelWidth = maxStaminaBarWidthPercent * FPSController.instance.playerCamera.pixelWidth;
        updateStamina(1);
    }
     
    public void showPopupText(string text) { 
    
    }
    public void hidePopupText()
    {

    }
    public void showPopupText(string text, float duration)
    {

    }
    public void updateStamina(float staminaPercent)
    {
        staminaBar.sizeDelta = new Vector2(staminaPercent * _maxStaminaPixelWidth, maxStaminaBarHeightPixels); //scale the staminabar to the % of the max pixel width, which was computed based on screen width and tunable in Start()
    }
}
