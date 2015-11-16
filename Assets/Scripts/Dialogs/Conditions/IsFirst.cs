using UnityEngine;
using System.Collections;

namespace GameJam
{
    public class IsFirst : MonoBehaviour, ActionCondition
    {
        public DialogTrigger m_DialogTrigger;

        public bool IsTrue()
        {
            return NarativeManager.Instance.DoesPlayerHaveDialogTriggered(m_DialogTrigger, 0);
        }
    }
}


