using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;

    private int pointindex = 0;



    void Start(){
        target = WavePoints.points[0];
    }
    void Update(){

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f){
            NextPoint();

        }
    }

    void NextPoint(){
        if(pointindex >= WavePoints.points.Length -1 ){
            Destroy(gameObject);
            return;
        }

        pointindex++;
        target = WavePoints.points[pointindex];
    }


}
