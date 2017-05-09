using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

	public float distance_to_camera;
	public static GameObject itemBeginDragged;
	public GameObject support;
	Vector3 startPosition;
	Transform startParent;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeginDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeginDragged = null;
		transform.position = startPosition;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == startParent) 
		{
			transform.position = startPosition;
		}
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		Vector3 mousePos = new Vector3 ();
		mousePos = Input.mousePosition;
		float distance = -Camera.main.transform.position.z + support.transform.position.z - distance_to_camera;
		mousePos.z = distance;
		transform.position = Camera.main.ScreenToWorldPoint(mousePos);
		//Debug.Log (transform.position);
	}

	#endregion

}
