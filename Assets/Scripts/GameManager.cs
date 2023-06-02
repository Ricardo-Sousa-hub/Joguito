using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> inimigos;

    public float intervaloDeSpawn = 3f;

    public float x;
    public float y;

    private float lastX = 0;
    private float lastY = 0;

    private GameObject player;
    public Image healthBar;
    public Image caraPersonagem;
    private float health;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(intervaloDeSpawn, inimigos[0]));
        player = GameObject.FindGameObjectWithTag("Player");
        maxHealth = player.GetComponent<PlayerController>().personagens[player.GetComponent<PlayerController>().personagemSelecionada].GetComponent<Classe>().health;
        health = player.GetComponent<PlayerController>().health;
        caraPersonagem.sprite = player.GetComponent<PlayerController>().carasPersonages[player.GetComponent<PlayerController>().personagemSelecionada];
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerController>().health;
        healthBar.fillAmount = map(health, 0, maxHealth, 0, 1);
    }

    private IEnumerator spawnEnemy(float tempo, GameObject inimigo)
    {
        yield return new WaitForSeconds(tempo);

        float coordX = UnityEngine.Random.Range(-x, x);
        float coordY = UnityEngine.Random.Range(-y, y);

        // Não spawnar em cima do jogador nem em cima de outro monstro
        while((coordY == player.transform.position.y && coordX == player.transform.position.x) || (coordY == lastY && coordX == lastX) )
        {
            coordX = UnityEngine.Random.Range(-x, x);
            coordY = UnityEngine.Random.Range(-y, y);
        }

        lastX = coordX;
        lastY = coordY;

        Instantiate(inimigo, new Vector3(coordX, coordY, 0f), Quaternion.identity);
        StartCoroutine(spawnEnemy(tempo, inimigos[0]));
    }

    private static float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }
}
