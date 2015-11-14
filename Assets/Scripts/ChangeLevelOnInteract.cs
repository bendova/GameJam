using UnityEngine;

namespace GameJam
{
    public class ChangeLevelOnInteract : MonoBehaviour
    {
        public string m_LevelToLoad = "";

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject == GameController.Player)
            {
                if(GameController.PlayerCtrl.IsInteracting())
                {
                    GameController.Instance.ChangeLevel(m_LevelToLoad);
                }
            }
        }
    }
}
