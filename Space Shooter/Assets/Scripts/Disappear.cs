using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public GameObject bang;
    public GameObject playerBang;

    GameObject GameControl;
    GameControl control;

    void Start()
    {
        GameControl = GameObject.FindGameObjectWithTag("GameControl");
        control = GameControl.GetComponent<GameControl>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Boundary")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(bang, transform.position, transform.rotation);
            if (col.tag != "Player")
            {
                control.Score(10);
            }
            
        }

        if (col.tag == "Player")
        {
            Instantiate(playerBang, col.transform.position, col.transform.rotation);
            control.GameOver();
        }
       
    }
}
