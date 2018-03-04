using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour {

    private Transform grenade;
    //public float speed;
    //public GameObject player;
    public bool GrenadeTimer;
    public GameObject explosionGo;
    public Camera cam;
    private float shake = 0;
    private float shakeamount = 0.3f;
    private float decreaserate = 3;


    void Start ()

    {
        cam = FindObjectOfType<Camera>();
        shake = 1.2f;
        
        Collider2D[] enemiesOnScreen = Physics2D.OverlapBoxAll(cam.ScreenToWorldPoint(new Vector2(Screen.width/2f, Screen.height/2f)), 
                                                               new Vector2(30, 12), 0); //rough equivalent of screen size
        
        for (int i = 0; i < enemiesOnScreen.Length; i++)
        {
            if (enemiesOnScreen[i].gameObject.CompareTag("Enemy"))
            {
                Destroy(enemiesOnScreen[i].gameObject);
                playExplosion(enemiesOnScreen[i].gameObject);
                ScoreManager.AddScore(2);
                
            }
            
        }
                


    

    }
    
    void playExplosion(GameObject g)
    {
        GameObject explosion = (GameObject) Instantiate(explosionGo);
        explosion.transform.position = g.transform.position;
    }

    private void FixedUpdate()
    {
        if (shake > 0)
        {
            cam.transform.localPosition = Random.insideUnitCircle * shakeamount;
            shake -= Time.fixedDeltaTime * decreaserate;

        }

        if (shake <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }

    // Use this for initialization
    /*void Start ()
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
    
    */
}
