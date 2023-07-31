using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public class MobileInput : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}
