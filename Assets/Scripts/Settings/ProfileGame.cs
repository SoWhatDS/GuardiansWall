
using GuardiansWall.Utils;

namespace GuardiansWall.Settings
{
    internal sealed class ProfileGame 
    {
        public readonly SubscriptionProperty<GameState> CurrentGameState;

        public ProfileGame(GameState initialState)
        {
            CurrentGameState = new SubscriptionProperty<GameState>();
            CurrentGameState.Value = initialState;
        }
    }
}
