# Fuga_Da_Cidade

## 📝 Descrição do Jogo
Um jogo de ação em terceira pessoa onde o jogador acorda em uma cidade infestada por hordas de zumbis. O objetivo é sobreviver recolhendo armas pelo cenário e utilizando veículos para atropelar os inimigos e escapar do apocalipse.

## 🎮 Instruções de Jogabilidade
* **W, A, S, D:** Movimentar o personagem (Andar / Girar).
* **Barra de Espaço:** Atacar com o taco de baseball (após coletado).
* **E:** Entrar e Sair do carro (quando estiver próximo ao veículo).
* **Setas do Teclado / W,S,A,D (No Carro):** Dirigir o veículo.

## 📹 Vídeo de Gameplay 
[Clique aqui para assistir à Gameplay](https://youtu.be/iMnostVDyHw)

## 📸 Capturas de Tela (Screenshots)
### Menu Inicial

<img width="990" height="560" alt="Captura de tela 2026-06-14 163142" src="https://github.com/user-attachments/assets/5171bd1c-ea18-461d-a26f-25618686e4a2" />

### Exploração da Cidade
<img width="1660" height="930" alt="Captura de tela 2026-06-14 163750" src="https://github.com/user-attachments/assets/d4eba9ae-28a5-43e6-ba73-c1f9be425019" />

### Combate Zumbi
<img width="1888" height="904" alt="image" src="https://github.com/user-attachments/assets/2e5554b3-cab9-4b61-8bb5-d39b8fbf3341" />

---

## 🛠️ Novas Funcionalidades Desenvolvidas

### 1. Sistema de Vida (HP) e Dano Dinâmico nos Zumbis
Foi implementado um sistema de vida para os zumbis onde eles podem receber dano de duas formas distintas: de forma fixa através do ataque físico com o taco de baseball, ou de forma dinâmica através de colisões com o carro, onde a quantidade de dano aplicada é calculada em tempo real com base na velocidade (magnitude) do impacto do veículo.

### 1. Sistema de Dano por Atropelamento

Foi implementado um sistema de dano baseado na velocidade do veículo no momento da colisão. Quando o personagem colide com um objeto identificado pela tag `Carro`, a velocidade do impacto é obtida através do `Rigidbody` do veículo. Caso a velocidade seja superior ao limite mínimo definido, o dano é calculado proporcionalmente à velocidade e aplicado ao personagem.

```csharp
// Trecho do cálculo de dano por atropelamento baseado na velocidade
private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Carro"))
    {
        Rigidbody rbCarro = collision.gameObject.GetComponent<Rigidbody>();

        if (rbCarro != null)
        {
            float velocidadeImpacto = rbCarro.linearVelocity.magnitude;

            if (velocidadeImpacto > 2f)
            {
                float danoPorVelocidade = velocidadeImpacto * 5f;
                TomarDano(danoPorVelocidade);
            }
        }
    }
}
```

---

### 2. Sistema de Interação com Veículos (Entrar/Sair)

Foi criado um sistema de gerenciamento de estados que permite ao personagem entrar e sair dos veículos presentes no jogo. Ao aproximar-se do colisor do carro e pressionar a tecla **E**, o personagem é ocultado, o controle do veículo é ativado e a câmera de perseguição passa a acompanhar o carro. Ao pressionar a mesma tecla novamente, o processo é revertido, permitindo que o jogador retorne ao controle do personagem fora do veículo.

```csharp
void EntrarNoCarro()
{
    estaNoCarro = true;

    personagem.SetActive(false);
    scriptControleCarro.enabled = true;
    cameraCarro.SetActive(true);
}
```
