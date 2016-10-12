using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Objeto : MonoBehaviour
{
    public TextMesh textEquacao;

    public Rigidbody rigidBody;
    
    // Classe de gera��o de equa��es.
    private GeradorDeEquacoes geradorDeEquacoes;

    // Equa��o.
    private string equacaoString;

    // Guarda a resposta do usu�rio para a equa��o.
    private int respostaDaEquacao;
    private int respostaDaEquacaoCorreta;

    // Verifica se acertou.
    private bool respostaCorreta = false;
    
    // Array de n�meros.
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

        // Gerador de equa��es.
        geradorDeEquacoes = new GeradorDeEquacoes();

        // Chama a classe de score do personagem.
        personagem = GameObject.Find("Personagem");
        pontuacaoPersonagem = personagem.GetComponent<Pontuacao>();
    }

    void Update()
    {
        rigidBody.isKinematic = true;

        if (respostaDaEquacaoCorreta == -1)
        {
            // Gera a equa��o.
            geradorDeEquacoes.startGame(1);
            respostaDaEquacaoCorreta = geradorDeEquacoes.responseSolution;
            equacaoString = geradorDeEquacoes.equationString;
            textEquacao.text = equacaoString;
        }
    }
    
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Personagem")
        {
            // Caso ainda n�o tenha respondido.
            if (respostaDaEquacao == -1)
            {
                // Percorre as teclas para checar qual foi escolhida.
                for (int i = 0; i < keyCodes.Length; i++)
                {
                    if (Input.GetKeyDown(keyCodes[i]))
                    {
                        respostaDaEquacao = i;
                        // Verifica se a resposta foi correta.
                        if (respostaDaEquacao == respostaDaEquacaoCorreta)
                        {
                            respostaCorreta = true;
                            textEquacao.color = Color.green;
                            pontuacaoPersonagem.addAcerto();
                        }
                        else
                        {
                            respostaCorreta = false;
                            textEquacao.color = Color.red;
                            pontuacaoPersonagem.addErro();
                        }
                        // substitui a equa��o colocando a resposta.
                        equacaoString = equacaoString.Replace("?", respostaDaEquacao + "");
                        textEquacao.text = equacaoString;
                    }
                }
            }
        }
    }
}