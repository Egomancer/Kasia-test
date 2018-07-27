using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour {

	[SerializeField] Animator canvasAnimator;

	public void SwitchViews() {
		canvasAnimator.SetTrigger ("SwitchViews");
	}
}
