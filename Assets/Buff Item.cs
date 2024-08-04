using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItem : MonoBehaviour
{
    GameObject item;
    ///
    private void Awake()
    {
        item = GetComponent<GameObject>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) {
            Debug.Log("trigger");
            Destroy(item);
        }
        
    }
}
