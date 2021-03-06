using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    private Transform target;
    public GameObject impactEffect;



    public float speed = 18f;

    

    public void Seek(Transform _target){
        target = _target;


    }
    

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;


        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);


        
    }

    void HitTarget(){

        GameObject eff = (GameObject)Instantiate(impactEffect, transform.position,transform.rotation);

        Destroy(eff,1f);
        Destroy(target.gameObject);
        Destroy(gameObject);

        

    }
}
