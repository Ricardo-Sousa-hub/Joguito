using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Nome do inimigo")]
    [Space(5)]
    public string nomeClasse;

    [Space(10)]
    [Header("Stats do inimigo")]
    [Space(5)]
    public float health;
    public float shield;
    public float atackSpeed;
    public float moveSpeed;
    public float range;

    public Animator anim;

    private GameObject player;
    private float distancia;
    public float distanciaStop;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        distancia = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direcao = player.transform.position - transform.position;
        direcao.Normalize();
        //float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

        if(distancia > distanciaStop)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angulo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
