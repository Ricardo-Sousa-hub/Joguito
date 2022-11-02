using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> inimigos;

    public float intervaloDeSpawn = 3f;

    public float x;
    public float y;

    private float lastX = 0;
    private float lastY = 0;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(intervaloDeSpawn, inimigos[0]));
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float tempo, GameObject inimigo)
    {
        yield return new WaitForSeconds(tempo);

        float coordX = Random.Range(-x, x);
        float coordY = Random.Range(-y, y);

        // Não spawnar em cima do jogador nem em cima de outro monstro
        while((coordY == player.transform.position.y && coordX == player.transform.position.x) || (coordY == lastY && coordX == lastX) )
        {
            coordX = Random.Range(-x, x);
            coordY = Random.Range(-y, y);
        }

        lastX = coordX;
        lastY = coordY;

        Instantiate(inimigo, new Vector3(coordX, coordY, 0f), Quaternion.identity);
        StartCoroutine(spawnEnemy(tempo, inimigos[0]));
    }
}
