using UnityEngine;

public class DanoTaco : MonoBehaviour
{
    [SerializeField] private float danoDoTaco = 25f;
    private Animator animatorHeroi;

    void Start()
    {
        // Pega o animator do personagem (pai do objeto atual) para checar se ele está atacando
        animatorHeroi = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se colidir com o zumbi
        if (other.CompareTag("Zumbi") || other.GetComponent<VidaZumbi>() != null)
        {
            // Checa se o jogador está na animação de ataque
            if (animatorHeroi != null && animatorHeroi.GetCurrentAnimatorStateInfo(0).IsName("m_melee_combat_attack_A")) 
            {
                VidaZumbi scriptZumbi = other.GetComponent<VidaZumbi>();
                if (scriptZumbi != null)
                {
                    scriptZumbi.TomarDano(danoDoTaco);
                }
            }
        }
    }
}