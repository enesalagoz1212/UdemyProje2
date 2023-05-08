using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Abstracts.Utilities;
using UnityEngine.SceneManagement;
using UdemyProject2.ScriptableObjects;

namespace UdemyProject2.Managers
{
	public class GameManager : SingletonMonoBehaviorObject<GameManager>
	{
		[SerializeField] LevelDifficultyData[] _levelDifficultyDatas;

		public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[DifficultyIndex];
		int _difficultyIndex;
		public int DifficultyIndex 
		{
			get => _difficultyIndex;
			set
			{
				if (_difficultyIndex<0|| _difficultyIndex> _levelDifficultyDatas.Length)
				{
					LoadSceneAsync("Menu");
				}
				else
				{
					_difficultyIndex = value;
				}
			}
		}
		public event System.Action OnGameStop;
		
		private void Awake()
		{
			SingletonThisObject(this);
		}

		public void StopGame()
		{
			Time.timeScale = 0f;

			//if (OnGameStop!=null)
			//{
			//	OnGameStop();
			//}

			OnGameStop?.Invoke();
		}
		public void LoadScene(string sceneName)
		{
			
			StartCoroutine(LoadSceneAsync(sceneName));
		}
		private IEnumerator LoadSceneAsync(string sceneName)
		{
			Time.timeScale = 1f;
			yield return SceneManager.LoadSceneAsync(sceneName);
		}
		public void ExitGame()
		{
			Debug.Log("Exit on click");
			Application.Quit();
		}
	}
}

