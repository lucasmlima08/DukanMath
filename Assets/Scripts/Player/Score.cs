using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Score : MonoBehaviour
{
	public TextMesh textEquation;

	public TextMesh tempoDeJogo;

	public TextMesh textProvas1;
	public TextMesh textProvas2;

    private int objectsDestroyed_T1 = 0;
    private int objectsDestroyed_T2 = 0;

    private GenerateEquation generateEquation;

	private float tempoSec = 0;
	private float tempoMin = 0;

    void Start()
    {
        generateEquation = new GenerateEquation();
        generateEquation.startGame(1);
    }

    void Update()
    {
        tempoSec += Time.deltaTime;

        if (tempoSec >= 60)
        {
            tempoMin += 1;
            tempoSec = 0;
        }

		textEquation.text = generateEquation.equationString+"";

		textProvas1.text = "0"+objectsDestroyed_T1;
		textProvas2.text = "0"+objectsDestroyed_T2;

		tempoDeJogo.text = tempoMin.ToString("0")+"m"+tempoSec.ToString("00")+"s";

        Debug.Log("Resultado da Equação: " + generateEquation.responseSolution);

        //Debug.Log("Provas tipo 1: " + objectsDestroyed_T1 + " :: Provas tipo 2: " + objectsDestroyed_T2);
        //Debug.Log("Equação Gerada: " + generateEquation.equationString + " Resultado da Equação: " + generateEquation.responseSolution);
    }
    
    public void destroyObject_T1()
    {
        objectsDestroyed_T1++;
    }

    public void destroyObject_T2()
    {
        objectsDestroyed_T2++;
    }

    public void clear()
    {
        objectsDestroyed_T1 = 0;
        objectsDestroyed_T2 = 0;
    }
}
