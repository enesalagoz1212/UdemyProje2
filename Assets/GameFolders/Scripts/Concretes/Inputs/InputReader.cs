using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UdemyProject2.Abstracts.Inputs;

namespace UdemyProject2.Inputs
{
	public class InputReader : IInputReader
	{
		PlayerInput _playerInput;

		public float Horizontal { get; private set; }
		public InputReader(PlayerInput playerInput)
		{
			_playerInput = playerInput;

			_playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;
		}

		private void OnHorizontalMove(InputAction.CallbackContext context)
		{
			Horizontal = context.ReadValue<float>();
		}
	}
}

