using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameJam
{
    public class KeepOnLevelChange : MonoBehaviour
    {
        private static Dictionary<string, KeepOnLevelChange> m_Instances = new Dictionary<string, KeepOnLevelChange>();

        void Awake()
        {
            if (m_Instances.ContainsKey(gameObject.name) == false)
            {
                m_Instances.Add(gameObject.name, this);
                DontDestroyOnLoad(gameObject);
            }
            else if (m_Instances[gameObject.name] != this)
            {
                Destroy(gameObject);
            }
        }
    }
}


