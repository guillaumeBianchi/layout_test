using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking.NetworkSystem;
using System.Globalization;

public class DateManager : MonoBehaviour {

	DateTime current_date;
	int chosen_day;
	public GameObject ui_display_month;
	public GameObject ui_display_year;
	public GameObject ui_display_days_in_month;
	public GameObject ui_display_day;

	void Start()
	{
		chosen_day = 1;
		current_date = DateTime.Now.Date;

		if (ui_display_month == null) 
		{
			ui_display_month = GameObject.Find ("mois_ui");
		}
		if (ui_display_year == null) 
		{
			ui_display_year = GameObject.Find ("annee_ui");
		}
		if (ui_display_days_in_month == null) 
		{
			ui_display_days_in_month = GameObject.Find ("Selection jour");
		}
		if (ui_display_day == null) 
		{
			ui_display_day = GameObject.Find ("jour_ui");
		}
		displayDate ();
	}

	public void setChosenDay(string _chosen_day_on_click)
	{
		chosen_day = int.Parse(_chosen_day_on_click);
		//Debug.Log ("chosen day "+ chosen_day);
		displayDay();
	}

	public void displayChosenDate()
	{
		int year = current_date.Year;
		int month = current_date.Month;
		int day = chosen_day;
		DateTime chosen_date = new DateTime (year,month,day);
		Debug.Log (chosen_date);
	}

	public DateTime getChosenDate()
	{
		int year = current_date.Year;
		int month = current_date.Month;
		int day = chosen_day;
		DateTime chosen_date = new DateTime (year,month,day);
		return chosen_date;
	}

	public void previousMonth()
	{
		//Debug.Log ("mois précédent.");
		current_date = current_date.AddMonths (-1);	
		//Debug.Log (current_date);
		displayDate ();
	}

	public void nextMonth()
	{
		//Debug.Log ("mois suivant.");
		current_date = current_date.AddMonths (1);	
		//Debug.Log (current_date);
		displayDate ();
	}

	void displayDate()
	{
		displayDay ();
		displayMonth ();
		displayYear ();
		displayDaysInMonth ();
	}

	void displayYear()
	{
		ui_display_year.SendMessage ("changeElementDate",current_date.Year.ToString("D"));
	}

	void displayMonth()
	{
		ui_display_month.SendMessage ("changeElementDate",toMonthName(current_date));
	}

	void displayDay()
	{
		ui_display_day.SendMessage ("changeElementDate",chosen_day.ToString());
	}

	void displayDaysInMonth()
	{
		object[] tempstorage = new object[2];
		tempstorage [0] = current_date.Year;
		tempstorage [1] = current_date.Month;
		ui_display_days_in_month.SendMessage ("displayDays",tempstorage);
	}

	string toMonthName(DateTime dateTime)
	{
		return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName (dateTime.Month);
	}

	string toShortMonthName(DateTime dateTime)
	{
		return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName (dateTime.Month);
	}
}
