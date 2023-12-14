namespace Script.Screens.Screen
{
    using Script.Level;
    using UnityEngine;
    using UnityEngine.UI;

    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private Button buttonNextLevel;

        private void Start() { this.buttonNextLevel.onClick.AddListener(this.OnNextLevel); }

        private void OnNextLevel()
        {
            LevelManager.Instance.NextLevel();
            this.gameObject.SetActive(false);
        }
    }
}