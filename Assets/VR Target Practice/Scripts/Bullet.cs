using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Target") {
            Target targ = collision.gameObject.GetComponent<Target>();
            targ.TargetHit();
            Destroy(this.gameObject);
        }

        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy() {
        yield return new WaitForSeconds(3);
        Destroy(this);
    }
}