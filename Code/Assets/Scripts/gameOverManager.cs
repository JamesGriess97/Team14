using UnityEngine;

public class gameOverManager : MonoBehaviour
{
	public PlayerHealth playerHealth;    

	Animator anim;                          


	void Start ()
	{
		anim = GetComponent <Animator> ();
	}


	void Update ()
	{
		
		if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger ("GameOver");

		}
	}
}