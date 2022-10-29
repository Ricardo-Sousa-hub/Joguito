using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Classes")]
    [Space(5)]
    public List<GameObject> personagens;
    public int personagemSelecionada;

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

    private float lastShot = 0.0f;
    private List<GameObject> ataques;
    public GameObject firePoint;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        switch (personagemSelecionada)
        {
            case 0:
                rb.mass = 50;
                break;
            case 1:
                rb.mass = 90;
                break;
            case 2:
                rb.mass = 50;
                break;
        }

        personagens[personagemSelecionada].SetActive(true);

        ataques = personagens[personagemSelecionada].GetComponent<Classe>().ataques;

        health = personagens[personagemSelecionada].GetComponent<Classe>().health;
        shield = personagens[personagemSelecionada].GetComponent<Classe>().shield;
        atackSpeed = personagens[personagemSelecionada].GetComponent<Classe>().atackSpeed;
        moveSpeed = personagens[personagemSelecionada].GetComponent<Classe>().moveSpeed;
        range = personagens[personagemSelecionada].GetComponent<Classe>().range;

        anim = personagens[personagemSelecionada].GetComponent<Classe>().anim;
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
            if (Time.time > atackSpeed + lastShot && GameObject.FindObjectOfType<Inimigo>())
            {
                Inimigo inimigo = ProcuraInimigoMaisProximo();

                GameObject disparo = Instantiate(ataques[0], firePoint.transform.position, CalcularAnguloDeProjetil(inimigo));
                disparo.GetComponent<Projetil>().target = inimigo;
                lastShot = Time.time;
            }
            anim.SetBool("Inimigo", true);
        }
        else
        {
            anim.SetBool("Inimigo", false);
        }
    }

    Inimigo ProcuraInimigoMaisProximo()
    {
        Inimigo[] inimigos = GameObject.FindObjectsOfType<Inimigo>();

        float dist = Vector2.Distance(transform.position, inimigos[0].transform.position);
        Inimigo maisProx = inimigos[0];

        for (int i = 1; i < inimigos.Length; i++)
        {
            if (Vector2.Distance(transform.position, inimigos[i].transform.position) < dist)
            {
                dist = Vector2.Distance(transform.position, inimigos[i].transform.position);
                maisProx = inimigos[i];
            }
        }
        return maisProx;
    }

    Quaternion CalcularAnguloDeProjetil(Inimigo inimigo)
    {
        Inimigo target = inimigo;
        Vector2 dir = target.transform.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        return Quaternion.AngleAxis(angle, Vector3.forward);

    }


    void Virar()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        if (moveX < 0 && !esq)
        {
            personagens[personagemSelecionada].transform.RotateAround(transform.position, transform.up, 180f);
            esq = true;
        }
        else if (moveX > 0 && esq)
        {
            personagens[personagemSelecionada].transform.RotateAround(transform.position, transform.up, 180f);
            esq = false;
        }
    }
}
