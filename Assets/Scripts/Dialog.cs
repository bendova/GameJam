using System;
using UnityEngine;

namespace GameJam
{
    [System.Serializable]
    public class Choice
    {
        [TextArea(2, 10)]
        public String m_ChoiceText;
        public Dialog m_NextDialog;
        public MonoBehaviour m_Trigger;
    }

    public class Dialog : MonoBehaviour
    {
        [TextArea(3, 10)]
        public String m_DialogText = "";
        public String m_RememberText = "";
        public String m_ActionText = "";
        public bool m_BlockPlayerInput = true;
        public Choice[] m_Choices;
    }
}
