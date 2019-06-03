using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

    public Pistol other;
    public Transform spawnPoint;
    public Collider reloadZone;
    public Rigidbody bulletPrefab;
    public AudioSource reload;
    public AudioClip shot, empty;
    public float force = 500f, timeBetweenShots = 0.25f;
    public int clipSize = 12, bullets;

    AudioSource aud;
    bool shoot = true;

	// Use this for initialization
	void Start () {
        bullets = clipSize;
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        var controller = OVRInput.GetConnectedControllers();
        if (shoot && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
            StartCoroutine(TriggerPull(timeBetweenShots));
	}

    IEnumerator TriggerPull(float timeBetweenShots)
    {
        shoot = false;
        if (bullets != 0)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
        else
        {
            Empty();
            yield return new WaitForSeconds(timeBetweenShots);
        }
        shoot = true;
    }

    private void Shoot()
    {
        bullets--;
        Rigidbody bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.localRotation);
        bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * force);
        aud.Play();

    }

    private void Empty()
    {
        if (aud.clip != empty)
            aud.clip = empty;

        aud.Play();

        if (!reloadZone.enabled)
            reloadZone.enabled = true;
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ReloadZone" && bullets == 0)
        {
            Reload();
        }
    }

    private void Reload()
    {
        reload.Play();
        bullets = clipSize;
        aud.clip = shot;

        if(other.bullets != 0)
            reloadZone.enabled = false;
    }

}
