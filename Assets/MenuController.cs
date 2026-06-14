using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // O segredo para conseguir trocar de cena!

public class MenuController : MonoBehaviour
{
    // Criamos uma função pública para o botão conseguir "vê-la"
    public void IniciarJogo()
    {
        // Tem de colocar o nome EXATO da cena da sua cidade aqui dentro das aspas
        SceneManager.LoadScene("2"); 
    }
}