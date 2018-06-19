using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    private float TimeNextWave = 11f;
    private int WaveRound = 1;
    public Text waveCountdownText;

    public Transform SpawnPoint;
    public GameObject mobPrefab;
    public List<GameObject> MobList;
    public int MobsToSpawn;

    public static int MobsAlive = 0;

    // Update is called once per frame

    private void Start()
    {
        SpawnWave();
    }
    void Update()
    {
        if(MobsAlive > 0)
        {
            waveCountdownText.GetComponent<Text>().enabled = false;
            return;
        }       

        if (TimeNextWave <= 1f)
        {
            SpawnWave();
            TimeNextWave = 11f;
        }

        TimeNextWave -= Time.deltaTime;
        waveCountdownText.GetComponent<Text>().enabled = true;
        waveCountdownText.text = Mathf.Floor(TimeNextWave).ToString();

    }


    void SpawnWave()
    {
        MobList = new List<GameObject>();
        for (int i = 0; i < MobsToSpawn; i++)
        {
            if (i < MobsToSpawn/2)
            {
                GameObject mob = (GameObject)Instantiate(mobPrefab, SpawnPoint.position + new Vector3(1, 1, i), SpawnPoint.rotation);
                mob.transform.parent = transform;
                MobList.Add(mob);
            }
            else
            {
                GameObject mob = (GameObject)Instantiate(mobPrefab, SpawnPoint.position + new Vector3(-1.0f, 1, i-MobsToSpawn/2), SpawnPoint.rotation);
                mob.transform.parent = transform;
                MobList.Add(mob);
               
            }
           
        }
        MobsAlive = MobList.Count;
        WaveRound++;
    }
}
