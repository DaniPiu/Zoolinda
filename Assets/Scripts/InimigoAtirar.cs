using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtirar : MonoBehaviour
{
	public Rigidbody2D projectile;
	bool bloqueio = true;

	void Start()
	{
		StartCoroutine("Atraso");
	}
	void Update()
	{
		if (bloqueio == false)
		{
			Atirar();
			StartCoroutine("Cooldown");
		}
	}

	void Atirar()
	{
		bloqueio = true;
		Rigidbody2D clone;
		clone = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody2D;
		Destroy(clone.gameObject, 3.0f);

	}

	IEnumerator Atraso()
	{
		yield return new WaitForSeconds(0.25f);
		bloqueio = false;
	}

	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(2.5f);
		bloqueio = false;
	}
}