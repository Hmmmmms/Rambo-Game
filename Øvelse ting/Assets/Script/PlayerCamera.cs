using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
        public Transform Player;
        public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

// Update is called once per frame
void Update()
{
    transform.position = player.transform.position + new Vector3(0, 0, -10);
}
}
