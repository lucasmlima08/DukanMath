using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Pontuacao : MonoBehaviour
{
    // Texto do tempo de jogo.
	public TextMesh tempoDeJogo;

    // Texto do número de equações respondidas.
    public TextMesh equacoesRespondidas;
    
    // Número de respostas certas e erradas.
    private int respostasCertas;
    private int respostasErradas;
    
    // Tempo de jogo.
	private float tempoSec = 0;
	private float tempoMin = 0;

    void Start()
    {
        respostasCertas = 0;
        respostasErradas = 0;
    
        tempoSec = 0;
        tempoMin = 0;

        equacoesRespondidas.color = Color.black;
    }

    void Update()
    {
        equacoesRespondidas.text = (respostasCertas + respostasErradas) + "";

        // Tempo de jogo
        tempoSec += Time.deltaTime;
        if (tempoSec >= 60)
        {
            tempoMin += 1;
            tempoSec = 0;
        }
        tempoDeJogo.text = tempoMin.ToString("0") + "m" + tempoSec.ToString("00") + "s";

        // Condição de parada 1: Respondeu 6 questões.
        if (respostasCertas + respostasErradas == 6)
        {
            // Interrompe o jogo.
        }

        // Condição de parada 2: Passou de 10 minutos.
        if (tempoMin >= 10)
        {
            // Interrompe o jogo.
        }
    }

    // Chamado quando 
    public void addAcerto()
    {
        respostasCertas++;
    }

    // Chamado quando 
    public void addErro()
    {
        respostasErradas++;
    }

    // Reinicia os dados.
    public void clear()
    {
        respostasCertas = 0;
        respostasErradas = 0;
        tempoMin = 0;
        tempoSec = 0;
    }
}
