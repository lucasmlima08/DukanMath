using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Controle : MonoBehaviour
{
    // Câmera do personagem.
    private GameObject cameraTerceiraPessoa;

    // Câmera do labirinto.
    private GameObject cameraLabirinto;

    void Start()
    {
        // Chama as câmeras do jogo.
        cameraTerceiraPessoa = GameObject.Find("CameraTerceiraPessoa");
        cameraLabirinto = GameObject.Find("CameraLabirinto");

        cameraTerceiraPessoa.SetActive(true);
        cameraLabirinto.SetActive(false);
    }

    void Update()
    {
        // Troca a câmera do jogo enquanto clicar no botão.
        if (Input.GetKey(KeyCode.B))
        {
            cameraTerceiraPessoa.SetActive(false);
            cameraLabirinto.SetActive(true);
        }
        else
        {
            cameraTerceiraPessoa.SetActive(true);
            cameraLabirinto.SetActive(false);
        }
    }
}
