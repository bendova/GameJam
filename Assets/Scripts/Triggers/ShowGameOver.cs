using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace GameJam
{
    public class ShowGameOver : MonoBehaviour, ActionTrigger
    {
        [TextArea(3, 10)]
        public string m_GameOverMessage = "";

        private bool m_ShowGameOver = false;

        // Use this for initialization
        void Start()
        {

        }

        void FixedUpdate()
        {
            if (m_ShowGameOver)
            {
                if (CrossPlatformInputManager.GetButton("Restart"))
                {
                    Application.LoadLevel(ChangeLevelOnInteract.s_LevelsMap[Levels.Level_WhiteRoom]);
                    UiManager.Instance.m_GameOverArea.SetActive(false);
                }
            }
        }

        public void Trigger()
        {
            if (m_ShowGameOver == false)
            {
                m_ShowGameOver = true;
                UiManager.Instance.m_GameOverArea.SetActive(true);
                UiManager.Instance.m_GameOverText.text = "Game Over!\n" + m_GameOverMessage;
            }
        }
    }
}


