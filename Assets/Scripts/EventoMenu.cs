using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventoMenu : MonoBehaviour {

    // Efeito de clique.
    public GameObject effectClick;

    // Tela do menu.
    public GameObject telaMenu;

    // Tela do jogo.
    public GameObject telaJogo;

    // Tela de instrução dos cálculos.
    public GameObject telaCalculos;

    // Tela de instruções.
    public GameObject telaInstrucoes;

    // Tela de desempenho.
    public GameObject telaDesempenho;

    // Clone da tela do jogo.
    private GameObject telaJogoClone;

    // Classe de efeitos sonoros.
    private AudioSource audioSource;

    // Evento que inicia a tela do menu.
    public void eventoIniciarTelaMenu()
	{
        tocarEfeitoSonoro();
        telaMenu.SetActive(false);
        telaMenu.SetActive(true);
    }

    // Evento que inicia a tela do jogo.
    public void eventoIniciarTelaJogo()
    {
        tocarEfeitoSonoro();
        telaJogoClone = Instantiate(telaJogo);
        telaMenu.SetActive(false);
        telaJogoClone.SetActive(true);
    }

    // Evento que inicia a tela de intruções dos cálculos.
    public void eventoIniciarTelaCalculos()
    {
        tocarEfeitoSonoro();
        telaMenu.SetActive(false);
        telaCalculos.SetActive(true);
    }

    // Evento que inicia a tela de instruções.
    public void eventoIniciarTelaInstrucoes()
    {
        tocarEfeitoSonoro();
        telaMenu.SetActive(false);
        telaInstrucoes.SetActive(true);
    }

    // Evento de saída da tela do menu.
    public void eventoSairTelaMenu()
    {
        Application.Quit();
    }

    // Evento de saída da tela do jogo.
    public void eventoSairTelaJogo()
    {
        tocarEfeitoSonoro();
        telaJogo.SetActive(false);
        telaDesempenho.SetActive(true);
    }

    // Evento de saída da tela de intruções.
    public void eventoSairTelaInstrucoes()
    {
        tocarEfeitoSonoro();
        telaInstrucoes.SetActive(false);
        telaMenu.SetActive(true);
    }

    // Evento de saída da tela de instruções de cálculos.
    public void eventoSairTelaCalculos()
    {
        tocarEfeitoSonoro();
        telaCalculos.SetActive(false);
        telaMenu.SetActive(true);
    }

    // Evento de saída da tela de desempenho.
    public void eventoSairTelaDesempenho()
    {
        tocarEfeitoSonoro();
        telaDesempenho.SetActive(false);
        telaMenu.SetActive(true);
    }

    // Evento que toca um efeito sonoro.
    private void tocarEfeitoSonoro()
    {
        audioSource = effectClick.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
