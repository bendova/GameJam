using System;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text m_DialogText;
    public Text m_ChoiceText_01;
    public Text m_ChoiceText_02;
    public Text m_ChoiceText_03;
    public Text m_ChoiceText_04;

    void Start()
    {
	
	}
	
	void Update()
    {
	
	}

    public void SetDialogText(String text)
    {
        m_DialogText.text = text;
    }
}
