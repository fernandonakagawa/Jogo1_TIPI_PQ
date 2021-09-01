using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject protagonista;
    public float velocidade;

    private Vector3 posicaoProtagonista;
    private SpriteRenderer sprite;
    
    void Start()
    {
        posicaoProtagonista = protagonista.transform.position;
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(posicaoProtagonista.x < this.transform.position.x)
        {
            Andar(false);
        }
        else if(posicaoProtagonista.x > this.transform.position.x)
        {
            Andar(true);
        }
        posicaoProtagonista = protagonista.transform.position;
    }

    public void Andar(bool andandoParaFrente)
    {
        if (andandoParaFrente)
        {
            sprite.flipX = false;
            Vector3 pos = this.transform.position;
            pos.x += velocidade;
            this.transform.position = pos;
        }
        else
        {
            sprite.flipX = true;
            Vector3 pos = this.transform.position;
            pos.x -= velocidade;
            this.transform.position = pos;
        }
    }
}
