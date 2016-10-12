using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventoMenu : MonoBehaviour {

    public GameObject effectClick;

    public GameObject menu;
    public GameObject game;

	public void eventStartGame()
	{
        menu.SetActive(false);

        game.SetActive(true);
    }

    public void playEffectSound()
    {
        AudioSource audioSource = effectClick.GetComponent<AudioSource>();
        audioSource.Play();
    }

}
