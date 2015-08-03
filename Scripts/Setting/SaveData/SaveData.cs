using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		/*
		 * SaveDataのルール 
		 * 		ex.セーブデータ1の場合
		 * 	 	DataName:01_XXXXXX
		*/

		/********************
		 *** --- Save --- ***
		*********************/
		// セーブデータ1に保存するデータ
		if (GUI.Button(new Rect(5, 5, 200, 50),   "Save01")) {

			// FloatData
			PlayerPrefs.SetFloat("01_FloatData01", 1.0f);
			PlayerPrefs.SetFloat("01_FloatData02", 2.0f);
			PlayerPrefs.SetFloat("01_FloatData03", 3.0f);

			// IntData
			PlayerPrefs.SetInt("01_IntData01", 1);
			PlayerPrefs.SetInt("01_IntData02", 2);
			PlayerPrefs.SetInt("01_IntData03", 3);
			PlayerPrefs.SetInt("01_reStartMapNumber_X", 1);
			PlayerPrefs.SetInt("01_reStartMapNumber_Y", 0);


			// StringName
			PlayerPrefs.SetString("01_PlayerName", "NANASHI01");
			PlayerPrefs.SetString("01_PlayerTime", "11:11");
		}

		// セーブデータ2に保存するデータ
		if (GUI.Button(new Rect(215, 5, 200, 50),   "Save02")) {
			
			// FloatData
			PlayerPrefs.SetFloat("02_FloatData01", 11.0f);
			PlayerPrefs.SetFloat("02_FloatData02", 22.0f);
			PlayerPrefs.SetFloat("02_FloatData03", 33.0f);
			
			// IntData
			PlayerPrefs.SetInt("02_IntData01", 11);
			PlayerPrefs.SetInt("02_IntData02", 22);
			PlayerPrefs.SetInt("02_IntData03", 33);
			
			// StringName
			PlayerPrefs.SetString("02_PlayerName", "NANASHI02");
			PlayerPrefs.SetString("02_PlayerTime", "22:22");
		}

		// セーブデータ3に保存するデータ
		if (GUI.Button(new Rect(425, 5, 200, 50),   "Save03")) {
			
			// FloatData
			PlayerPrefs.SetFloat("03_FloatData01", 111.0f);
			PlayerPrefs.SetFloat("03_FloatData02", 222.0f);
			PlayerPrefs.SetFloat("03_FloatData03", 333.0f);
			
			// IntData
			PlayerPrefs.SetInt("03_IntData01", 111);
			PlayerPrefs.SetInt("03_IntData02", 222);
			PlayerPrefs.SetInt("03_IntData03", 333);
			
			// StringName
			PlayerPrefs.SetString("03_PlayerName", "NANASHI03");
			PlayerPrefs.SetString("03_PlayerTime", "33:33");
		}

		
		/********************
		 *** --- Load --- ***
		*********************/
		// セーブデータ1からロードするデータ
		if (GUI.Button(new Rect(5, 60, 200, 50),   "Load01")) {
			
			// FloatData
			float floatData01 = PlayerPrefs.GetFloat("01_FloatData01");
			float floatData02 = PlayerPrefs.GetFloat("01_FloatData02");
			float floatData03 = PlayerPrefs.GetFloat("01_FloatData03");
			
			// IntData
			int intData01 = PlayerPrefs.GetInt("01_IntData01");
			int intData02 = PlayerPrefs.GetInt("01_IntData02");
			int intData03 = PlayerPrefs.GetInt("01_IntData03");
			
			// StringName
			string stringDataPlayerName = PlayerPrefs.GetString("01_PlayerName");
			string stringDataPlayerTime = PlayerPrefs.GetString("01_PlayerTime");

			// Debug
			Debug.Log (floatData01 + ", " + floatData02 + ", " + floatData03);
			Debug.Log (intData01   + ", " + intData02   + ", " + intData03);
			Debug.Log (stringDataPlayerName + ", " + stringDataPlayerTime);
		}

		// セーブデータ2からロードするデータ
		if (GUI.Button(new Rect(215, 60, 200, 50),   "Load02")) {
			
			// FloatData
			float floatData01 = PlayerPrefs.GetFloat("02_FloatData01");
			float floatData02 = PlayerPrefs.GetFloat("02_FloatData02");
			float floatData03 = PlayerPrefs.GetFloat("02_FloatData03");
			
			// IntData
			int intData01 = PlayerPrefs.GetInt("02_IntData01");
			int intData02 = PlayerPrefs.GetInt("02_IntData02");
			int intData03 = PlayerPrefs.GetInt("02_IntData03");
			
			// StringName
			string stringDataPlayerName = PlayerPrefs.GetString("02_PlayerName");
			string stringDataPlayerTime = PlayerPrefs.GetString("02_PlayerTime");
			
			// Debug
			Debug.Log (floatData01 + ", " + floatData02 + ", " + floatData03);
			Debug.Log (intData01   + ", " + intData02   + ", " + intData03);
			Debug.Log (stringDataPlayerName + ", " + stringDataPlayerTime);
		}
		
		// セーブデータ3からロードするデータ
		if (GUI.Button(new Rect(425, 60, 200, 50),   "Load03")) {
			
			// FloatData
			float floatData01 = PlayerPrefs.GetFloat("03_FloatData01");
			float floatData02 = PlayerPrefs.GetFloat("03_FloatData02");
			float floatData03 = PlayerPrefs.GetFloat("03_FloatData03");
			
			// IntData
			int intData01 = PlayerPrefs.GetInt("03_IntData01");
			int intData02 = PlayerPrefs.GetInt("03_IntData02");
			int intData03 = PlayerPrefs.GetInt("03_IntData03");
			
			// StringName
			string stringDataPlayerName = PlayerPrefs.GetString("03_PlayerName");
			string stringDataPlayerTime = PlayerPrefs.GetString("03_PlayerTime");
			
			// Debug
			Debug.Log (floatData01 + ", " + floatData02 + ", " + floatData03);
			Debug.Log (intData01   + ", " + intData02   + ", " + intData03);
			Debug.Log (stringDataPlayerName + ", " + stringDataPlayerTime);
		}
		
		
		/********************
		 *** --- Delete --- ***
		*********************/
		// セーブデータ1のデータを削除する
		if (GUI.Button(new Rect(5, 115, 200, 50),   " Delete01")) {
			
			// FloatData
			PlayerPrefs.DeleteKey("01_FloatData01");
			PlayerPrefs.DeleteKey("01_FloatData02");
			PlayerPrefs.DeleteKey("01_FloatData03");
			
			// IntData
			PlayerPrefs.DeleteKey("01_IntData01");
			PlayerPrefs.DeleteKey("01_IntData02");
			PlayerPrefs.DeleteKey("01_IntData03");
			PlayerPrefs.DeleteKey("01_reStartMapNumber_X");
			PlayerPrefs.DeleteKey("01_reStartMapNumber_Y");
			
			// StringName
			PlayerPrefs.DeleteKey("01_PlayerName");
			PlayerPrefs.DeleteKey("01_PlayerTime");
		}
		
		// セーブデータ2のデータを削除する
		if (GUI.Button(new Rect(215, 115, 200, 50),   "Delete02")) {
			
			// FloatData
			PlayerPrefs.DeleteKey("02_FloatData01");
			PlayerPrefs.DeleteKey("02_FloatData02");
			PlayerPrefs.DeleteKey("02_FloatData03");
			
			// IntData
			PlayerPrefs.DeleteKey("02_IntData01");
			PlayerPrefs.DeleteKey("02_IntData02");
			PlayerPrefs.DeleteKey("02_IntData03");
			
			// StringName
			PlayerPrefs.DeleteKey("02_PlayerName");
			PlayerPrefs.DeleteKey("02_PlayerTime");
		}
		
		// セーブデータ3のデータを削除する
		if (GUI.Button(new Rect(425, 115, 200, 50),   "Delete03")) {
			
			// FloatData
			PlayerPrefs.DeleteKey("03_FloatData01");
			PlayerPrefs.DeleteKey("03_FloatData02");
			PlayerPrefs.DeleteKey("03_FloatData03");
			
			// IntData
			PlayerPrefs.DeleteKey("03_IntData01");
			PlayerPrefs.DeleteKey("03_IntData02");
			PlayerPrefs.DeleteKey("03_IntData03");
			
			// StringName
			PlayerPrefs.DeleteKey("03_PlayerName");
			PlayerPrefs.DeleteKey("03_PlayerTime");
		}
		
		// 全データを削除する
		if (GUI.Button(new Rect(5, 170, 200, 50),   " AllDelete")) {
			PlayerPrefs.DeleteAll();
		}

	}
}