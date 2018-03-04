using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour {

    private Transform grenade;
    public float speed;
    public GameObject player;
    public bool GrenadeTimer;

    // Use this for initialization
    void Start ()
    {

        grenade = GetComponent<Transform>();
        StartCoroutine(ActivateGrenade());
        GrenadeTimer = false;

    }

    void FixedUpdate()
    {
        grenade.position += Vector3.up * speed;

        if (grenade.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (GrenadeTimer == false && other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(DestructGrenade());
            GrenadeTimer = true;
        }
       
    }

    IEnumerator ActivateGrenade()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.01f);
        GetComponent<Collider2D>().enabled = true;
    }
    
    IEnumerator DestructGrenade()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
