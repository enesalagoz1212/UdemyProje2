using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.ScriptableObjects;
using UdemyProject2.Managers;

namespace UdemyProject2.Controllers
{
    public class LevelInitializerController : MonoBehaviour
    {
        LevelDifficultyData _levelDifficultyData;

		private void Awake()
		{
			_levelDifficultyData = GameManager.Instance.LevelDifficultyData;
		}
		private void Start()
		{
			RenderSettings.skybox = _levelDifficultyData.skyboxMaterial;
			Instantiate(_levelDifficultyData.FloorPrefab);
			Instantiate(_levelDifficultyData.SpawnerPrefab);
			EnemyManager.Instance.SetMoveSpeed(_levelDifficultyData.MoveSpeed);
			EnemyManager.Instance.SetAddDelayTime(_levelDifficultyData.AddDelayTime);
		}
	}

}
