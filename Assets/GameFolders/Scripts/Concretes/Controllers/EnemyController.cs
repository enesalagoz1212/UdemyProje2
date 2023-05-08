using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Movements;
using System;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Managers;
using UdemyProject2.Enums;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MyCharacterController,IEntityController
    {
		
		[SerializeField] float _maxLifeTime = 10f;
		[SerializeField] EnemyEnum _enemyEnum;
		VerticalMover _mover;
		float _currentLifeTime = 0f;

		public EnemyEnum EnemyType => _enemyEnum;


		private void Awake()
		{
			_mover = new VerticalMover(this);
		}
		private void Update()
		{
			_currentLifeTime += Time.deltaTime;
			if (_currentLifeTime>_maxLifeTime)
			{
				_currentLifeTime = 0f;
				KillYourself();
			}
		}

		

		private void FixedUpdate()
		{
			_mover.FixedTick();
		}

		private void KillYourself()
		{
			EnemyManager.Instance.SetPool(this);
		}
		public void SetMoveSpeed(float moveSpeed)
		{
			if (moveSpeed<_moveSpeed)
			{
				return;
			}
			_moveSpeed = moveSpeed;
		}
	}
}

