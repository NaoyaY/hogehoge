using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyinst_tipeC : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemy;
    Transform[] pos_enemyclones = new Transform[10];
    const float fromplayerdis_min = 5f;
    const float fromplayerdis_max = 10f;

    // Use this for initialization
    void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            pos_enemyclones[i] = Instantiate(enemy).transform;
            posrandom(pos_enemyclones[i]);
        }
    }


    void posrandom(Transform pos_enemyclones_)
    {
        float[] enemyclones_vec = new float[3] { 0, 0, 0 };
        for (int i = 0; i < 3; i++)
        {
            while (Mathf.Abs(enemyclones_vec[i]) < fromplayerdis_min)
            {
                enemyclones_vec[i] = Random.Range(-fromplayerdis_max, fromplayerdis_max);
            }
            i++;
        }
        pos_enemyclones_.transform.position = new Vector3(player.position.x + enemyclones_vec[0], player.position.y + enemyclones_vec[1], player.position.z + enemyclones_vec[2]);
    }
}

