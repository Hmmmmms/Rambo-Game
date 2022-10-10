using System.Diagnostics;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class PlayerShoot : MonoBehaviour
{

    public float shootSpeed, shootTimer;
    
    private bool isShooting;

    public Transform shootPos;
    public GameObject Player_bullet;

    [SerializeField] private AudioSource shootingSoundEffect;

    void Start()
    {
        isShooting = false;
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting )
        {
            StartCoroutine(Shoot());
            shootingSoundEffect.Play();
        }
    }

    public int direction_bullet()
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

    IEnumerator Shoot()
    {
        

        isShooting = true;
        GameObject newPlayer_bullet = Instantiate(Player_bullet, shootPos.position, Quaternion.identity);
        newPlayer_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction_bullet() * Time.fixedDeltaTime, 0f);
        newPlayer_bullet.transform.localScale = new Vector2(newPlayer_bullet.transform.localScale.x * direction_bullet(), newPlayer_bullet.transform.localScale.y);

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
