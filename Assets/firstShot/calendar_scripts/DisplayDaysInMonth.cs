using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDaysInMonth : MonoBehaviour {

	int days_in_month;
	public GameObject day_prefab_ui;
	int previous_day_in_month = 0;

	void displayDays(object[] tempStorage)
	{
		int year = (int)tempStorage [0];
		int month = (int)tempStorage [1];
		days_in_month = System.DateTime.DaysInMonth (year, month);

		//Clear que si le nombre de jour est différent.
		if (previous_day_in_month != days_in_month) 
		{
			clearCalendar ();
			for (int day = 1; day <= days_in_month; day++) 
			{
				//Debug.Log (day);
				GameObject new_day = Instantiate (day_prefab_ui);
				new_day.transform.SetParent (gameObject.transform);
				new_day.name = "jour " + day.ToString ();
				new_day.GetComponentInChildren<Text> ().text = day.ToString ();
			}
		}

		previous_day_in_month = days_in_month;
	}

	void clearCalendar()
	{
		foreach (Transform child in transform) 
		{
			GameObject.Destroy (child.gameObject);
		}
	}
}
