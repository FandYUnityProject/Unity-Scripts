/*
 * 全てのアイテム取得/未取得を管理
 * 2015/07/30 Fri - Guttyon
*/

using UnityEngine;
using System.Collections;

public class itemControll : MonoBehaviour {
	
	public int effectByItem = 0; // 効果別アイテムの数
	public int kindOfItem   = 0; // 種類/能力アイテムの数

	// 全アイテムを二次元配列[効果別, 種類/能力別（など）]で管理
	public static bool[,] allItem;

	// Use this for initialization
	void Start () {

		// 初期化
		allItem = new bool[effectByItem, kindOfItem];

		// セーブデータからアイテム獲得フラグを取得
		// allItem[0][0] = PlayerPrefs.GetInt("isItem[0][0]");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
