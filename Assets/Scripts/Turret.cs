using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private string enemyTag = "Enemy";

    [Header("Attributies")]

    public float range = 15f;
    public float rotationSpeed = 3f;
    public float fireRate = 0.1f;
    private float fireCountDown = 1f;

    [Header("Unity Setup Fields")]


    public Transform parttoRotate;
    public GameObject bulletPref;
    public Transform firePoint;

   




    void Start(){
        InvokeRepeating("UpdateTarget",0f,0.5f);


    }

    void UpdateTarget(){

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDis = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies){

            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < shortestDis){
                shortestDis = distance;
                nearestEnemy = enemy;

            }

        }

        if(nearestEnemy != null && shortestDis <= range){
            target = nearestEnemy.transform;

        }
        else{
            target = null;
            }

    }

    void Update(){
        if(target != null){
            Vector3 dir = target.position - transform.position;

            Quaternion lookRot = Quaternion.LookRotation(dir);

            Vector3 rotation = Quaternion.Lerp(parttoRotate.rotation,lookRot,Time.deltaTime * rotationSpeed).eulerAngles;

            parttoRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

            fireCountDown -= Time.deltaTime;
        }

        if(fireCountDown <= 0f && target != null){
            Shoot();
            fireCountDown = 1 / fireRate;

        }

        
    }

    void Shoot(){
        GameObject bull = (GameObject) Instantiate(bulletPref, firePoint.position,firePoint.rotation);
        Bullets bullet = bull.GetComponent<Bullets>();
        if(bullet != null){
            bullet.Seek(target);
        }
    }

    

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
