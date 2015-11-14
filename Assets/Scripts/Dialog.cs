using System;
using UnityEngine;

namespace GameJam
{
    [System.Serializable]
    public class Choice
    {
        public String m_ChoiceText;
        public Dialog m_NextDialog;
        public MonoBehaviour m_Trigger;
    }

    public class Dialog : MonoBehaviour
    {
        public String m_DialogText = "";
        public String m_RememberText = "";
        public String m_ActionText = "";
        public bool m_BlockPlayerInput = true;
        public Choice[] m_Choices;
    }
}
