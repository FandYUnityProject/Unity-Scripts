/*
 * ゲーム全体に影響する変数や関数をまとめたもの
 * アタッチするオブジェクト名は "gameControll" で統一する。
 * 2015/07/27 Mon - Guttyon
*/

using UnityEngine;
using System.Collections;

public class gameControll : MonoBehaviour {

	// 現在の(サブ)ストーリー進行具合
	public static int storyNumber;
	public static int subStoryNumber;

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
}
