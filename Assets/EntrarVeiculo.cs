using UnityEngine;

public class EntrarVeiculo : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private GameObject personagem; // Arraste o seu herói aqui
    [SerializeField] private MonoBehaviour scriptControleCarro; // Arraste o OBJETO DO CARRO da Hierarchy para aqui!
    [SerializeField] private GameObject cameraCarro; // Arraste a câmara do carro aqui
    [SerializeField] private Transform localSaida; // Um objeto vazio ao lado da porta do carro

    private bool pertoDoCarro = false;
    private bool estaNoCarro = false;

    void Start()
    {
        // Garante que o jogo começa com o controle do carro desligado
        if (scriptControleCarro != null) scriptControleCarro.enabled = false;
        if (cameraCarro != null) cameraCarro.SetActive(false);
    }

    void Update()
    {
        // Se estiver perto do carro e apertar a tecla E para entrar
        if (pertoDoCarro && !estaNoCarro && Input.GetKeyDown(KeyCode.E))
        {
            EntrarNoCarro();
        }
        // Se já estiver dentro do carro e apertar E para sair
        else if (estaNoCarro && Input.GetKeyDown(KeyCode.E))
        {
            SairDoCarro();
        }
    }

    void EntrarNoCarro()
    {
        estaNoCarro = true;
        personagem.SetActive(false); // Esconde o herói
        
        scriptControleCarro.enabled = true; // Ativa o controle do carro
        cameraCarro.SetActive(true); // Ativa a câmara do carro
    }

    void SairDoCarro()
    {
        estaNoCarro = false;
        scriptControleCarro.enabled = false; // Desliga o carro
        cameraCarro.SetActive(false);

        // Move o herói para o local de saída e reativa-o
        personagem.transform.position = localSaida.position;
        personagem.SetActive(true); 
    }

    // === ATUALIZADO PARA A SUA TAG "Personagem" ===
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Personagem"))
        {
            pertoDoCarro = true;
            Debug.Log("Pressione E para entrar no carro");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Personagem"))
        {
            pertoDoCarro = false;
        }
    }
}