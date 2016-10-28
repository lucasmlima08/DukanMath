using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Pontuacao : MonoBehaviour
{
    // Texto do tempo de jogo.
	public TextMesh tempoDeJogo;

    // Texto do número de equações respondidas.
    public TextMesh equacoesRespondidas;

    // Tela do jogo.
    public GameObject telaJogo;
    
    // Tela de desempenho.
    public GameObject telaDesempenho;
    
    // Número de respostas certas e erradas.
    private int respostasCertas;
    private int respostasErradas;
    private int questoesRespondidas;
    
    // Tempo de jogo.
	private float tempoSec = 0;
	private float tempoMin = 0;
    
    // Classe de desempenho.
    private Desempenho desempenho;

    void Start()
    {
        respostasCertas = 0;
        respostasErradas = 0;
        questoesRespondidas = 0;

        tempoSec = 0;
        tempoMin = 0;

        equacoesRespondidas.color = Color.black;
    }

    void Update()
    {
        // Apresenta os acertos na interface.
        equacoesRespondidas.text = respostasCertas + " de " + questoesRespondidas;

        // Tempo de jogo
        tempoSec += Time.deltaTime;
        if (tempoSec >= 60)
        {
            tempoMin += 1;
            tempoSec = 0;
        }
        tempoDeJogo.text = tempoMin.ToString("0") + "m" + tempoSec.ToString("00") + "s";

        // Condição de parada 1: Respondeu 10 questões.
        if (questoesRespondidas == 10)
        {
            apresentaDesempenho();
        }

        // Condição de parada 2: Passou de 10 minutos.
        if (tempoMin >= 10)
        {
            apresentaDesempenho();
        }

        // Condição de parada 3: Clicou na tecla de saída.
        if (Input.GetKey(KeyCode.Escape))
        {
            apresentaDesempenho();
        }
    }

    // Chama a tela de desempenho.
    private void apresentaDesempenho()
    {
        telaDesempenho.SetActive(true);
        desempenho = telaDesempenho.GetComponent<Desempenho>();
        if (questoesRespondidas == 0) // Não respondeu nenhuma questão.
        {
            desempenho.setStringQuestoes("Você não respondeu nenhuma questão!");
            desempenho.setStringDesempenho("Desempenho: 0% de acertos.");
        }
        else if (respostasCertas == 0) // Não acertou nenhuma questão.
        {
            desempenho.setStringQuestoes("Você não acertou nenhuma questão de " + questoesRespondidas + " questões respondidas!");
            desempenho.setStringDesempenho("Desempenho: 0% de acertos.");
        }
        else // Respondeu e acertou alguma questão.
        {
            desempenho.setStringQuestoes("Você acertou " + respostasCertas + " questões de " + questoesRespondidas + " questões respondidas.");
            desempenho.setStringDesempenho("Desempenho: " + string.Format("{0:#.##}", ((respostasCertas * 100) / questoesRespondidas)) + "% de acertos.");
        }
        Destroy(gameObject);
    }

    // Chamado quando 
    public void addAcerto()
    {
        respostasCertas++;
        questoesRespondidas++;
    }

    // Chamado quando 
    public void addErro()
    {
        respostasErradas++;
        questoesRespondidas++;
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
