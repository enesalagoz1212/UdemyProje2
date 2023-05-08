using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Controllers;

namespace UdemyProject2.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty/Create New", order = 1)]
	public class LevelDifficultyData : ScriptableObject
	{
		[SerializeField] FloorController _floorPrefab;
		[SerializeField] GameObject _spawnersPrefab;
		[SerializeField] Material _skyboxMaterial;
		[SerializeField] float _moveSpeed = 10f;
		[SerializeField] float _addDelayTime = 50;
		public FloorController FloorPrefab => _floorPrefab;
		public GameObject SpawnerPrefab => _spawnersPrefab;
		public Material skyboxMaterial => _skyboxMaterial;
		public float MoveSpeed => _moveSpeed;
		public float AddDelayTime => _addDelayTime;
	}
	

}

