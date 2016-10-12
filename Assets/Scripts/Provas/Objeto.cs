using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Objeto : MonoBehaviour
{
    public TextMesh textEquacao;

    public Rigidbody rigidBody;
    
    // Classe de geração de equações.
    private GeradorDeEquacoes geradorDeEquacoes;

    // Equação.
    private string equacaoString;

    // Guarda a resposta do usuário para a equação.
    private int respostaDaEquacao;
    private int respostaDaEquacaoCorreta;

    // Verifica se acertou.
    private bool respostaCorreta = false;
    
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


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        respostaDaEquacao = -1;

        // Gera uma equação.
        geradorDeEquacoes = new GeradorDeEquacoes();
        geradorDeEquacoes.startGame(1);
        respostaDaEquacaoCorreta = geradorDeEquacoes.responseSolution;
        equacaoString = geradorDeEquacoes.equationString;
        textEquacao.text = equacaoString;
    }

    void Update()
    {
        rigidBody.isKinematic = true;
    }
    
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Personagem")
        {
            // Guarda o valor respondido.
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
                    } else
                    {
                        respostaCorreta = false;
                        textEquacao.color = Color.red;
                    }
                    // substitui a equação colocando a resposta.
                    equacaoString = equacaoString.Replace("?", respostaDaEquacao + "");
                    textEquacao.text = equacaoString;
                }
            }
        }
    }
}