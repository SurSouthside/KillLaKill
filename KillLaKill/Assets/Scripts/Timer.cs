using UnityEngine;
using System.Collections;
using System;

/*
 * Timer script used for keeping time in game and (I assume) handling time based events
 * such as the fight's remaining time reaching 0. I do not know how to get things to interact
 * with eachother properly in Unity yet as I have just started using it, but getting the clock
 * script to work properly by itself was done pretty easily in about a half hour this morning (4/6/2014)
 * --I Shot Web
 */
public class Timer : MonoBehaviour {

	public float initTime;
	public bool HourDisplay = false;
	private float timeRemaining;


	// Use this for initialization
	void Start () {
		timeRemaining = initTime;
	}

	//for reporting stats after game ends
	string timeElapsed(){
		float timeElapsed = initTime - timeRemaining;
		return timeElapsed.ToString ();
	}

	/*
	 * Converts time to 00:00.00 format (assuming anything larger than an hour will be 
	 * displayed as 61-99 minutes. Change HourDisplay to true to get 00:00:00.00 format)
	 * I do not know any more efficient ways of doing this in unity, but
	 * here is the literal logic that gets the job done.
	 * --I Shot Web
	 */
	string displayTime(float time){
		//strings for handling leading zeroes if needed, not needed for hours
		string minutes = "";
		string seconds = "";
		string milliseconds = "";
		if (HourDisplay) {
			int hours = (int)time / 3600;
			time %= 3600f;
			int minutesI = (int)time / 60;
			time %= 60f;
			int secondsI = (int)time;
			time %= 1f;
			int millisecondsI = (int)(time*100);

			//adding on leading zeroes if needed
			if(minutesI < 10){
				minutes = "0"+minutesI;
			}
			else{
				minutes = minutesI.ToString();
			}

			if(secondsI < 10){
				seconds = "0"+secondsI.ToString();
			}
			else{
				seconds = secondsI.ToString();
			}

			if(millisecondsI < 10){
				milliseconds = "0"+millisecondsI.ToString();
			}
			else{
				milliseconds = millisecondsI.ToString();
			}

			return (hours.ToString() + ":" + minutes + ":" + seconds + "." + milliseconds);
		} 
		else {
			int minutesI = (int)time / 60;
			time %= 60;
			int secondsI = (int)time;
			time %= 1f;
			int millisecondsI = (int)(time*100);

			//adding on leading zeroes if needed
			if(minutesI < 10){
				minutes = "0"+minutesI.ToString();
			}
			else{
				minutes = minutesI.ToString();
			}
			
			if(secondsI < 10){
				seconds = "0"+secondsI.ToString();
			}
			else{
				seconds = secondsI.ToString();
			}

			if(millisecondsI < 10){
				milliseconds = "0"+millisecondsI.ToString();
			}
			else{
				milliseconds = millisecondsI.ToString();
			}

			return (minutes + ":" + seconds + "." + milliseconds);
		}
	}

	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
		if (timeRemaining < 0f) {
			//Ends game
		} else {
			guiText.text = displayTime(timeRemaining);
		}
	}
}
