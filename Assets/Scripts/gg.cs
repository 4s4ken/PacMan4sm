using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gg : MonoBehaviour
{
    public Transform[] waypoints;
    int pos = 0;
    public float speed = 0.3f;
    //  GameObject.Find("gg").GetComponent<GhostMove>().speed = 0.01f;
    void FixedUpdate()
    {


        if (transform.position.ToString().Equals(waypoints[pos].position.ToString()))
            pos = (pos + 1) % waypoints.Length;

        else
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[pos].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }

    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            GameObject.Find("game").GetComponent<GhostMove>().speed = 100f;


        }
    }
}

