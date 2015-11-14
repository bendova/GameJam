using System;
using GameJam;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
    public class UiManager : Singleton<UiManager>
    {
        public Text m_DialogText;
        public Text m_RememeberText;
        public Text m_ActionText;
        public Text[] m_ChoiceTexts;
        public GameObject m_GameOverArea;
        public Text m_GameOverText;

        void Start()
        {
            ResetDialog();
        }

        void Update()
        {

        }

        public void ShowDialog(Dialog dialog)
        {
            ResetDialog();

            if(dialog)
            { 
                m_DialogText.text = dialog.m_DialogText;
                //m_ActionText.text = dialog.m_ActionText;
                //m_RememeberText.text = dialog.m_RemeberText;
                if (m_ChoiceTexts.Length >= dialog.m_Choices.Length)
                {
                    int i = 0;
                    for (int optionIndex = 0; i < dialog.m_Choices.Length; ++i)
                    {
                        bool isValid = true;
                        if (dialog.m_Choices[i].m_Condition && (dialog.m_Choices[i].m_Condition is ActionCondition))
                        {
                            isValid = (dialog.m_Choices[i].m_Condition as ActionCondition).IsTrue();
                        }
                        if (isValid)
                        {
                            m_ChoiceTexts[optionIndex].text = (optionIndex + 1) + ". " + dialog.m_Choices[i].m_ChoiceText;
                            ++optionIndex;
                        }
                        else
                        {
                            m_ChoiceTexts[i].text = "";
                        }
                    }
                    for (; i < m_ChoiceTexts.Length; ++i)
                    {
                        m_ChoiceTexts[i].text = "";
                    }
                }
                else
                {
                    Debug.LogWarning("UiManager::ShowDialog() Trying to show too many choices in the dialog window. " +
                                     "The dialog in question is: '" + dialog.m_DialogText + "'");
                }
            }
            else
            {
                Debug.LogWarning("UiManager::ShowDialog() The dialog is null");
            }
        }

        public void ResetDialog()
        {
            m_DialogText.text = "";
            //m_RememeberText.text = "";
            //m_ActionText.text = "";
            for (int i = 0; i < m_ChoiceTexts.Length; ++i)
            {
                m_ChoiceTexts[i].text = "";
            }
        }
    }
}

