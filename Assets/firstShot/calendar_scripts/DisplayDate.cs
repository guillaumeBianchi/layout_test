using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDate : MonoBehaviour {

	Text ui_display_date;

	public void Start()
	{
		ui_display_date = GetComponent<Text>();
	}

	public void changeElementDate(string element_date)
	{
		//Debug.Log (element_date);
		ui_display_date.text = element_date;
	}
}
