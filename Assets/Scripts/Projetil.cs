using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    private Rigidbody2D rb;
    public float destruirApos;
    public float velocidade;
    private Vector2 moveDirection;

    public Inimigo target; //Recebe alvo do script PlayerController
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - transform.position).normalized * velocidade * Time.deltaTime;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destruirApos);
    }


}
