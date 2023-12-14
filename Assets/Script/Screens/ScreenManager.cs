using UnityEngine;

namespace Script.Screens
{
    using System.Collections.Generic;

    public class ScreenManager : MonoBehaviour
    {
        public static            ScreenManager Instance;
        [SerializeField] private GameObject    screenWin;

        public void Awake() { Instance = this; }

        public void OpenScreen(string nameScreen)
        {
            var listScreens = new List<GameObject>() { this.screenWin };
            listScreens.ForEach(item => item.SetActive(false));
            switch (nameScreen)
            {
                case "ScreenWin":
                    this.screenWin.SetActive(true);
                    break;
            }
        }
    }
}