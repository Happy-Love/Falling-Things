using System;
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
		timeScore.text = SetTime(Mathf.Round(time)); ; // Rounding to the nearest hundredth
		
	}
	public string SetTime(double time)
	{
		string text="";
		//time += 50000000;
		DateTime date = new DateTime(), date2 = new DateTime();
		date = date.AddSeconds(time);
		if (date.Year - date2.Year > 0)
			text += (date.Year - date2.Year) + "y ";
		if (date.Month - date2.Month > 0)
			text += date.Month - date2.Month + "m ";
		if (date.Day - date2.Day > 0)
			text += date.Day - date2.Day + "d ";
		if (date.Hour - date2.Hour > 0)
			text += date.Hour - date2.Hour + "h ";
		if (date.Minute - date2.Minute >0)
			text += date.Minute - date2.Minute + "m ";
		if (date.Second - date2.Second > 0)
			text += date.Second - date2.Second + "s";
		return text;
	}
	
}
