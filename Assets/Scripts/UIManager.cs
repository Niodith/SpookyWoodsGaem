using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    void Start()
    {
        UIManager.instance = this;
    } 
    public void showPopupText(string text) { 
    
    }
    public void hidePopupText()
    {

    }
    public void showPopupText(string text, float duration)
    {

    }
}
