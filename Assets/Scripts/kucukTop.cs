﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kucukTop : MonoBehaviour
{
    LineRenderer cizgi;

    bool durduMu = false;
    Rigidbody2D rgb;
    Transform anaDaire;

    Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        cizgi = GetComponent<LineRenderer>();
        rgb = GetComponent<Rigidbody2D>();
        anaDaire = GameObject.Find("kure").transform;
        manager = GameObject.FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (durduMu)
        {
            cizgi.SetPosition(0, anaDaire.position);
            cizgi.SetPosition(1, transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == anaDaire.name)
        {
            rgb.velocity = Vector2.zero;
            Vector2 yeniPos = transform.position;

            yeniPos.y = (anaDaire.transform.position.y - anaDaire.GetComponent<CircleCollider2D>().bounds.size.y )* 1.5f;
            transform.position = yeniPos;
            transform.SetParent(anaDaire.transform);
            durduMu = true;
            manager.ToplarinPozisyonlariniGuncelle();
        }

        else if(collision.gameObject.tag == "top")
        {
            manager.Kaybettin();
        }
    }
}
