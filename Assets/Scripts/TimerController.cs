using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
	
	[SerializeField] Text timerHoursText;
	[SerializeField] Text timerMinutesText;
	[SerializeField] Text timerSecondsText;

	System.DateTime time;
	System.DateTime lastTime;

	// Use this for initialization
	void Start () {
		time = lastTime = System.DateTime.UtcNow;

		timerHoursText.text = time.Hour.ToString("00");
		timerMinutesText.text = time.Minute.ToString("00");
		timerSecondsText.text = time.Second.ToString("00");
	}

	// Update is called once per frame
	void Update () {
		time = System.DateTime.UtcNow;
		SetTimer ();
	}

	void SetTimer() {
		if(time.Hour != lastTime.Hour) {
			timerHoursText.text = time.Hour.ToString("00");
		}

		if(time.Minute != lastTime.Minute) {
			timerMinutesText.text = time.Minute.ToString("00");
		}

		if(time.Second != lastTime.Second) {
			timerSecondsText.text = time.Second.ToString("00");
		}
	}
}
