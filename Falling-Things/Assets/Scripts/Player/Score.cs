using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	[SerializeField] private Text coinScore;
	[SerializeField] private Text timeScore;

	public void SetScores(int coins,float time)
	{
		coinScore.text = coins.ToString();
		timeScore.text = Mathf.Round(time).ToString()+" seconds"; // Rounding to the nearest hundredth
	}

	
}
