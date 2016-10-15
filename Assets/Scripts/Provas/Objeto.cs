using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Objeto : MonoBehaviour
{
    // Texto da equação.
    public TextMesh textEquacao;

    public Rigidbody rigidBody;
    
    // Classe de geração de equações.
    private GeradorDeEquacoes geradorDeEquacoes;

    // Equação.
    private string equacaoString;
    private string equacaoStringOriginal;

    // Guarda a resposta do usuário para a equação.
    private int respostaDaEquacao;
    private int respostaDaEquacaoCorreta;

    // Verifica se acertou.
    private bool respostaCorreta = false;

    // Verifica se já foi respondido.
    private bool respondido = false;
    
    // Array de números.
    private KeyCode[] keyCodes = {
         KeyCode.Alpha0,
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };

    // Atributos do personagem.
    private GameObject personagem;
    private Pontuacao pontuacaoPersonagem;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        respostaDaEquacao = -1;
        respostaDaEquacaoCorreta = -1;

        // Gerador de equações.
        geradorDeEquacoes = new GeradorDeEquacoes();

        // Chama a classe de score do personagem.
        personagem = GameObject.Find("TelaGame(Clone)");
        pontuacaoPersonagem = personagem.GetComponent<Pontuacao>();
    }

    void Update()
    {
        rigidBody.isKinematic = true;

        if (respostaDaEquacaoCorreta == -1)
        {
            gerarEquacao(); // Gera a equação.
        }
    }

    // Gera a equação.
    void gerarEquacao()
    {
        // Sorteia o nível da equação.
        int complexidade = 1 + Random.Range(0, 4);

        // Gera a equação
        bool statusEquacao = geradorDeEquacoes.gerarEquacaoPrimeiroGrau(complexidade);
        if (statusEquacao == true)
        {
            respostaDaEquacaoCorreta = geradorDeEquacoes.respostaCorreta;
            equacaoString = geradorDeEquacoes.equacaoString;
            equacaoStringOriginal = geradorDeEquacoes.equacaoString;
            textEquacao.text = equacaoString;
        }
    }
    
    // Verificação de colisão;
    void OnCollisionStay(Collision col)
    {
        // Verifica se foi o personagem que colidiu.
        if (col.gameObject.name == "Personagem")
        {
            // Caso não tenha enviado a resposta ainda.
            if (!respondido)
            {
                // Percorre as teclas de números.
                for (int i = 0; i < keyCodes.Length; i++)
                {
                    // Verifica o número que foi clicado.
                    if (Input.GetKeyDown(keyCodes[i]))
                    {
                        // Atualiza a resposta.
                        if (respostaDaEquacao == -1)
                        {
                            respostaDaEquacao = i;
                        }
                        else
                        {
                            respostaDaEquacao *= 10;
                            respostaDaEquacao += i;
                        }
                        
                        // substitui a equação colocando a resposta.
                        equacaoString = equacaoStringOriginal.Replace("X", respostaDaEquacao + "");
                        textEquacao.text = equacaoString;
                    }
                }

                // Apaga a resposta e reseta a equação.
                if (Input.GetKey(KeyCode.Backspace))
                {
                    respostaDaEquacao = -1;
                    equacaoString = equacaoStringOriginal;
                    textEquacao.text = equacaoString;
                }

                // Confirma a resposta do usuário. (Se respondeu e pressionou enter)
                if (Input.GetKey(KeyCode.KeypadEnter) && respostaDaEquacao != -1)
                {
                    // Verifica se a resposta foi correta.
                    if (respostaDaEquacao == respostaDaEquacaoCorreta)
                    {
                        respostaCorreta = true; // Define o status.
                        textEquacao.color = Color.green; // Muda a cor.
                        pontuacaoPersonagem.addAcerto(); // Adiciona um erro ao personagem.
                    }
                    else
                    {
                        respostaCorreta = false; // Define o status.
                        textEquacao.color = Color.red; // Muda a cor.
                        pontuacaoPersonagem.addErro(); // Adiciona um acerto ao personagem.
                    }
                    respondido = true;
                }
            }
        }
    }
}