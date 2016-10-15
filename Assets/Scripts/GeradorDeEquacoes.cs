using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class GeradorDeEquacoes
    {
        public String equacaoString = "";
        public int respostaCorreta = -1;

        //- Retorna um array com 2 operadores aritméticos.
        private char gerarOperador()
        {
            char[] operadores = new char[] { '+', '-' };
            int posicao = gerarNumeroAleatorio(2);
            return operadores[posicao];
        }

        //- Retorna um número aleatório entre 0 e o limite.
        private int gerarNumeroAleatorio(int limite)
        {
            int sorteado = UnityEngine.Random.Range(0, limite);
            return sorteado;
        }

        // Gerador de equações.
        // Complexidade 1: Vai de 1 a 10.
        // Complexidade 2: Vai de 1 a 20.
        // Complexidade 3: Vai de 1 a 50.
        // Complexidade 4: Vai de 1 a 100;

        public bool gerarEquacaoPrimeiroGrau(int complexidade)
        {
            try
            {
                // Limite do gerador.
                int limite = 0;

                // Define a complexidade.
                if (complexidade == 1)
                {
                    limite = 10;
                }
                else if (complexidade == 2)
                {
                    limite = 20;
                }
                else if (complexidade == 3)
                {
                    limite = 50;
                }
                else
                {
                    limite = 100;
                }
                
                // Sorteia o X (Entre 1 e 100)
                int x = 1 + gerarNumeroAleatorio(limite);

                // Sorteia o A (Entre 1 e 100)
                int a = 1 + gerarNumeroAleatorio(limite);

                // Sorteia o B (Entre 1 e 100)
                int b = 1 + gerarNumeroAleatorio(limite);

                // Sorteia o operador (- ou +)
                char operador = gerarOperador();

                // Calcula o resultado da equacao.
                if (operador.Equals('+')) // Soma.
                {
                    int respostaDoCalculo = (a * x) + b;
                    equacaoString = a + " * X + " + b + " = " + respostaDoCalculo;
                }
                else // Subtração.
                {
                    int respostaDoCalculo = (a * x) - b;
                    equacaoString = a + " * X - " + b + " = " + respostaDoCalculo;
                }

                // A resposta correta será o X.
                respostaCorreta = x;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
