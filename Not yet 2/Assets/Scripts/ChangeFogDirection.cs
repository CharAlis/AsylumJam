using UnityEngine;
using System.Collections;

public class ChangeFogDirection : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fog") {
            col.gameObject.GetComponent<FogMovement>().multiplier *= -1;
            StartCoroutine(DeadTime(col.gameObject));
        }
    }

    IEnumerator DeadTime(GameObject obj)
    {
        obj.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(30f);
        obj.GetComponent<BoxCollider2D>().enabled = true;
		obj.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return null;
    }
}
