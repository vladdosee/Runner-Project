using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    public Spawner spawner;

    private void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Spawn")
        {
            spawner.Spawn();
        }
        if (collision.name == "Destroy")
        {
            Destroy(collision.transform.parent.gameObject);
        }

    }
}
