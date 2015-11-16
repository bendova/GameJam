using UnityEngine;
using System.Collections;

namespace GameJam
{
    public class HasTriggersInOrder : MonoBehaviour, ActionCondition
    {
        public DialogTrigger m_First;
        public DialogTrigger m_Second;

        public bool IsTrue()
        {
            bool hasFirst = NarativeManager.Instance.DoesPlayerHaveDialogTriggered(m_First, 0);
            bool hasSecond = NarativeManager.Instance.DoesPlayerHaveDialogTriggered(m_Second, 1);
            bool doesntHaveThird = NarativeManager.Instance.DoesPlayerHaveDialogTriggered(DialogTrigger.None, 2);
            return hasFirst && hasSecond;
        }
    }
}

