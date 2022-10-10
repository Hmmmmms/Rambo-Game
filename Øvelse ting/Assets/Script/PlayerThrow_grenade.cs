using System.Diagnostics;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class PlayerThrow_grenade : MonoBehaviour
{

    public float ThrowSpeed_x, ThrowSpeed_y, ThrowTimer;

    private bool isThrowing;

    public Transform ThrowPos;
    public GameObject Player_grenade;

    void Start()
    {
        isThrowing = false;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !isThrowing)
        {
            StartCoroutine(Throw());

        }


    }

    IEnumerator Throw()
    {
        int direction()
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }

        isThrowing = true;
        GameObject newPlayer_grenade = Instantiate(Player_grenade, ThrowPos.position, Quaternion.identity);
        newPlayer_grenade.GetComponent<Rigidbody2D>().velocity = new Vector2(ThrowSpeed_x * direction() * Time.fixedDeltaTime, ThrowSpeed_y * Time.fixedDeltaTime);
        newPlayer_grenade.transform.localScale = new Vector2(newPlayer_grenade.transform.localScale.x * direction(), newPlayer_grenade.transform.localScale.y);

        yield return new WaitForSeconds(ThrowTimer);
        isThrowing = false;
    }
}
