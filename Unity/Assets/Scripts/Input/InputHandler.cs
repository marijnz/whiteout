using UnityEngine;
using System.Collections;
using System;

public class InputHandler : MonoBehaviour
{
	
	private int controllerCount = 0;
	private ControllerState[] controllers;
	private ControllerState[] oldState;
	private bool isMac;
	private InputParser inputParser;

	
	static InputHandler instance;
	
	
	
	public static InputHandler Instance
		
	{
		
		get
		{
			if(!instance) {
				GameObject gameObject = new GameObject("InputHandlerContainer");
				instance = gameObject.AddComponent<InputHandler>();
				instance.Init();
				return instance;
			}

			return instance;
		}
		
	}


	public void Init() {
		
		controllers = new ControllerState[4];
		oldState = new ControllerState[4];
		for(int i = 0; i < 4; i++) {
			controllers[i] = new ControllerState(0);
			oldState[i] = new ControllerState(0);
		}
		isMac = (Application.platform == RuntimePlatform.OSXPlayer) || (Application.platform == RuntimePlatform.OSXEditor) || (Application.platform == RuntimePlatform.OSXWebPlayer);
		inputParser = new InputParser();

	}

	public void Update() {

		CheckForNewInput();

		for(int i = 0; i < controllerCount; i++) {
			oldState[i] = controllers[i];
			controllers[i] = inputParser.ParseInput(controllers[i], i + 1);
		}


	}

	private void CheckForNewInput() {
		
		if (Input.GetJoystickNames().Length != controllerCount) {
			nameControllers();
			controllerCount = Math.Min(Input.GetJoystickNames().Length, 4);
		}

	}

	public bool ButtonIsPressed(int controllerID, int buttonID) {
		ControllerState state = GetControllerState(controllerID);
		return ButtonIsPressedOnController(state, buttonID);
	}
	
	public bool ButtonGotPressed(int controllerID, int buttonID) {
		ControllerState state = GetControllerState(controllerID);
		ControllerState oldControllerState = GetControllerState(controllerID, true);
		return ButtonIsPressedOnController(state, buttonID) && !ButtonIsPressedOnController(oldControllerState, buttonID);
	}

	private bool ButtonIsPressedOnController(ControllerState state, int buttonID) {
		if(state.Buttons.ContainsKey(buttonID))
			return state.Buttons[buttonID];
		else if(state.Axis.ContainsKey(buttonID))
			return state.Axis[buttonID] > 0.5f ? true : false;
		return false;
	}
	
	public bool DPadIsPressed(int controllerID, ControllerState.DPadDirection direction) {

		ControllerState state = GetControllerState(controllerID);
		return (state.DPad & direction) == direction;
	}
	
	public bool DPadGotPressed(int controllerID, ControllerState.DPadDirection direction) {
		ControllerState state = GetControllerState(controllerID);
		ControllerState oldControllerState = GetControllerState(controllerID, true);
		return (state.DPad & direction) == direction && (oldControllerState.DPad & direction) != direction;
	}

	public float GetAxis(int controllerID, object axis) {
		ControllerState state = GetControllerState(controllerID);
		if(state.Axis.ContainsKey(axis))
			return state.Axis[axis];
		else if(state.Buttons.ContainsKey(axis))
			return state.Buttons[axis] ? 1f : 0f;
		return 0f;
	}

	
	public ControllerState GetControllerState(int controllerID) {
		return GetControllerState(controllerID, false);
	}

	public ControllerState GetControllerState(int controllerID, bool getOldState) {
		if(controllerID >= controllers.Length || controllerID < 1)
			return new ControllerState(0);
		if(getOldState)
			return oldState[controllerID - 1];
		else
			return controllers[controllerID - 1];
	}
	
	
	private void nameControllers() {
		var names = Input.GetJoystickNames();
		if(isMac) {
			for (var i = 0; i < names.Length && i < 4; i++) {
				print("matching Mac: " + names[i]);
				switch (names[i]) {
				case "Sony PLAYSTATION(R)3 Controller":
					controllers[i].Type = ControllerType.PS3;
					break;
				case "Microsoft Wireless 360 Controller":
					controllers[i].Type = ControllerType.XBoxMac;
					break;
				case "":
					controllers[i].Type = ControllerType.XBoxMac;
					break;
				default:
					controllers[i].Type = ControllerType.Unknown;
					break;
				}
			}
		}
		else {
			
			for (var i = 0; i < names.Length && i < 4; i++) {
				print("matching Win: " + names[i]);
				switch (names[i]) {
				case "Sony PLAYSTATION(R)3 Controller":
					controllers[i].Type = ControllerType.PS3;
					break;
				case "Controller (Xbox 360 Wireless Receiver for Windows)":
					
					print("found WinController");
					controllers[i].Type = ControllerType.XBoxWin;
					break;
				case "":
					controllers[i].Type = ControllerType.XBoxWin;
					break;
				default:
					controllers[i].Type = ControllerType.Unknown;
					break;
				}
			}
		}
	}
}


