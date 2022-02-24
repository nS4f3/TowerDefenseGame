
using UnityEngine;

public class TurretController : MonoBehaviour
{

    public static TurretController instance;


    public GameObject turretPreb;
    public Vector3 offset;

    public GameObject getTurret(){
        return turretPreb;
    }

    void Awake(){
        instance = this;
    }


}
