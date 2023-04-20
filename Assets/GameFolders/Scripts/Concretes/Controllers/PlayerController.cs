using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Movements;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Inputs;
using UnityEngine.InputSystem;
using UdemyProject2.Managers;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Movements;

namespace UdemyProject2.Controllers
{

	public class PlayerController : MyCharacterController,IEntityController
	{
	
		[SerializeField] float _jumpForce = 300f;



		IMover _mover;
		IJump _jump;
		IInputReader _input;
		float _horizontal;
		bool _isJump;
		bool _isDead = false;

		private void Awake()
		{
			_mover = new HorizontalMover(this);
			_jump = new JumpWithRigidbody(this);
			_input = new InputReader(GetComponent<PlayerInput>());
		}
		private void Update()
		{
			if (_isDead)
			{
				return;
			}
			_horizontal = _input.Horizontal;

			if (_input.IsJump)
			{
				_isJump = true;
			}

		}

		private void FixedUpdate()
		{
			_mover.FixedTick(_horizontal);


			if (_isJump)
			{
				_jump.FixedTick(_jumpForce);
			}
			_isJump = false;
		}

		private void OnTriggerEnter(Collider other)
		{
			 IEntityController entityController = other.GetComponent<IEntityController>();
			if (entityController != null)
			{
				_isDead = true;


				GameManager.Instance.StopGame();
			}
		}
	}
}

