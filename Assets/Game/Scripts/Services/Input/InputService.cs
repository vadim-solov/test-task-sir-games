using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public static class InputService
    {
        public static Vector3 Axis { get; set; }

        public static bool IsMove()
        {
            return Axis != Vector3.zero;
        }
    }
}
