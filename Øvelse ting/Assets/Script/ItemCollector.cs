using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Grenades = 0;

    [SerializeField] private Text Grenade_count;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("grenades"))
        {
            string itemType = collision.gameObject.GetComponent<Utility>().itemType;

            collectionSoundEffect.Play();

            Destroy(collision.gameObject);

            Grenades++;
            Grenade_count.text = Convert.ToString(Grenades); 


        }

    }
}
