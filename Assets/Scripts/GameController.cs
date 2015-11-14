using System;
using UnityEngine;
using System.Collections;

namespace GameJam
{
    public class GameController : Singleton<GameController>
    {
        public static GameObject Player
        {
            get { return Instance.m_Player; }
        }

        public static UserControl PlayerCtrl
        {
            get { return Instance.m_PlayerControl; }
        }

        private GameObject m_Player = null;
        private UserControl m_PlayerControl = null;

        void Start()
        {
            m_Player = GameObject.FindGameObjectWithTag(Tags.Player);
            m_PlayerControl = m_Player.GetComponent<UserControl>();
        }

        public void ChangeLevel(String level)
        {
            Application.LoadLevel(level);
        }

        public new void OnDestroy()
        {
            // FIXME This function should not be called if our 
            // gameObject is marked as DontDestroyOnLoad()
            // when changing levels, but it is. 
            // To be investigated.
            //base.OnDestroy();
        }
    }
}

