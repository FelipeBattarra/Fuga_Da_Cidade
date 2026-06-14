using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieRadar : MonoBehaviour
{
    private Transform target; 
    public float _range; // Esta será a distância de ataque agora! (ex: 1.5)
    public float speed;
    public float rotationSpeed;
    private Animator zombieAnim;

    void Start()
    {
        zombieAnim = GetComponent<Animator>();
    }

private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Personagem")
        {
            // === EXERCÍCIO 04: A PESSOA FOGE ===
            Animator pessoaAnim = other.GetComponent<Animator>();
            followPath pessoaCaminho = other.GetComponent<followPath>(); // Pegamos o script da pessoa!

            if (pessoaAnim != null)
            {
                // Se ela ainda não estava correndo, ativamos o desespero
                if (pessoaAnim.GetBool("runAway") == false)
                {
                    pessoaAnim.SetBool("runAway", true);
                    
                    if (pessoaCaminho != null)
                    {
                        // Sorteia uma velocidade de fuga entre 15 e 30
                        pessoaCaminho.movementSpeed = Random.Range(4f, 6f); 
                    }
                }
            }
            // ===================================

            target = other.gameObject.transform;
            
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(target.position - transform.position),
                rotationSpeed * Time.deltaTime);

            float dist = Vector3.Distance(target.position, transform.position);
            
            if (dist <= _range)
            {
                zombieAnim.SetBool("runZombie", false);
                zombieAnim.SetBool("attackZombie", true); 
            }
            else
            {
                zombieAnim.SetBool("attackZombie", false); 
                zombieAnim.SetBool("runZombie", true);     
                
                transform.position = Vector3.MoveTowards(transform.position,
                    target.transform.position, speed);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personagem")
        {
            zombieAnim.SetBool("runZombie", false);
            zombieAnim.SetBool("attackZombie", false);
            zombieAnim.SetBool("idleZombie", true);

            // === EXERCÍCIO 04: A PESSOA VOLTA AO NORMAL ===
            Animator pessoaAnim = other.GetComponent<Animator>();
            followPath pessoaCaminho = other.GetComponent<followPath>();

            if (pessoaAnim != null)
            {
                pessoaAnim.SetBool("runAway", false);
                
                if (pessoaCaminho != null)
                {
                    // Volta para a velocidade normal de caminhada
                    pessoaCaminho.movementSpeed = 5f; 
                }
            }
            // ==============================================
        }
    }
}