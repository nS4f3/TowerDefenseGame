
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
   
   public Transform enemyPref;
   public Transform spawnpoint;
   public Text countText;

   public float timeWave = 20f;

   private float countDown = 3f;
   private int wavenum = 0;





   void Update(){

       if(countDown <= 0f) {
           StartCoroutine(Spawn());
           countDown = timeWave;

       }

       countDown -= Time.deltaTime;
       countText.text = Mathf.Floor(countDown).ToString();



   }

   IEnumerator Spawn(){

        wavenum++;
        for(int i = 0; i < wavenum ; i++){
           SpawnEnemy();
           yield return new WaitForSeconds(1f);
       }

      



   }


    void SpawnEnemy(){

        Instantiate(enemyPref,spawnpoint.position,spawnpoint.rotation);

    }
}
