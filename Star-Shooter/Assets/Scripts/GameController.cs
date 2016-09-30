using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject SecondHazard;
	public GameObject ThirdHazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText GameOverText;
	private int score;
	private bool gameOver;
	private bool restart;


	void Start() {

		gameOver = false;
		restart = false;
		restartText.text = "";
		GameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves() {

		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0;i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				if (i % 3 == 0) {
					Vector3 spawnPosition2 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Instantiate (SecondHazard, spawnPosition2, spawnRotation);
				} else if (i % 7 == 0) {
					Vector3 spawnPosition3 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Instantiate (ThirdHazard, spawnPosition3, spawnRotation);
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	void Update () {

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {

				Application.LoadLevel (Application.loadedLevel);

			}
		}

	}

	public void AddScore (int newScoreValue){

		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver(){

		GameOverText.text = "Game Over!";
		gameOver = true;

	}

	void UpdateScore() {

		scoreText.text = "Score: " + score;
	}

}
