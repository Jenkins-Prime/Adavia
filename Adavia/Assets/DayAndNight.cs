using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour {

	private TimeManager time;
	public Light sun;
	private float sunTime = 30f;
	public bool isDay;
	public bool isNight;
	public Camera cam;

	[Header("Colours of the Background")]
	private Color currentColor;
	public Color nightColor;
	public Color midColor;
	public Color dayColor;



	// Use this for initialization
	void Start () {
		time = FindObjectOfType<TimeManager> ();
		currentColor = dayColor;
	}
	
	// Update is called once per frame
	void Update () {

		SunCheck ();
		ColorCheck ();

	}

	void ColorCheck()
	{
		if (time.hours == 5 && time.minutes == 30) 
		{
			cam.backgroundColor = Color.Lerp(currentColor, midColor, 30.0f);
			currentColor = cam.backgroundColor;
		}
		if (time.hours == 6 && time.minutes == 0) 
		{
			if (time.AMPM == "PM") 
			{
				cam.backgroundColor = Color.Lerp(currentColor, nightColor, 30.0f);
				currentColor = cam.backgroundColor;
			}

			if (time.AMPM == "AM") 
			{
				cam.backgroundColor = Color.Lerp(currentColor, dayColor, 30.0f);
				currentColor = cam.backgroundColor;
			}
		}
	}

	void SunCheck()
	{
		if (time.hours == 6) 
		{
			if (time.AMPM == "AM") 
			{
				sunTime += Time.deltaTime;
				if (sunTime >= 1) 
				{
					sunTime = 1;
				}
				sun.intensity = sunTime;

				isDay = true;
				isNight = false;
			} 
			if (time.AMPM == "PM") 
			{
				sunTime -= Time.deltaTime;
				if (sunTime <= 0) 
				{
					sunTime = 0;
				}
				sun.intensity = sunTime;

				isNight = true;
				isDay = false;
			}
		}
	}
}
