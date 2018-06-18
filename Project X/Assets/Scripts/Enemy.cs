
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    private float wait = 2f;
    public NavMeshAgent enemy;
    public Transform target;

	// Use this for initialization
	void Start () {
        wait = 2f;
        enemy.SetDestination(target.transform.position + Vector3.left);
        enemy.isStopped = true;
        
	}

     void Update()
    {
      
        if (this.gameObject.transform.position.x <= target.transform.position.x)
        {

            die();
        }
       
       
        if (Mathf.Floor(wait) == 0f)
        {
            enemy.isStopped = false; ;
            wait = -1f;
        }
        if(wait > 0f)
        {
            wait -= Time.deltaTime;
        }
         

    }

    void die()
    {
        WaveSpawner.MobsAlive--;
        Destroy(this.gameObject);
    }

}
