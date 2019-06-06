using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    Transform bulletSpawnPoint;
    Collider reloadZone;
    AudioSource reloadAudio;

    public Pistol other;
    public GameObject bulletPrefab;
    public AudioClip shot, empty;
    public float force = 500f, timeBetweenShots = 0.25f;
    public int clipSize = 12, bullets;
    public bool left;

    AudioSource aud;
    bool shoot = true;

    // Use this for initialization
    void Start() {
        bullets = clipSize;
        aud = GetComponent<AudioSource>();
        reloadAudio = GameObject.Find("Mgr").GetComponent<AudioSource>();
        bulletSpawnPoint = transform.Find("Bullet Spawner");
        reloadZone = GameObject.Find("Reload Zone").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {
        var controller = OVRInput.GetConnectedControllers();
        if (shoot && ((!left && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)
            || (left && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))))
            StartCoroutine(TriggerPull(timeBetweenShots));
    }

    IEnumerator TriggerPull(float timeBetweenShots) {
        shoot = false;
        if (bullets != 0) {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        } else {
            Empty();
            yield return new WaitForSeconds(timeBetweenShots);
        }
        shoot = true;
    }

    private void Shoot() {
        Debug.Log("shoot " + bullets);
        bullets--;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.localRotation);
        bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * force);
        aud.Play();
    }

    private void Empty() {
        if (aud.clip != empty)
            aud.clip = empty;
        aud.Play();
        if (!reloadZone.enabled)
            reloadZone.enabled = true;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "ReloadZone" && bullets == 0) {
            Reload();
        }

    }

    private void Reload() {
        reloadAudio.Play();
        bullets = clipSize;
        aud.clip = shot;

        if (other.bullets != 0)
            reloadZone.enabled = false;
    }
}
