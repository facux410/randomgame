using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnfire : MonoBehaviour
{
    fueguito fire;
    public float countfire;
    public float spawntimefire;
    public GameObject firesito;
    BOSS boss;
    public Transform posfires;

    private void Start()
    {
        boss = FindObjectOfType<BOSS>();
        fire = FindObjectOfType<fueguito>();
    }

    void Countfires()
    {
        if (!boss.fires[0] && !boss.fires[1] && !boss.fires[2] && !boss.fires[3] && !boss.fires[4] && !boss.fires[5])
            spawntimefire += Time.deltaTime;

        if (spawntimefire >= 11)
            spawntimefire = 0;
        
    }
    /*void Spawntime()
    {
        if (countfire >= 10)
            spawntimefire += Time.deltaTime;

        if (!boss.fires[0] && !boss.fires[1]&&!boss.fires[2] && !boss.fires[3] && !boss.fires[4] && !boss.fires[5] && countfire >= 20 && spawntimefire >= 10)
        {
            
            countfire = 0;
            spawntimefire = 0;
        }

    }*/
    void Update()
    {
        
        Countfires();
    }
}
