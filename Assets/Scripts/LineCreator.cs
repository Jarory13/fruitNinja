﻿using UnityEngine;
using System.Collections;

public class LineCreator : MonoBehaviour {

    int vertexCount = 0;
    bool mouseDown = false;
    LineRenderer line;
    public GameObject blast;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void Update()
    {

        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.touchCount > 0)
            {
                mouseDown = true;
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    drawlinw();
                }

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    stopLine();
                }

            }


        }
        else {

            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = true;
            }

            drawlinw();

            if (Input.GetMouseButtonUp(0))
            {
                stopLine();
            }

        }
    }

    private void drawlinw() {
        if (mouseDown)
        {
            line.SetVertexCount(vertexCount + 1);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.SetPosition(vertexCount, mousePos);
            vertexCount++;

            BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
            box.transform.position = line.transform.position;
            box.size = new Vector2(0.1f, 0.1f);
        }
    }

    private void stopLine() {
       
            mouseDown = false;
            vertexCount = 0;
            line.SetVertexCount(0);
            BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

            foreach (BoxCollider2D box in colliders)
            {
                Destroy(box);
            }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bomb") {
            GameObject b = Instantiate(blast, col.transform.position, Quaternion.identity) as GameObject;
            Destroy(b.gameObject, 5f);
            Destroy(col.gameObject);
            GameManager.instance.gameOver = true;
            GameManager.instance.GameOver();
            ScoreManager.instance.gameOver();
        }
    }


}
