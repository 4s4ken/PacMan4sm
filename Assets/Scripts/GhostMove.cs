using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    int pos = 0;
    public float speed = 0.3f;
  //  
    void FixedUpdate()
    {
       

        if (transform.position.ToString().Equals(waypoints[pos].position.ToString()))            
            pos = (pos + 1) % waypoints.Length;

        else
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[pos].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }

        Vector2 dir = waypoints[pos].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);

    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            Destroy(co.gameObject);
            GameObject.Find("game").GetComponent<GhostMove>().speed = 100f;
            // GameObject.Find("gg").GetComponent<GhostMove>().speed = 100f;
            GameObject.Find("Ghost4").GetComponent<GhostMove>().speed = 0.0f;
             GameObject.Find("Ghost1").GetComponent<GhostMove>().speed = 0.0f;
             GameObject.Find("Ghost3").GetComponent<GhostMove>().speed = 0.0f;
             GameObject.Find("Ghost2").GetComponent<GhostMove>().speed = 0.0f;
            //   GetComponent<Image>().sprite = Resources.Load<Sprite>(name);
           /* pos = -1;
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[pos].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);*/

        }
    }
}

