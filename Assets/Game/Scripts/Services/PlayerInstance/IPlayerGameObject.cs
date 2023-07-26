namespace Game.Scripts.Services.PlayerInstance
{
    public interface IPlayerGameObject
    {
        public Player.Player Instance { get; }
        public void SetPlayer(Player.Player player);
    }
}
