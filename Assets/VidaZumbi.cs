using UnityEngine;

public class VidaZumbi : MonoBehaviour
{
    [SerializeField] private float hpMaximo = 100f;
    private float hpAtual;

    void Start()
    {
        hpAtual = hpMaximo;
    }

    // Função pública para que outros scripts possam aplicar dano
    public void TomarDano(float quantidade)
    {
        hpAtual -= quantidade;
        Debug.Log("Zumbi tomou " + quantidade + " de dano! HP Restante: " + hpAtual);

        if (hpAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Zumbi morreu!");
        // Aqui você pode tocar uma animação de morte ou som antes de destruir
        Destroy(gameObject); 
    }

    // Detetar colisão com o Carro (Dano baseado na velocidade)
    private void OnCollisionEnter(Collision collision)
    {
        // Certifique-se de que o seu carro tem a Tag "Carro"
        if (collision.gameObject.CompareTag("Carro"))
        {
            // Pega o componente Rigidbody do carro para saber a velocidade dele
            Rigidbody rbCarro = collision.gameObject.GetComponent<Rigidbody>();
            
            if (rbCarro != null)
            {
                // Calcula a velocidade do impacto
                float velocidadeImpacto = rbCarro.linearVelocity.magnitude; 
                
                // Só dá dano se o carro estiver em movimento considerável
                if (velocidadeImpacto > 2f)
                {
                    float danoPorVelocidade = velocidadeImpacto * 5f; // Ajuste o multiplicador (5f) como quiser
                    TomarDano(danoPorVelocidade);
                }
            }
        }
    }
}