/*
 * 指定したシーンに移動する
 * マリオでいうゴールフラッグ的なものににアタッチすることを基本とする。
 * 2015/07/28 Tue - Guttyon
*/

using UnityEngine;
using System.Collections;

public class sceanChange : MonoBehaviour {

	// public staticはシーンが移動しても参照可能
	public static string sceanName = "StartMenu";

	// getter
	public static string getSceanName() {
		return sceanName;
	}

	// Use this for initialization
	void Start () {
	
		/* 
		 * DontDestroyOnload("GameObjectName");
		 * シーンを切り替えてもアタッチしたGameObjectを削除しないようにする
		 * gameControllやシーン遷移プログラムなど、ゲーム全体に影響するプログラムに使用
		*/
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		// 基本、プレイヤーに接触すると次のシーンに移動
		if (coll.gameObject.name == "Player") {

			// 現在のシーン名に合わせて、次のシーンに移動
			if (Application.loadedLevelName == "sceanName") {
				Application.LoadLevel ("nextSceanName");
			}
		}
	}
}
