using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{

    public GameBehaviour gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
        if(gameManager == null)
        {
            Debug.LogError("Game Manager not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.transform.gameObject);
            gameManager.Items += 1;
        }
    }
}
