using Leopotam.Ecs;
using Player;

namespace Text
{
    public class TextSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<TextComponent> textFilter = null;
        private readonly EcsFilter<PlayerScoreComponent> playerScoreFilter = null;

        public void Run()
        {
            foreach (var i in textFilter)
            {
                foreach (var j in playerScoreFilter)
                {
                    ref var text = ref textFilter.Get1(i).text;
                    text.text = "Score: " + playerScoreFilter.Get1(j).score;
                }
            }
        }
    }
}