using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



public static class CustomInputManager {


	//TODO PLAYERID ARE 1 BASED!!!!;
	private static bool init = false;

	public enum Token {
		HorizontalMove,
		VerticalMove,
		Interact
	}

	private static Dictionary<Token, int>[] buttonMappings = new Dictionary<Token, int>[4];
	private static Dictionary<Token, ControllerState.AxisName>[] axisMappings = new Dictionary<Token, ControllerState.AxisName>[4];

	
	private static Dictionary<Token, KeyCode>[] keyMappings = new Dictionary<Token, KeyCode>[4];


	private static void Init() {
		if(init)
			return;
		for(int i = 0; i < 4; i++) {
			buttonMappings[i] = new Dictionary<Token, int>();
			buttonMappings[i].Add(Token.Interact, 0);
			axisMappings[i] = new Dictionary<Token, ControllerState.AxisName>();
			axisMappings[i].Add(Token.HorizontalMove, ControllerState.AxisName.AnalogStick0X);
			axisMappings[i].Add(Token.VerticalMove, ControllerState.AxisName.AnalogStick0Y);
			keyMappings[i] = new Dictionary<Token, KeyCode>();
		}

		keyMappings[1].Add(Token.Interact, KeyCode.Space);

		init = true;
	}

	public static float GetAxis(Token token, int playerID) {
		Init();
		
		float output = InputHandler.Instance.GetAxis(playerID, axisMappings[playerID][token]);
		if(token == Token.HorizontalMove) {
			if(Input.GetKey(KeyCode.A))
				output = -1;
			if(Input.GetKey(KeyCode.D))
				output = 1;
		}		
		if (token == Token.VerticalMove) {
			if(Input.GetKey (KeyCode.W))
				output = 1;
			if(Input.GetKey (KeyCode.S))
				output = -1;
		}
		return output;
	}
	
	public static bool ButtonIsPressed(Token token, int playerID) {
		Init();
		return InputHandler.Instance.ButtonIsPressed(playerID, buttonMappings[playerID][token]) || Input.GetKey(keyMappings[playerID][token]);
	}
	
	public static bool ButtonGotPressed(Token token, int playerID) {
		Init();

		return InputHandler.Instance.ButtonGotPressed(playerID, buttonMappings[playerID][token]) || Input.GetKeyDown(keyMappings[playerID][token]);
	}
}
