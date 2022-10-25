using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;

public class Classe : MonoBehaviour
{
    [Header("Nome da classe")]
    [Space(5)]
    public string nomeClasse;

    [Space(10)]
    [Header("Stats do personagem")]
    [Space(5)]
    public float health;
    public float shield;
    public float atackSpeed;
    public float moveSpeed;
    public float range;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
