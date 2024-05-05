using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacionCultivo : MonoBehaviour
{
	Animator anim;
	public GameObject boton;
	//public GameObject CosechaTradicional;
	//public GameObject CosechaRegenerativa;

	// Start is called before the first frame update
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		// cuando termina la animacion bool pasa a true
		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0)) {
			anim.SetBool("Final", true);
			boton.SetActive(true);
			//precio();
		}
	}

	/*public void precio() {
		if(mainManager.Instance.agricultura == true)
		{
			CosechaRegenerativa.SetActive(true);
			print("Regenerativa");
		}
		else
		{
			CosechaTradicional.SetActive(true);
			print("Tradicional");
		}
	}*/
}