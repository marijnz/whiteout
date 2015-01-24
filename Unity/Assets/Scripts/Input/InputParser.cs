using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/**
 * controller mappings
 * 
 * --- Axis of Evil---
 * XB360/Mac 3rd party driver
 * 1: LS right
 * 2: LS down
 * 3: RS: right
 * 4: RS down
 * 5: LT pulled
 * 6: RT pulled
 * 
 * PS3/Mac
 * 1: LS right
 * 2: LS down
 * 3: RS: right
 * 4: RS down
 * 
 * --- buttons ---
 * XB360/MAc 3rd party driver
 * 1: ???
 * 2: ???
 * 3: ???
 * 4: ???
 * 5: D-up
 * 6: D-down
 * 7: D-left
 * 8: D-right
 * 9: start
 * 10: back
 * 11: LS
 * 12: RS
 * 13: LB
 * 14: RB
 * 15: shiny XBox button
 * 16: A
 * 17: B
 * 18: X
 * 19: Y
 * 
 * PS3/Mac
 * 0: select
 * 1: LS
 * 2: RS
 * 3: start
 * 4: D-up
 * 5: D-right
 * 6: D-down
 * 7: D-left
 * 8: LT
 * 9: RT
 * 10: LB
 * 11: RB
 * 12: triangle
 * 13: circle
 * 14: cross
 * 15: square
 * 
 * 
 */

public class InputParser : MonoBehaviour
{

	private class InputMapper {
		public Dictionary<object,int> ButtonMapper = new Dictionary<object, int>();
		public Dictionary<object, int> AxisMapper = new Dictionary<object, int>();
	};



	public static float deadZone = 0.2f;

	private Dictionary<ControllerType, InputMapper> inputMappers = new Dictionary<ControllerType, InputMapper>();

	public InputParser()
	{
		InputMapper mapper = new InputMapper();
		mapper.ButtonMapper.Add(0,16);
		mapper.ButtonMapper.Add(1,17);
		mapper.ButtonMapper.Add(2,19);
		mapper.ButtonMapper.Add(3,18);
		mapper.ButtonMapper.Add(4,13);
		mapper.ButtonMapper.Add(5,14);
		mapper.ButtonMapper.Add(6,10);
		mapper.ButtonMapper.Add(7,15);
		mapper.ButtonMapper.Add(8,9);
		
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick0X, 1);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick0Y, 2);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick1X, 3);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick1Y, 4);

		mapper.AxisMapper.Add(ControllerState.AxisName.Trigger0, 5);
		mapper.AxisMapper.Add(ControllerState.AxisName.Trigger1, 6);
		
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Left, 8);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Up, 5);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Right, 7);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Down, 6);
		inputMappers.Add(ControllerType.XBoxMac, mapper);

		mapper = new InputMapper();
		mapper.ButtonMapper.Add(0,0);
		mapper.ButtonMapper.Add(1,1);
		mapper.ButtonMapper.Add(2,3);
		mapper.ButtonMapper.Add(3,2);
		mapper.ButtonMapper.Add(4,4);
		mapper.ButtonMapper.Add(5,5);
		mapper.ButtonMapper.Add(6,6);
		mapper.ButtonMapper.Add(7,7);
		mapper.ButtonMapper.Add(8,8);
		
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick0X, 1);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick0Y, 2);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick1X, 3);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick1Y, 4);
		
		mapper.AxisMapper.Add(ControllerState.AxisName.Trigger0, 5);
		mapper.AxisMapper.Add(ControllerState.AxisName.Trigger1, 6);
		
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Left, 8);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Up, 5);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Right, 7);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Down, 6);
		inputMappers.Add(ControllerType.XBoxWin, mapper);

		mapper = new InputMapper();
		mapper.ButtonMapper.Add(0,16);
		mapper.ButtonMapper.Add(1,17);
		mapper.ButtonMapper.Add(2,19);
		mapper.ButtonMapper.Add(3,18);
		mapper.ButtonMapper.Add(4,13);
		mapper.ButtonMapper.Add(5,14);
		mapper.ButtonMapper.Add(6,10);
		mapper.ButtonMapper.Add(7,15);
		mapper.ButtonMapper.Add(8,9);

		mapper.AxisMapper.Add(ControllerState.AxisName.Trigger0, 5);
		mapper.AxisMapper.Add(ControllerState.AxisName.Trigger1, 6);

		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick0X, 1);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick0Y, 2);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick1X, 3);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick1Y, 4);

		
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Left, 8);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Up, 5);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Right, 7);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Down, 6);
		inputMappers.Add(ControllerType.Unknown, mapper);

		mapper = new InputMapper();
		mapper.ButtonMapper.Add(0,14);
		mapper.ButtonMapper.Add(1,13);
		mapper.ButtonMapper.Add(2,12);
		mapper.ButtonMapper.Add(3,15);
		mapper.ButtonMapper.Add(4,10);
		mapper.ButtonMapper.Add(5,11);
		mapper.ButtonMapper.Add(6,0);
		mapper.ButtonMapper.Add(7,16);
		mapper.ButtonMapper.Add(8,3);
		
		
		mapper.ButtonMapper.Add(ControllerState.AxisName.Trigger0, 8);
		mapper.ButtonMapper.Add(ControllerState.AxisName.Trigger1, 9);
		
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick0X, 1);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick0Y, 2);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick1X, 3);
		mapper.AxisMapper.Add(ControllerState.AxisName.AnalogStick1Y, 4);

		
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Left, 7);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Up, 4);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Right, 5);
		mapper.ButtonMapper.Add(ControllerState.DPadDirection.Down, 6);
		inputMappers.Add(ControllerType.PS3, mapper);
	}

	public ControllerState ParseInput(ControllerState inState, int playerID){
		ControllerState state = new ControllerState(0);

		if(!inputMappers.ContainsKey(inState.Type))
			return state;
		state.Type = inState.Type;

		foreach(object inputType in inputMappers[inState.Type].ButtonMapper.Keys) {
			state.Buttons.Add(inputType, RetrieveButtonData(playerID, inputMappers[inState.Type].ButtonMapper[inputType]));
		}

		foreach(ControllerState.AxisName inputType in inputMappers[inState.Type].AxisMapper.Keys) {
			state.Axis.Add(inputType, RetrieveAxisDataDeadZoned(playerID, inputMappers[inState.Type].AxisMapper[inputType]));
		}

		state.DPad = ControllerState.DPadDirection.None;

		bool left = RetrieveButtonData(playerID, inputMappers[inState.Type].ButtonMapper[ControllerState.DPadDirection.Left]);
		bool up = RetrieveButtonData(playerID, inputMappers[inState.Type].ButtonMapper[ControllerState.DPadDirection.Left]);
		bool right = RetrieveButtonData(playerID, inputMappers[inState.Type].ButtonMapper[ControllerState.DPadDirection.Left]);
		bool down = RetrieveButtonData(playerID, inputMappers[inState.Type].ButtonMapper[ControllerState.DPadDirection.Left]);

		if(left)
			state.DPad |= ControllerState.DPadDirection.Left;
		if(right)
			state.DPad |= ControllerState.DPadDirection.Right;
		if(up)
			state.DPad |= ControllerState.DPadDirection.Up;
		if(down)
			state.DPad |= ControllerState.DPadDirection.Down;

		return state;
	}

	
	private float RetrieveAxisDataDeadZoned(int playerID, int axis) {
		return MathUtils.DeadZone(deadZone, RetrieveAxisDataRaw(playerID, axis));
	}
	
	private float RetrieveAxisDataRaw(int playerID, int axis) {
		var identifier = "Joystick_" + playerID + "_axis_" + axis;
		return Input.GetAxis(identifier);
	}
	
	private bool RetrieveButtonData(int playerID, int button) {
		var identifier = "Joystick_" + playerID + "_button_" + button;
		return Input.GetButton(identifier);
	}

	
	
	public static void DebugDumpAxis() {
		for (var joystick = 1; joystick <= 2; joystick++) {
			for (var axis = 1; axis <= 10; axis++) {
				var identifier = "Joystick_" + joystick + "_axis_" + axis;
				var value = Input.GetAxis(identifier);
				Debug.Log(identifier + ", value: " + value);
			}
		}
	}
	
	public static void DebugDumpButtons() {
		for (var joystick = 1; joystick <= 1; joystick++) {
			for (var button = 0; button <= 19; button++) {
				var identifier = "Joystick_" + joystick + "_button_" + button;
				var value = Input.GetButton(identifier);
				Debug.Log(identifier + ", value: " + value);
			}
		}
	}
}