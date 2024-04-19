using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

	public void LoadGameScene()
	{
		StartCoroutine("Jogo");
	}

	public void Instrucoes()
	{
		StartCoroutine("Dicas");
	}

	public void Creditos()
	{
		StartCoroutine("Autores");
	}

	public void FecharJogo()
	{
		Application.Quit();
	}

	IEnumerator Jogo()
    {
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Igreja1");
	}

	IEnumerator Dicas()
	{
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Instrucoes");
	}

	IEnumerator Autores()
	{
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Creditos");
	}

}