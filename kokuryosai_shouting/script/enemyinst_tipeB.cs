using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyinst_tipeB : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemy;
    GameObject clone_enemy;
    Renderer rendenemy;

    private struct appear_status
    {
        public bool isappear;
        public float appeartime;
    }

    // Use this for initialization
    void Start()
    {
        respoun();
        rendenemy = clone_enemy.GetComponent<Renderer>();
    }


    // Update is called once per frame
    public float frominsttime = 0;
    void FixedUpdate()
    {
        frominsttime += Time.fixedDeltaTime;
        moving();
        appear();
    }

    void respoun()
    {
        clone_enemy = Instantiate(enemy);
    }

    const float enemypos_y = 5;
    void moving()
    {
        float playerpos_x = player.transform.position.x;
        float playerpos_z = player.transform.position.z;
        float Toangle = 50 * frominsttime * Mathf.PI / 180;
        clone_enemy.transform.position = new Vector3(playerpos_x + 10 * Mathf.Sin(Toangle), enemypos_y, playerpos_z + 10 *  Mathf.Cos(Toangle));
    }

    int list_arraynum = 0;
    float appeartime_tmp = 0f;
    const float appeartime_same = 0.5f;
     void appear()
    {
        var appearlist = new List<appear_status>() {
            new appear_status{ isappear = true,appeartime = appeartime_same },
            new appear_status{ isappear = false,appeartime = appeartime_same },
            new appear_status{ isappear = true,appeartime = appeartime_same},
            new appear_status{ isappear = false,appeartime = appeartime_same },
            new appear_status{ isappear = true,appeartime = appeartime_same},
            new appear_status{ isappear = false,appeartime = appeartime_same },
            new appear_status{ isappear = true,appeartime = 3 }
        };

        if(list_arraynum < appearlist.Count-1)
        {
            if (frominsttime - appearlist[0].appeartime > appeartime_tmp)
            {
                appeartime_tmp += appearlist[list_arraynum].appeartime;
                list_arraynum++;
            }
            rendenemy.enabled = appearlist[list_arraynum].isappear;
        }

    }
}
