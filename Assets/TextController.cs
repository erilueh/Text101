﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
	private State currentState;

	public Text text;

	// Use this for initialization
	void Start ()
	{
		var cell = new Cell (); //new State (States.cell, KeyCode.Space, cellText);
		var sheet0 = new State (States.sheets_0, KeyCode.S, "Sheet 0");
		sheet0.AddState (cell);
		var lock0 = new State (States.lock_0, KeyCode.L, "Lock 0");
		lock0.AddState (cell);
		var mirror = new State (States.mirror, KeyCode.M, "Mirror");
		mirror.AddState (cell);
		cell.AddState (sheet0);
		cell.AddState (lock0);
		cell.AddState (mirror);
		currentState = cell;
	}
		
	
	// Update is called once per frame
	void Update ()
	{
		currentState = currentState.CheckAction ();
		text.text = currentState.Text;
	}
}

enum States
{
	cell,
	mirror,
	sheets_0,
	lock_0,
	cell_mirror,
	sheets_1}
;


class Cell : State
{
	public Cell ()
	{
		this.stateName = States.cell; 
		this.key = KeyCode.Space; 
		this.text = "You are in a prision cell, and you want to" +
		" escape. There are some dirty sheet on the bed, a mirror on " +
		"the wal, and the door is locked from the outside. \n\n" +
		"Press S to view sheets, press M to view Mirror and L to view Lock";
	}
}

class State
{
	protected States stateName;
	protected KeyCode key;
	protected string text;
	private List<State> knownStates = new List<State> ();

	public string Text { 
		get { return text; } 
	}

	protected State ()
	{
	}

	public State (States stateName, KeyCode key, string text)
	{
		this.stateName = stateName;
		this.key = key;
		this.text = text;
	}

	public State AddState (State newState)
	{
		knownStates.Add (newState);
		return newState;
	}

	public State CheckAction ()
	{
		foreach (State knownState in knownStates) {
			if (Input.GetKeyDown (knownState.key)) {
				return knownState;
			}
		}
		return this;
	}
}

