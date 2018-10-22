using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour {
	[Tooltip("asset ファイルのパスをプロジェクトからの相対パスで")]
	[SerializeField] string statusPath = "";
	Dictionary<string, EnemyStatus> enemies = new Dictionary<string, EnemyStatus>();

	void Awake() {
		// Load enemy datas
		string[] paths = Directory.GetFiles(statusPath, "*.asset", SearchOption.AllDirectories);

		foreach (string path in paths) {
			EnemyStatus enemy = AssetDatabase.LoadAssetAtPath<EnemyStatus>(path);
			if (enemy != null) {
				enemies[enemy.name] = enemy;
			}
		}
	}

	public GameObject MakeEnemy(string name) {
		if (!enemies.ContainsKey(name)) {
			Debug.LogError("Enemy name: " + name + " is not found.");
			return null;
		}
		var enemy = enemies[name];
		// Setup instance
		GameObject inst = Instantiate(enemy.model);
		switch (enemy.moveType) {
			case MoveType.A:
				inst.AddComponent<enemyinst_tipeA>();
				break;
			case MoveType.B:
				inst.AddComponent<enemyinst_tipeB>();
				break;
			case MoveType.C:
				inst.AddComponent<enemyinst_tipeC>();
				break;
		}
		//inst.AddComponent<Spawnable>();
		//inst.AddComponent<DeathTimer>();

		return inst;
	}
}