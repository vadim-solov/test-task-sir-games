namespace Game.Scripts.Services.PlayerInstance
{
    public class PlayerGameObject : IPlayerGameObject
    {
        public Player.Player Instance { get; private set; }

        public void SetPlayer(Player.Player player)
        {
            Instance = player;
        }
    }
}
