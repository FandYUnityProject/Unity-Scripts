using UnityEngine;
using System.Collections;

public class friendMessage_XXX : MonoBehaviour {

	public GameObject playerObject;
	public GameObject friendObject;

	public  float  distance;
	private Vector2 playerPos;
	private Vector2 friendPos;

	public  bool isTalk = false;

	// Use this for initialization
	void Start () {

		// Playerは基本1人なので予め取得
		playerObject = GameObject.Find ("Player");

		// 仲間毎にスクリプトを作成するので”Friend_XXX”を予め取得
		friendObject = GameObject.Find (this.name);
	}
	
	// Update is called once per frame
	void Update () {

		// Playerと仲間キャラの座標から距離を取得
		playerPos = playerObject.transform.position;
		friendPos = friendObject.transform.position;
		distance = Vector2.Distance(playerPos,friendPos);

		// 一定距離内で”T/t”を押すと会話
		if (distance <= 5.0f && Input.GetKeyDown (KeyCode.T)) {

			textMessage.isTalk = true;
			isTalk = true;
		}

		if ( textMessage.isTalk ) {

			if( isTalk ){

				// --- 現在のシナリオ（ゲームの進行度）に応じてメッセージを変更  --- //
				if( scenarioControll.mainScenarioNumber == 0 ){
					textMessage.dispMsg ("Friend_01", "会話0あああああああああああああああああ\nああああああああ");
				}

				if( scenarioControll.mainScenarioNumber == 1 ){
					textMessage.dispMsg ("Friend_01", "会話1あああああああああああああああああああああああああ");
				}

				if( scenarioControll.mainScenarioNumber == 2 ){
					textMessage.dispMsg ("Friend_01", "会話2あああああああああああああああああああああああああ");
				}

				isTalk = false;
			}
		}
	}
}
