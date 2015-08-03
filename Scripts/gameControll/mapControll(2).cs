/*
 * 現在、１、２つ前のマップ番地を管理
 * （未実装）ミニマップの表示と管理
 * "moveMapRockman.cs" と連携。
 * 2015/07/30 Fri - Guttyon
*/

using UnityEngine;
using System.Collections;

public class mapControll : MonoBehaviour {

	// 現在マップの番地を保存する変数
	public static int mapNumber_X;
	public static int mapNumber_Y;

	// 1つ前のマップの番地を保存する変数 (※”-1”は一度もマップを移動していない場合)
	public static int oldMapNumber_X = -1;
	public static int oldMapNumber_Y = -1;

	// 2つ前のマップの番地を保存する変数 (※”-1”は2マップも移動していない場合)
	public static int oldestMapNumber_X = -1;
	public static int oldestMapNumber_Y = -1;

	
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void mapInfoUpdate_X(int mapNum_X){

		// 1,2つ前のマップ番地を更新
		oldestMapNumber_X = oldMapNumber_X;
		oldMapNumber_X    = mapNumber_X;

		// 最新のマップ番地を更新
		mapNumber_X       = mapNum_X;
	}

	public static void mapInfoUpdate_Y(int mapNum_Y){
		
		// 1,2つ前のマップ番地を更新
		oldestMapNumber_Y = oldMapNumber_Y;
		oldMapNumber_Y    = mapNumber_Y;
		
		// 最新のマップ番地を更新
		mapNumber_Y       = mapNum_Y;
	}
}
