/*
 * 現在、１、２つ前のマップ番地を管理
 * （未実装）ミニマップの表示と管理
 * "moveMapRockman.cs" と連携。
 * 2015/07/31 Fri - Guttyon
*/

using UnityEngine;
using System.Collections;

public class mapControll : MonoBehaviour {

	// 現在マップの番地を保存する変数
	public static int mapNumber_X;
	public static int mapNumber_Y;

	// 1つ前のマップの番地を保存する変数
	public static int oldMapNumber_X = 99999;
	public static int oldMapNumber_Y = 99999;

	// 2つ前のマップの番地を保存する変数
	public static int oldestMapNumber_X = 99999;
	public static int oldestMapNumber_Y = 99999;
	
	// Inspector画面で設定できるようにするための変数
	// ( static変数はInspectorに表示されない )
	public int reStartMapNumber_X_inspector;
	public int reStartMapNumber_Y_inspector;

	// --- public staticはどのスクリプトからでも値参照可能 --- //
	// 再開地点（マップ）
	public static int reStartMapNumber_X;
	public static int reStartMapNumber_Y;

	// Use this for initialization
	void Start () {

		/* --- セーブした再開地点を反映  --- */
		reStartMapNumber_X = PlayerPrefs.GetInt("01_reStartMapNumber_X");
		reStartMapNumber_Y = PlayerPrefs.GetInt("01_reStartMapNumber_Y");

		mapNumber_X = reStartMapNumber_X;
		mapNumber_Y = reStartMapNumber_Y;

		// デバッグ
		// Debug.Log (mapNumber_X + "_" + mapNumber_Y + "_" + oldMapNumber_X + "_" + oldMapNumber_Y + "_" + oldestMapNumber_X + "_" + oldestMapNumber_Y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void mapInfoUpdate(int mapNum_X, int mapNum_Y){

		// 1,2つ前のマップ番地を更新
		oldestMapNumber_X = oldMapNumber_X;
		oldestMapNumber_Y = oldMapNumber_Y;
		oldMapNumber_X    = mapNumber_X;
		oldMapNumber_Y    = mapNumber_Y;

		// 最新のマップ番地を更新
		mapNumber_X       = mapNum_X;
		mapNumber_Y       = mapNum_Y;

		// デバッグ
		// Debug.Log (mapNumber_X + "_" + mapNumber_Y + "_" + oldMapNumber_X + "_" + oldMapNumber_Y + "_" + oldestMapNumber_X + "_" + oldestMapNumber_Y);
	}
}
