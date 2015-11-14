using UnityEngine;
using System.Collections;

namespace GameJam
{
    public class Interactable : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == GameController.Player)
            {
                //GameController.PlayerCtrl.OnTriggerEntered(gameObject);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == GameController.Player)
            {
//                GameController.PlayerCtrl.OnTriggerExited(gameObject);
            }
        }
    }
}


