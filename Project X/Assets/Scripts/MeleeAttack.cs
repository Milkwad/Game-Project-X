
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    private float ProjSpeed = 150f;
    private Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        //projectile logic
        Vector3 Direction = target.position - transform.position;
        float DistPerFrame = ProjSpeed * Time.deltaTime;
        
        //checks if projectile has hit
        if (Direction.magnitude <= DistPerFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(Direction.normalized * DistPerFrame, Space.World);

    }

    public void AttackTarget(Transform _target)
    {
        target = _target;
    } 

    void HitTarget()
    {
        target.GetComponent<Enemy>().die();
        Destroy(gameObject);
    }
}
