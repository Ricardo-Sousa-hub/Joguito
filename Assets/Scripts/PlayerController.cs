using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Classes")]
    [Space(5)]
    public List<GameObject> personagens;
    public int classeSelecionada;

    [Space(10)]
    [Header("Stats do personagem")]
    [Space(5)]
    public float health;
    public float shield;
    public float atackSpeed;
    public float moveSpeed;
    public float range;

    public bool esq = false;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        personagens[classeSelecionada].SetActive(true);

        health = personagens[classeSelecionada].GetComponent<Classe>().health;
        shield = personagens[classeSelecionada].GetComponent<Classe>().shield;
        atackSpeed = personagens[classeSelecionada].GetComponent<Classe>().atackSpeed;
        moveSpeed = personagens[classeSelecionada].GetComponent<Classe>().moveSpeed;
        range = personagens[classeSelecionada].GetComponent<Classe>().range;

        anim = personagens[classeSelecionada].GetComponent<Classe>().anim;
    }

    // Update is called once per frame
    void Update()
    {
        Virar();
        Atacar();
    }

    void Atacar()
    {
        if (GameObject.FindGameObjectWithTag("Inimigo"))
        {
            anim.SetBool("Inimigo", true);
        }
        else
        {
            anim.SetBool("Inimigo", false);
        }
    }

    void Virar()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        if (moveX < 0 && !esq)
        {
            personagens[classeSelecionada].transform.RotateAround(transform.position, transform.up, 180f);
            esq = true;
        }
        else if (moveX > 0 && esq)
        {
            personagens[classeSelecionada].transform.RotateAround(transform.position, transform.up, 180f);
            esq = false;
        }
    }
}
