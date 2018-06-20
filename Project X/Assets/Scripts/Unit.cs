using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public Transform target;
    private string Mobtag = "mob";
    public float Range;
    public float Cooldown;
    private float lastAttack;
    public GameObject Projectile;
    public Transform AttackOrigin;
    //public WaveSpawner WS;

    // Use this for initialization
    void Start () {
        lastAttack = Time.time - Cooldown;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (target == null)
        {
            return;
        }
        
        
        if (Time.time - lastAttack <= Cooldown)
        {
            return;
        }
        if(Time.time - lastAttack >= Cooldown)
        {
            Attack();
            lastAttack = Time.time;
        }
       


    }

    void UpdateTarget()
    {
        //WS = GetComponent<WaveSpawner>();
        float ShortestDist = Mathf.Infinity;
        GameObject NearestMob = null;
        GameObject[] Moblist = GameObject.FindGameObjectsWithTag("mob");
      
       
        foreach (GameObject Mob in Moblist)
        {
            float DistToMob = Vector3.Distance(transform.position, Mob.transform.position);
            if(DistToMob < ShortestDist)
            {
                ShortestDist = DistToMob;
                NearestMob = Mob;
            }

            if(NearestMob != null && ShortestDist <= Range)
            {
                target = NearestMob.transform;
            }
            else
            {
                target = null;
            }
        }

    }
    
    void Attack()
    {
        GameObject AttackProjectile = (GameObject)Instantiate(Projectile, AttackOrigin.position, AttackOrigin.rotation);
        AttackProjectile.transform.SetParent(transform);
        MeleeAttack Attack = AttackProjectile.GetComponent<MeleeAttack>();

        if(Attack != null)
        {
            Attack.AttackTarget(target);
        }
    
    }
    //shows range radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
