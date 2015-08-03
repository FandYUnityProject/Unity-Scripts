/*
 * 全てのメインメインシナリオ / サブシナリオを管理
 * 2015/07/30 Fri - Guttyon
*/

using UnityEngine;
using System.Collections;

public class scenarioControll : MonoBehaviour {

	public static int mainScenarioNumber = 0; // 現在のメインシナリオ番号

	public int kindOfSubScenario  = 0; // サブシナリオの種類の数
	public int subScenarioNumber  = 0; // 現在のサブシナリオ番号

	// 全サブシナリオを二次元配列で管理
	public static bool[,] allSubScenario;

	// Use this for initialization
	void Start () {

		// 初期化
		allSubScenario = new bool[kindOfSubScenario, subScenarioNumber];
		
		// セーブデータからメインシナリオ番号を取得
		// allSubScenario[0][0] = PlayerPrefs.GetInt("isSubScenario[0][0]"); 

		// セーブデータからサブシナリオフラグを取得
		// allSubScenario[0][0] = PlayerPrefs.GetInt("isSubScenario[0][0]"); 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
