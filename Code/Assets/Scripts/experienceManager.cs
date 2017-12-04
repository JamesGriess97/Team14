using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class experienceManager : MonoBehaviour
{
	public static int experience;       


	Text text;                      // Reference to the Text component.


	void Start ()
	{
		text = GetComponent <Text> ();

		// Reset the score.
		experience = 0;
	}


	void Update ()
	{
		text.text = "Experience: " + experience;
	}
}