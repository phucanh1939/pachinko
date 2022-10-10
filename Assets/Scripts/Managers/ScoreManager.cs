using System;
using Events;
using GG.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Listen To Events")]
        [SerializeField] private VoidEventChannelSO _eventPlayerCollectFruit;

        [SerializeField] private TextMeshProUGUI _textScore;

        private int _score;

        private void Start()
        {
            SetScore(0);
        }

        private void OnEnable()
        {
            _eventPlayerCollectFruit.OnEventRaised += OnPlayerCollectFruit;
        }

        private void OnDisable()
        {
            _eventPlayerCollectFruit.OnEventRaised -= OnPlayerCollectFruit;
        }

        private void OnPlayerCollectFruit()
        {
            SetScore(_score + 1);
        }

        public void SetScore(int score)
        {
            _score = score;
            _textScore.text = "Score: " + _score;
        }
    }
}