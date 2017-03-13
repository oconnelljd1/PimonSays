using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

	private float onTime = 0.4f;
	private float offTime = 0.1f;

	private string pi = "31415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253482117";
	private char[] Pi;

	private int index = 1;
	private int myIndex;

	private int soundCheck;

	private bool playing = false;

	[SerializeField] private Sprite[] regularSprites;
	[SerializeField] private Sprite[] highlightedSprites;
	[SerializeField] private Image[] buttons;
	[SerializeField] private GameObject wrong, right;
	[SerializeField] private Text score;
	[SerializeField] private AudioClip[] audioClips;

	private AudioSource audioS;

	// Use this for initialization
	void Start () {
		//int value = Mathf.RoundToInt(Mathf.PI);
		//Debug.Log (value);
		//pi = "" + value;
		Pi = pi.ToCharArray ();
		audioS = GetComponent<AudioSource> ();
		StartCoroutine ("Simon");
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.Keypad0)){
			StartAudio (0);
			buttons [0].sprite = highlightedSprites [0];
		}else if(Input.GetKeyDown(KeyCode.Keypad1)){
			StartAudio (1);
			buttons [1].sprite = highlightedSprites [1];
		}else if(Input.GetKeyDown(KeyCode.Keypad2)){
			StartAudio (2);
			buttons [2].sprite = highlightedSprites [2];;
		}else if(Input.GetKeyDown(KeyCode.Keypad3)){
			StartAudio (3);
			buttons [3].sprite = highlightedSprites [3];
		}else if(Input.GetKeyDown(KeyCode.Keypad4)){
			StartAudio (4);
			buttons [4].sprite = highlightedSprites [4];
		}else if(Input.GetKeyDown(KeyCode.Keypad5)){
			StartAudio (5);
			buttons [5].sprite = highlightedSprites [5];
		}else if(Input.GetKeyDown(KeyCode.Keypad6)){
			StartAudio (6);
			buttons [6].sprite = highlightedSprites [6];
		}else if(Input.GetKeyDown(KeyCode.Keypad7)){
			StartAudio (7);
			buttons [7].sprite = highlightedSprites [7];
		}else if(Input.GetKeyDown(KeyCode.Keypad8)){
			StartAudio (8);
			buttons [8].sprite = highlightedSprites [8];
		}else if(Input.GetKeyDown(KeyCode.Keypad9)){
			StartAudio (9);
			buttons [9].sprite = highlightedSprites [9];
		}

		if(Input.GetKeyUp(KeyCode.Keypad0)){
			CheckInput (0);
			StopAudio (0);
		}else if(Input.GetKeyUp(KeyCode.Keypad1)){
			CheckInput (1);
			StopAudio (1);
		}else if(Input.GetKeyUp(KeyCode.Keypad2)){
			CheckInput (2);
			StopAudio (2);
		}else if(Input.GetKeyUp(KeyCode.Keypad3)){
			CheckInput (3);
			StopAudio (3);
		}else if(Input.GetKeyUp(KeyCode.Keypad4)){
			CheckInput (4);
			StopAudio (4);
		}else if(Input.GetKeyUp(KeyCode.Keypad5)){
			CheckInput (5);
			StopAudio (5);
		}else if(Input.GetKeyUp(KeyCode.Keypad6)){
			CheckInput (6);
			StopAudio (6);
		}else if(Input.GetKeyUp(KeyCode.Keypad7)){
			CheckInput (7);
			StopAudio (7);
		}else if(Input.GetKeyUp(KeyCode.Keypad8)){
			CheckInput (8);
			StopAudio (8);
		}else if(Input.GetKeyUp(KeyCode.Keypad9)){
			CheckInput (9);
			StopAudio (9);
		}*/

		for (int i = 0; i < 10; i++) {
			if (Input.GetButtonDown ("" + i)) {
				StartAudio (i);
				buttons [i].sprite = highlightedSprites [i];
			}else if(Input.GetButtonUp ("" + i)){
				CheckInput (i);
				StopAudio (i);
			}
		}
	}

	IEnumerator Simon(){
		playing = false;
		right.SetActive (true);
		yield return new WaitForSeconds (1);
		right.SetActive (false);
		for(int i = 0; i < index; i ++){
			string digit = "" + Pi [i];
			int current = int.Parse (digit);
			IEnumerator myCoroutine = PlaySound (current);
			StartCoroutine (myCoroutine);
			buttons [current].sprite = highlightedSprites [current];
			yield return new WaitForSeconds (onTime);
			buttons [current].sprite = regularSprites [current];
			yield return new WaitForSeconds(offTime);
		}
		playing = true;
		myIndex = 0;
	}

	IEnumerator GameOver(){
		wrong.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		SceneManager.LoadScene ("Title");
	}

	IEnumerator PlaySound(int _index){
		audioS.clip = audioClips [_index];
		audioS.Play ();
		yield return new WaitForSeconds (onTime);
		audioS.Stop ();
	}

	private void CheckInput(int _input){
		if(playing){
			string digit = "" + Pi [myIndex];
			int current = int.Parse (digit);
			if (current == _input) {
				buttons [current].sprite = regularSprites [current];
				myIndex++;
				if(myIndex == index){
					score.text = "" + index;
					index++;
					StartCoroutine ("Simon");
				}
			} else {
				StartCoroutine ("GameOver");
			}
		}
	}

	private void StartAudio(int _index){
		audioS.clip = audioClips [_index];
		audioS.Play();
		soundCheck = _index;
	}

	private void StopAudio(int _index){
		if(_index == soundCheck){
			audioS.Stop ();
		}
	}

}
