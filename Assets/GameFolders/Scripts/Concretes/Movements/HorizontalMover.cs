using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Movements;

namespace UdemyProject2.Movements
{
    public class HorizontalMover :IMover
    {
        IEntityController _entityController;
		

		public HorizontalMover(IEntityController entityController)
		{
            _entityController = entityController;
			
			
		}

        public void FixedTick(float horizontal )
		{
			if (horizontal==0)
			{
				return;
			}
			else
			{
	    _entityController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _entityController.MoveSpeed);
		float xBoundary = Mathf.Clamp(_entityController.transform.position.x,-_entityController.MoveBoundary,_entityController.MoveBoundary);
	    _entityController.transform.position = new Vector3(xBoundary, _entityController.transform.position.y, 0f);
			}
			
		}
    }
}


