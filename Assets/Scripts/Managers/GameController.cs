using System;
using UnityEngine;
using System.Collections;

namespace GameJam
{
    public class GameController : Singleton<GameController>
    {
        public static GameObject Player
        {
            get
            {
                if (Instance.m_Player == null)
                {
                    Instance.GetPlayer();
                }
                return Instance.m_Player; 
            }
        }

        public static UserControl PlayerCtrl
        {
            get
            {
                if (Instance.m_PlayerControl == null)
                {
                    Instance.GetPlayer();
                }
                return Instance.m_PlayerControl;
            }
        }

        private GameObject m_Player = null;
        private UserControl m_PlayerControl = null;
        private string m_LevelToLoad = null;

        private void GetPlayer()
        {
            m_Player = GameObject.FindGameObjectWithTag(Tags.Player);
            m_PlayerControl = m_Player.GetComponent<UserControl>();
        }

        public void ChangeLevel(String level)
        {
            m_LevelToLoad = level;
            ScreenFader screenFader = (GameObject.FindGameObjectWithTag(Tags.ScreenFader).GetComponent<ScreenFader>());
            if (screenFader)
            {
                screenFader.StartScreenFadeToBlack();
            }
        }

        public void OnScreenFadeDone()
        {
            if (m_LevelToLoad != null)
            {
                Application.LoadLevel(m_LevelToLoad);
            }
        }
    }
}

