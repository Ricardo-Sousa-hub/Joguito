using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Classes")]
    [Space(5)]
    public List<Classe> classes;
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
        health = classes[classeSelecionada].health;
        shield = classes[classeSelecionada].shield;
        atackSpeed = classes[classeSelecionada].atackSpeed;
        moveSpeed = classes[classeSelecionada].moveSpeed;
        range = classes[classeSelecionada].range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
