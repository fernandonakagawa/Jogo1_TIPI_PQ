using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public float velocidade;
    public float tempoPulo;
    private float tempoPulado;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = this.transform.position;
            //pos.x = pos.x + velocidade;
            pos.x += velocidade;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = this.transform.position;
            //pos.x = pos.x + velocidade;
            pos.x -= velocidade;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.W) && tempoPulado <= 0)
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 forca = new Vector2(0f, 10f);
            rb.AddForce(forca, ForceMode2D.Impulse);
            tempoPulado = tempoPulo;
        }
        //Debug.Log(Time.deltaTime);
        tempoPulado -= Time.deltaTime;
    }

}

