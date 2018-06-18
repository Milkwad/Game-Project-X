using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    private float TimeNextWave = 11f;
    private int WaveRound = 1;
    public Text waveCountdownText;

    public Transform SpawnPoint;
    public Transform mobPrefab;
    public List<Transform> MobList;
    public int MobsToSpawn = 20;

    public static int MobsAlive = 0;

    // Update is called once per frame

    private void Start()
    {
        SpawnWave();
    }
    void Update()
    {
        //Debug.Log(MobsAlive);

        if(MobsAlive <= 0)
        {
            TimeNextWave -= Time.deltaTime;
            
            waveCountdownText.text = Mathf.Floor(TimeNextWave).ToString();

        }
        if (TimeNextWave <= 1f)
        {
            SpawnWave();
            TimeNextWave = 11f;
        }

       



    }



    void SpawnWave()
    {
        MobList = new List<Transform>();
        for (int i = 0; i < MobsToSpawn; i++)
        {
            if (i < MobsToSpawn/2)
            {
                Transform mob = (Transform)Instantiate(mobPrefab, SpawnPoint.position + new Vector3(1, 1, i), SpawnPoint.rotation);
                mob.transform.parent = transform;
                MobList.Add(mob);
            }
            else
            {
                Transform mob = (Transform)Instantiate(mobPrefab, SpawnPoint.position + new Vector3(-1.0f, 1, i-10), SpawnPoint.rotation);
                mob.transform.parent = transform;
                MobList.Add(mob);
               
            }
           
        }
        MobsAlive = MobList.Count;
        WaveRound++;
    }
}
