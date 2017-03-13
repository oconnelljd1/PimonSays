using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(){
		SceneManager.LoadScene ("Test1");
	}

	public void LoadCredits(){
		SceneManager.LoadScene ("Credits");
	}

	public void Quit(){
		Application.Quit();
	}
}
