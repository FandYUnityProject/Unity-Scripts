/*
 * キャラクターなどのテキストメッセージを出力する
 * 空のオブジェクトにアタッチする
 * "S"キーでメッセージを全表示→スキップ
 * 画面サイズに応じてメッセージの高さ座標を変更する必要が有る
 * (未実装)現在のストーリーの進行具合や話す回数に応じてメッセージを変える
 * <!> 3つの画像(Texture 2D)をInspector画面のMsgWindowで設定する必要がある <!> 
 * 2015/07/30 Thu - Guttyon
*/

using UnityEngine;
using System;

public class textMessage : MonoBehaviour {

	// ストーリーの進行具合によってメッセージを変更するために使用 (Global変数から取得するようにする。)
	public int storyNumber    = gameControll.storyNumber;	
	public int subStoryNumber = gameControll.subStoryNumber;	

	public int talksNumber;	// 話した回数によってメッセージを変更するために使用

	// --- テキストメッセージウィンドウの大きさ --- //
	public int textWindow_Y = 100; 
	public Texture2D textureToDisplay;

	// メッセージ
	private string text;					// 表示したいメッセージ
	public  static int    textLength;		// 表示したい文字列の長さ
	public  static bool   isTalk = false;	// トーク開始フラグ
	public  static float  waitMessage = 0;	// 文字表示時間

	private float  nextStringWaitTime = 0.1f;	// 次の文字の待ち時間
	
	// 外部からもアクセス可能にする
	public static string dispCharaName;
	public static string dispMessage;
	
	public static void dispMsg (string charaName = "???", string Message = "No Message"){

		dispCharaName = "  " + charaName;
		dispMessage = Message;	// 外部メッセージを代入
		textLength  = 0;		// 0文字目にリセット
		isTalk 		= true;		// 表示
		waitMessage = 0;
	}
	
	// Use this for initialization
	void Start () {
		// 半角74文字,5行
		dispMsg ("Nanashi"
		         , "半角74文字,5行まで。123456789012345678901234567890123456789012345678901234\n12345678901234567890123456789012345678901234567890123456789012345678901234\n12345678901234567890123456789012345678901234567890123456789012345678901234\n12345678901234567890123456789012345678901234567890123456789012345678901234\n12345678901234567890123456789012345678901234567890123456789012345678901234\n");
	}
	
	// Update is called once per frame
	void Update () {

		// Sキー - メッセージスキップ
		if (Input.GetKeyDown (KeyCode.S)) { 

			// メッセージを全て表示する前なら全て表示する
			if (textLength < dispMessage.Length) {
				textLength = dispMessage.Length;
			} else {
				// メッセージを全て表示した後なら非表示
				isTalk = false;	// 非表示
			}
		}

		// メッセージ表示状態の時のみ処理を行う
		if (isTalk) {

			// メッセージを1文字ずつ流す
			if (Time.time > nextStringWaitTime) {
				if (textLength < dispMessage.Length) {
					textLength++;
				}
				nextStringWaitTime = Time.time + 0.01f;
			}

			// メッセージを全て表示した後
			if( textLength >= dispMessage.Length ) {

				waitMessage += Time.deltaTime;

				// 待機した後非表示
				if( waitMessage > dispMessage.Length / 4 ){

					isTalk = false;	// 非表示
				}
			}
		}
	}

	public GUIStyle msgWindow;

	void OnGUI(){

		// 基準となる画面の幅
		const float screenWidth = 1136;

		// 基準サイズに対するウィンドウサイズと座標
		const float messageWidth  = 1100;
		const float messageHeight = 200;
		const float messagePos_X  = (screenWidth - messageWidth) / 2;

		/*
		 * 5:4   ... messagePos_Y= 690
		 * 4:3   ... messagePos_Y= 630
		 * 3:2   ... messagePos_Y= 540
		 * 16:9  ... messagePos_Y= 420
		 * 16:10 ... messagePos_Y= 490
		 * 
		 * iPad(1024*768) ... messagePos_Y= 630
		*/
		const float messagePos_Y  = 420;

		// 画面の端から1ピクセルを算出
		float factorSize = Screen.width / screenWidth;

		float messageX;
		float messageY;
		float messageW = messageWidth  * factorSize;
		float messageH = messageHeight * factorSize;

		// フォントスタイル
		GUIStyle messageStyle = new GUIStyle ();
		messageStyle.fontSize = (int)(25 * factorSize);
		msgWindow.fontSize = (int)(20 * factorSize);

		// メッセージ表示
		if (isTalk) {
			
			// メッセージ用ウィンドウ
			msgWindow.normal.textColor = Color.yellow;
			messageX = messagePos_X * factorSize;
			messageY = messagePos_Y * factorSize;
			GUI.Box (new Rect( messageX, messageY, messageW, messageH ), dispCharaName, msgWindow);

			// メッセージ影
			messageStyle.normal.textColor = Color.black;
			messageX = (messagePos_X + 22) * factorSize;
			messageY = (messagePos_Y + 34) * factorSize;
			GUI.Label (new Rect( messageX, messageY, messageW, messageH ), dispMessage.Substring(0, textLength), messageStyle);

			// メッセージ
			messageStyle.normal.textColor = Color.white;
			messageX = (messagePos_X + 20) * factorSize;
			messageY = (messagePos_Y + 32) * factorSize;
			GUI.Label (new Rect( messageX, messageY, messageW, messageH ), dispMessage.Substring(0, textLength), messageStyle);
		}
	}
}

