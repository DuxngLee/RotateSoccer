using Script.Level.Controller;
using UnityEngine;

namespace Script.Level
{
    using Script.Screens;

    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        private LevelController level;
        private int             currentLevel = 1;

        private void Awake()
        {
            Instance = this;
            this.CreateLevel();
        }

        public void CompleteLevel()
        {
            this.currentLevel++;
            ScreenManager.Instance.OpenScreen("ScreenWin");
        }

        public void CreateLevel(int levelNumber = -1)
        {
            levelNumber = levelNumber == -1 ? this.currentLevel : levelNumber;
            var levelName   = $"Levels/Level{levelNumber}";
            var levelPrefab = Resources.Load<GameObject>(levelName);
            this.level = Instantiate(levelPrefab)?.GetComponent<LevelController>();
        }

        public void DestroyLevel()
        {
            if (!this.level) return;
            Destroy(this.level.gameObject);
        }

        public void NextLevel()
        {
            this.DestroyLevel();
            this.CreateLevel();
        }
    }
}