using EventSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace Interactables
{
    public class PotController
    {
        public CustomGameEvent OnThrownToPot;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Collidable"))
            {
                //OnThrownToPot.Invoke();
            }
        }
        
    }
}