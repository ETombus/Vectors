using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDown : MonoBehaviour
{
    public ParticleSystem explosion;
    void OnCollisionEnter2D(Collision2D hit)
    {
        var sfx = gameObject.GetComponent<AudioSource>();
        sfx.pitch = Random.Range(1f, 3f);
        sfx.Play();

        if(hit.gameObject.CompareTag("Peg"))
            gameObject.transform.localScale = gameObject.transform.localScale *= 0.75f;

        if(gameObject.transform.localScale.magnitude <= 0.75f)
        {
            GameObject.Find("AudioPlayer").GetComponent<AudioSource>().Play();
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 0.01f);
        }
    }
}
