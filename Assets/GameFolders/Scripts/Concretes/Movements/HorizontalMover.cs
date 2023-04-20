using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Movements;

namespace UdemyProject2.Movements
{
    public class HorizontalMover :IMover
    {
        IEntityController _playerController;
		float _moveSpeed;
		float _moveBoundary;

		public HorizontalMover(IEntityController entityController)
		{
            _playerController = entityController;
			_moveSpeed = entityController.MoveSpeed;
			_moveBoundary = entityController.MoveBoundary;
		}

        public void FixedTick(float horizontal )
		{
			if (horizontal==0)
			{
				return;
			}
			else
			{
				_playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _moveSpeed);
				float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);
				_playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y, 0f);
			}
			
		}
    }
}


