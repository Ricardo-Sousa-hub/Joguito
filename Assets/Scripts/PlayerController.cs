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

    // Start is called before the first frame update
    void Start()
    {
        personagens[classeSelecionada].SetActive(true);

        health = personagens[classeSelecionada].GetComponent<Classe>().health;
        shield = personagens[classeSelecionada].GetComponent<Classe>().shield;
        atackSpeed = personagens[classeSelecionada].GetComponent<Classe>().atackSpeed;
        moveSpeed = personagens[classeSelecionada].GetComponent<Classe>().moveSpeed;
        range = personagens[classeSelecionada].GetComponent<Classe>().range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
