using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
	private enum States
	{
		cell,
		mirror,
		sheets_0,
		lock_0,
		cell_mirror,
		sheets_1}
	;

	public Text text;

	// Use this for initialization
	void Start ()
	{
		this.text = "You are in a prision cell, and you want to" +
			" escape. There are some dirty sheet on the bed, a mirror on " +
			"the wal, and the door is locked from the outside. \n\n" +
			"Press S to view sheets, press M to view Mirror and L to view Lock";
	}
		
	
	// Update is called once per frame
	void Update ()
	{
		f (Input.GetKeyDown (knownState.key)) {
			return knownState;
		}
	}
}




