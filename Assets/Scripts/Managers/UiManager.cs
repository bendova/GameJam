using System;
using GameJam;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
    public class UiManager : Singleton<UiManager>
    {
        [Header("DialogUi")]
        public Text m_DialogText;
        public Text m_RememeberText;
        public Text m_ActionText;
        public Text[] m_ChoiceTexts;

        [Header("GameOverUi")]
        public GameObject m_GameOverArea;
        public Text m_GameOverText;
        
        void Start()
        {
            ResetDialog();
        }
        
        public void ShowDialog(Dialog dialog)
        {
            ResetDialog();

            if(dialog)
            { 
                m_DialogText.text = dialog.m_DialogText;
                //m_ActionText.text = dialog.m_ActionText;
                //m_RememeberText.text = dialog.m_RemeberText;
                int i = 0;
                int optionIndex = 0;
                for (; i < dialog.m_Choices.Length; ++i)
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
                }
                for (; i < m_ChoiceTexts.Length; ++i)
                {
                    m_ChoiceTexts[i].text = "";
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

