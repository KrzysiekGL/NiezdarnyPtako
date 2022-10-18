using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreCounter : MonoBehaviour
{
		private int _score = 0;

		private Label _scoreCounter;

		void Start()
		{
				// Find the UI score counter
				_scoreCounter = GetComponent<UIDocument>().rootVisualElement.Q<Label>("score");

				// Subscribe to the Ptako's PointScored and GameReset events
				Ptako ptako = GameObject.FindObjectOfType<Ptako>();
				ptako.PointScored += IncrementScoreCounter;
				ptako.GameReset += RestartTheGame;
		}

		void IncrementScoreCounter(object sender, EventArgs e)
		{
				// Inrement the score and update the UI element with the score count
				_score += 1;
				_scoreCounter.text = _score.ToString();
		}

		void RestartTheGame(object sender, EventArgs e)
		{
				_score = 0;
				_scoreCounter.text = _score.ToString();
		}
}
