using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Managers;


namespace UdemyProject2.Uis
{
	public class MenuPanel : MonoBehaviour
	{
		public void StartButton()
		{
			GameManager.Instance.LoadScene("Game");
		}
		public void ExitButton()
		{
			GameManager.Instance.ExitGame();

		}
	}

}
