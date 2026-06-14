using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Animator heroi;
    
    // === NOVA VARIÁVEL PARA O TACO NA MÃO ===
    public GameObject tacoNaMao; 

    void Start()
    {
        speed = 5.0f;
        heroi = GetComponent<Animator>();
        
        // Garante que o herói começa sem o taco na mão
        if (tacoNaMao != null)
        {
            tacoNaMao.SetActive(false);
        }
    }

    void Update()
    {
        // ... (Mantenha todo o código de movimento W, A, S, D que já estava aqui) ...
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            heroi.SetBool("Correndo", true);
            heroi.SetBool("Parado", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
            heroi.SetBool("Correndo", true);
            heroi.SetBool("Parado", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
            heroi.SetBool("Correndo", true);
            heroi.SetBool("Parado", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
            heroi.SetBool("Correndo", true);
            heroi.SetBool("Parado", false);
        }

        if (!Input.anyKey)
        {
            heroi.SetBool("Correndo", false);
            heroi.SetBool("Parado", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Dispara o "gatilho" da animação de ataque
            heroi.SetTrigger("Atacar");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se bater num objeto com a tag "Taco"...
        if (other.gameObject.CompareTag("Taco"))
        {
            // 1. Liga o taco na mão do personagem
            if (tacoNaMao != null)
            {
                tacoNaMao.SetActive(true);
            }
            
            // 2. Destrói o taco que estava a flutuar no chão
            Destroy(other.gameObject);
        }
    }
}