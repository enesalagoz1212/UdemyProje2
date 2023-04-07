using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Movements;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Inputs;
using UnityEngine.InputSystem;

namespace UdemyProject2.Controllers
{
   
    public class PlayerController : MonoBehaviour
    {
	
		[SerializeField] float _moveSpeed = 10f;
		[SerializeField] float _jumpForce = 300f;
		[SerializeField] bool _isJump;


        HorizontalMover _horizontalMover;
		JumpWithRigidbody _jump;
		IInputReader _input;
		float _horizontal;

		
		private void Awake()
		{
			_horizontalMover = new HorizontalMover(this);
			_jump = new JumpWithRigidbody(this);
			_input = new InputReader(GetComponent<PlayerInput>());
		}
		private void Update()
		{
			_horizontal = _input.Horizontal;
			Debug.Log(_input.Horizontal);
		}

		private void FixedUpdate()
		{
			_horizontalMover.TickFixed(_horizontal, _moveSpeed);


			if (_isJump)
			{
				_jump.TickFixed(_jumpForce);
			}
			_isJump = false;
		}
	}
}

