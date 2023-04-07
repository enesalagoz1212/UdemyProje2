using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Controllers;

namespace UdemyProject2.Movements
{
    public class JumpWithRigidbody 
    {
        Rigidbody _rigidbody;

		public JumpWithRigidbody(PlayerController playerController)
		{
            _rigidbody = playerController.GetComponent<Rigidbody>();
            
        }

        public void TickFixed(float jumpForce)
		{
            if (_rigidbody.velocity.y != 0) return;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * Time.deltaTime * jumpForce);
			
		}

    }

}
