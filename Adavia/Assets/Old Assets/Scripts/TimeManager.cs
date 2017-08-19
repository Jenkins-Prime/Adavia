using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	[Header ("Time Keeping")]
	public float seconds;
	public float hours;
	public float minutes;
	public Text text;
	public string AMPM;

	[Header ("If time is hidden from player.")]
	public bool timeHidden;

	[Header ("If time is paused.")]
	public bool timeStopped;

	void Start()
	{
		text = GetComponent<Text> ();
		AMPM = "AM";
	}

	// Update is called once per frame
	void Update () 
	{
		if (!timeStopped) 
		{
			UpdateTime ();
		}
	}

	void UpdateTime()
	{
		seconds += Time.deltaTime;
		if (seconds >= 10.0f) 
		{
			seconds = 0;
			minutes++;
			if (minutes >= 60) 
			{
				minutes = 0;
				hours++;

				if (hours >= 13) 
				{
					hours = 1;
					if (AMPM == "PM") {
						AMPM = "AM";
					} else 
					{
						AMPM = "PM";
					}
				}
			}
		}

		if (!timeHidden) 
		{
			if (minutes > 9) {
				text.text = hours + ":" + minutes + " " + AMPM;
				;
			} else {
				text.text = hours + ":" + "0" + minutes + " " + AMPM;
			}
		}

		if (timeHidden) 
		{
			text.text = "??" + ":" + "??";
		}
	}
		
}

