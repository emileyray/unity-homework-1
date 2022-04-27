using System;
using UnityEngine;

namespace Player
{
    public class CoinReceiver : MonoBehaviour
    {
        private Action updateScore; 
        private void OnTriggerEnter(Collider other)
        {
            var playerMovement = other.GetComponent<CoinMoving>();
            if (playerMovement == null) return;
            
            updateScore();
            
            Destroy(other.gameObject);
        }

        public void SetScoreUpdater(Action method)
        {
            updateScore = method;
        }
    }
}