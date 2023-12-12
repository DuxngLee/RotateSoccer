using UnityEngine;

namespace Script.Player
{
    using System;
    public class ControlPlayer : MonoBehaviour
    {
        public                   Action<ControlPlayer>     OnFinish;
        public                   Action<ControlPlayer>     OnLose;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Trap"))
            {
                this.OnLose?.Invoke(this);
            }
            else if (other.gameObject.CompareTag("Finish"))
            {
                this.OnFinish?.Invoke(this);
            }
        }
    }
}

