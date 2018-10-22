using System;
using System.Collections;
using UnityEngine;

public enum MoveType {
	A,
	B,
	C,
}

[CreateAssetMenu]
public class EnemyStatus : ScriptableObject {
	public string name { get { return name; } }
	public GameObject model { get { return model; } }
    public MoveType moveType { get  { return MoveType.A; } }
    public float spawnTime  { get { return spawnTime; } }
	public float lifeDuration { get { return lifeDuration; } }

    [SerializeField]
    private object
    field_name;
    public object property_name
    {
        get { return this.field_name; }
        set { this.field_name = value; }
    }
    public GameObject a;
}