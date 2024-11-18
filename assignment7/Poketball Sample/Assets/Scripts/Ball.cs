using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager GM;
    
    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerExit(Collider col)
    {
        // When ball falls through Hole
        if (col.gameObject.tag == "Hole" && transform.position.y < -1f)
        {
            GM.Fall(gameObject.name);
            Destroy(gameObject);
        }
    }
}
