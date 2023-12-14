using System;
using System.Collections;
using System.Collections.Generic;
using Script.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Level.Controller
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<ControlPlayer> players;
        private                  int                 countPlayerFinish;

        public int CountPlayer => this.players.Count;

        private void Awake()
        {
            foreach (var player in this.players)
            {
                player.OnFinish = this.ActionFinish;
                player.OnLose   = this.ActionLose;
            }
            //this.players.ForEach(player => player.OnFinish = this.ActionFinish);
        }

        private void ActionFinish(ControlPlayer player)
        {
            if (!player.gameObject.activeSelf) return;
            player.gameObject.SetActive(false);
            this.countPlayerFinish++;
            if (this.countPlayerFinish == this.players.Count)
            {
                // winScreen active
                LevelManager.Instance.CompleteLevel();
            }
        }

        private void ActionLose(ControlPlayer player)
        {
            LevelManager.Instance.DestroyLevel();
            LevelManager.Instance.CreateLevel();
        }
    }
}