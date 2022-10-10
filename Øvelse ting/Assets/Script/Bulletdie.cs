using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class Bulletdie : MonoBehaviour
{
    
    public float dieTime;

    private Transform Bullet;

    

    public GameObject dieEffect;

    // Reference from player shoot script
    

    void Start()
    {
        Bullet = GetComponent<Transform>();

       
    }


    void Update()
    {
        Destroy(gameObject, dieTime);


    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag != "Bullet")
        {
            Die();
        }



        


        int direction()
            {
                if (Bullet.localScale.x < 0f)
                {
                    return +1;
                }
                else
                {
                    return -1;
                }
            }


        void Die()
        {
              

            if (dieEffect != null)
            {
                print(direction());
                GameObject newdieEffect = Instantiate(dieEffect, transform.position, Quaternion.identity);
                newdieEffect.transform.localScale = new Vector2(newdieEffect.transform.localScale.x * direction(), newdieEffect.transform.localScale.x);
                
                

            }
            

            Destroy(gameObject);

            
        }
    }
}
