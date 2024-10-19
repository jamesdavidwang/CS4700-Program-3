using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonscript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;

    private GameObject bulletClone;
    float timeBetween;
    public float startTimeBetween;
    // Start is called before the first frame update
    void Start()
    {
        timeBetween = startTimeBetween;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetween <=0){
            
            if(bulletClone != null){
                Destroy(bulletClone);
            }

            bulletClone = Instantiate(bullet, firepoint.position, firepoint.rotation);
            
            timeBetween = startTimeBetween;
        }
        else{
            timeBetween -= Time.deltaTime;
        }
    }
}
