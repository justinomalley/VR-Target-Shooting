using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

    public int type; //0 for front, 1 for middle, 2 for back
    bool spawn = true;

    float secBetweenSpawns;
    public GameObject target;
    public GameManager mgr;
	
	// Update is called once per frame
	void Update () {
        if (spawn)
            StartCoroutine(SpawnTarget());
	}

    public IEnumerator SpawnTarget()
    {
        spawn = false;
        Target targ = Instantiate(target, transform.position, target.transform.rotation).GetComponent<Target>();
        targ.type = type;
        yield return new WaitForSeconds(secBetweenSpawns);
        spawn = true;
        
    }

    public void SetSpawnTime(float seconds) {
        secBetweenSpawns = seconds;
    }
}
