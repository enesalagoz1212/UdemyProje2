using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject2.Uis
{
    public class TimeCounter : MonoBehaviour
    {
		TMPro.TMP_Text _text;
		float _currentTime;

		private void Awake()
		{
			_text = GetComponent<TMPro.TMP_Text>();
		}

		private void Update()
		{
			_currentTime += Time.deltaTime;
			_text.text = "Time :"+_currentTime.ToString("0");
		}
	}

}
