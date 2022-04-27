using Leopotam.Ecs;
using UnityEngine;

namespace Player
{
    public class CoinReceivingSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, PlayerScoreComponent> playerScoreFilter = null;
        
        public void Init()
        {
            foreach (var i in playerScoreFilter)
            {
                ref int score = ref playerScoreFilter.Get2(i).score;
                score = 0;
                ref GameObject gameObject = ref playerScoreFilter.Get1(i).gameObject;
                gameObject.GetComponent<CoinReceiver>().SetScoreUpdater(TakeCoin);
            }
        }

        void TakeCoin()
        {
            foreach (var i in playerScoreFilter)
            {
                ref int score = ref playerScoreFilter.Get2(i).score;
                score++;
                Debug.Log(score);
            }
        }
    }
}