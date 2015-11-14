using System;
using UnityEngine;

namespace GameJam
{
    [System.Serializable]
    public class Choice
    {
        public String m_ChoiceText;
        public String m_OnSelectedEvent;
    }

    [System.Serializable]
    public class Dialog
    {
        public String m_DialogText;
        public String m_RememberText;
        public Choice[] m_Choices;
    }

    public class TextManager : Singleton<TextManager>
    {
        public Dialog[] m_Dialogs;
    }
}


