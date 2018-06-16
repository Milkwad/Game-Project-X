
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public NavMeshAgent enemy;

    
    public GameObject target;

	// Use this for initialization
	void Start () {
        //Vector3 end = transform.position + Vector3.left * 10 ;
        enemy.SetDestination(target.transform.position);
        
	}

     void Update()
    {
        if (gameObject.transform.position.x == target.transform.position.x)
            Destroy(this.gameObject);

       
    }

}
