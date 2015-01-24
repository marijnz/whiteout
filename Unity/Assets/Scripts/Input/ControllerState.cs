using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public enum ControllerType {
	Unknown,
	XBoxMac,
	XBoxWin,
	PS3
}


public struct ControllerState {

	[Flags]
	public enum DPadDirection {
		None = 0,
		Left = 1,
		Right = 2,
		Up = 4,
		Down = 8,
	}

	public enum AxisName {
		AnalogStick0X,
		AnalogStick0Y,
		AnalogStick1X,
		AnalogStick1Y,
		Trigger0,
		Trigger1,
	}

	public Dictionary<object, bool> Buttons;
	public DPadDirection DPad;
	public ControllerType Type;
	public Dictionary<object, float> Axis;

	public ControllerState(int uselessValue) {

		Buttons = new Dictionary<object, bool>();

		
		DPad = DPadDirection.None;
		Type = ControllerType.Unknown;

		Axis = new Dictionary<object, float>();

	}
}
