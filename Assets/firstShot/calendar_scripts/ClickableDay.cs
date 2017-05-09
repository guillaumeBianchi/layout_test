using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableDay : MonoBehaviour {

	public GameObject date_manager;
	public GameObject display_chosen_date;
	public string day;

	void Start()
	{
		if (date_manager == null)
		{
			date_manager = GameObject.FindGameObjectWithTag("Date Manager");
		}
		day = GetComponentInChildren<Text> ().text;
	}

	public void sendChosenDay()
	{
		date_manager.SendMessage("setChosenDay",day);
	}
}
