using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Turret2d
{
    public class GameController : MonoBehaviour
    {
        public static bool GAME_OVER;
        public static int SCORE;

        [SerializeField]
        private Text _scoreText;

        private void Start()
        {
            GAME_OVER = false;
            SCORE = 0;
        }

        private void Update()
        {
            _scoreText.text = "Score:" + SCORE;            
        }

    }

}
