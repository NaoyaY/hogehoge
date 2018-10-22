using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyinst_tipeA : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemy;
    Transform[] pos_enemys = new Transform[3];

    public void Start()
    {
        respoun();
        lookplayer();
    }

    public void Update()
    {
        movement();
        lookplayer();
    }

    public void respoun()
    {
        for (int i = 0; i < 3; i++)
        {
            pos_enemys[i] = Instantiate(enemy).transform;
        }
    }

    public void movement()
    {
        foreach (Transform movement in pos_enemys)
        {
            movement.transform.position += movement.transform.forward * 0.02f;
        }
    }

    void lookplayer()
    {
        float distance_eachenemy = 2f;
        pos_enemys[0].LookAt(player);
        Vector3 tmppos = pos_enemys[0].position;
        pos_enemys[0].position = new Vector3(tmppos.x, tmppos.y, tmppos.z);
        pos_enemys[1].position = pos_enemys[0].forward * -1.732f * distance_eachenemy + pos_enemys[0].right * 1f * distance_eachenemy;
        pos_enemys[2].position = pos_enemys[0].forward * -1.732f * distance_eachenemy + pos_enemys[0].right * 1f * -distance_eachenemy;

    }
}
