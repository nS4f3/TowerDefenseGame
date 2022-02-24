
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update

    public Color hovercolor;
    private Renderer rend;
    private Color baseColor;
    private bool isFull = false;

    void Awake(){
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;
    }
    
    
    void OnMouseEnter(){
    
        rend.material.color = hovercolor;    

    }
    void OnMouseExit(){
         rend.material.color = baseColor;

    }

    void OnMouseDown(){
        //instantiate a turret
        if(!isFull){
            GameObject tur = TurretController.instance.getTurret();
            tur = Instantiate(tur,transform.position + TurretController.instance.offset ,transform.rotation);
            isFull = true;
        }

    }

}
