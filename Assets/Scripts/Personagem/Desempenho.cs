using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Desempenho : MonoBehaviour
{
    // Texto que apresenta as questões respondidas e acertadas.
    public GameObject questoesString;

    // Texto que apresenta o desempenho no jogo.
    public GameObject desempenhoString;
    
    // Texto que define a string de questões respondidas.
    public void setStringQuestoes(string resultado)
    {
        questoesString.GetComponent<UnityEngine.UI.Text>().text = resultado;
    }

    // Texto que define a string de desempenho no jogo.
    public void setStringDesempenho(string resultado)
    {
        desempenhoString.GetComponent<UnityEngine.UI.Text>().text = resultado;
    }
}
