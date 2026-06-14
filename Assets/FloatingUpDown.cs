using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUpDown : MonoBehaviour
{
    // Variáveis que vão aparecer no Inspector iguais às do seu PDF
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.05f;
    public float frequency = 1f;

    // Variáveis para guardar a posição inicial
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        // Guarda a posição onde você colocou o taco no mapa
        posOffset = transform.position;
    }

    void Update()
    {
        // 1. Faz o taco girar no próprio eixo (Y)
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // 2. Faz o taco flutuar para cima e para baixo usando uma onda matemática (Seno)
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}