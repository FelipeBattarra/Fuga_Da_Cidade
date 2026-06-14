using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    [SerializeField] WheelCollider RodaTraseiraDireita;
    [SerializeField] WheelCollider RodaFrenteDireita;
    [SerializeField] WheelCollider RodaFrenteEsquerda;
    [SerializeField] WheelCollider RodaTraseiraEsquerda;

    public GameObject luzDoSol;
    public GameObject[] farois;
    public GameObject[] luzesFreio;

    // Novas variáveis para as 3 câmeras (Exercício 18)
    public GameObject camera3Pessoa;
    public GameObject cameraMotorista;
    public GameObject cameraRoda;

    public float aceleracao = 3000f;
    public float freio = 4000f;
    public float anguloTorque = 35f;

    private float aceleracaoAtual = 0f;
    private float freioAtual = 0f;
    private float anguloTorqueAtual = 0f;

    private void Update()
    {
        // Exercício 15 (Dia e Noite)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            luzDoSol.SetActive(!luzDoSol.activeInHierarchy);
        }

        // Exercício 16 (Faróis)
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject farol in farois)
            {
                farol.SetActive(!farol.activeInHierarchy);
            }
        }

        // Exercício 18 (Troca de Câmeras)
        // Nota: Alpha1, Alpha2 e Alpha3 são os números normais do teclado (acima das letras)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera3Pessoa.SetActive(true);
            cameraMotorista.SetActive(false);
            cameraRoda.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera3Pessoa.SetActive(false);
            cameraMotorista.SetActive(true);
            cameraRoda.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera3Pessoa.SetActive(false);
            cameraMotorista.SetActive(false);
            cameraRoda.SetActive(true);
        }
    }
    

    private void FixedUpdate()
    {
        // 1. Lógica do Freio, Motor e LUZES DE TRAVAGEM (Exercício 17)
        if (Input.GetKey(KeyCode.Space))
        {
            freioAtual = freio;
            aceleracaoAtual = 0f; 
            
            // Liga as luzes de travagem
            foreach (GameObject luz in luzesFreio)
            {
                luz.SetActive(true);
            }
        }
        else
        {
            freioAtual = 0f;
            aceleracaoAtual = aceleracao * Input.GetAxis("Vertical");
            
            // Desliga as luzes de travagem quando largamos o espaço
            foreach (GameObject luz in luzesFreio)
            {
                luz.SetActive(false);
            }
        }

        // 2. Aplica a força do motor
        RodaFrenteDireita.motorTorque = aceleracaoAtual;
        RodaFrenteEsquerda.motorTorque = aceleracaoAtual;

        // 3. Controle de Direção
        anguloTorqueAtual = anguloTorque * Input.GetAxis("Horizontal");
        RodaFrenteDireita.steerAngle = anguloTorqueAtual;
        RodaFrenteEsquerda.steerAngle = anguloTorqueAtual;

        // 4. Aplica a força do freio
        RodaFrenteDireita.brakeTorque = freioAtual;
        RodaFrenteEsquerda.brakeTorque = freioAtual;
        RodaTraseiraDireita.brakeTorque = freioAtual;
        RodaTraseiraEsquerda.brakeTorque = freioAtual;
    }
}