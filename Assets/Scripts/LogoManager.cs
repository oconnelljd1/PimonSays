using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour {

	[SerializeField] private float waitFor = 2;

	// Use this for initialization
	void Start () {
		StartCoroutine ("LoadNext");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator LoadNext (){
		yield return new WaitForSeconds (waitFor);
		SceneManager.LoadScene ("Title");
	}
}
