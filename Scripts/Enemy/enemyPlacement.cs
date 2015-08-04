/*
 * 敵の配置を行う
 * 現在と１つ前のマップの敵配置を管理
 * ２つ前のマップの敵は全て削除する
 * アタッチする敵の名前は原則”Enemy”とする
 * "mapControll.cs" と連携。
 * 
 * 2015/07/31 Fri - Guttyon
*/

using UnityEngine;
using System.Collections;

public class enemyPlacement : MonoBehaviour {

	public static Camera mainCamera;
	// cameraオブジェクト
	public static GameObject cameraObject;
	// cameraの初期座標
	public static  Vector3    cameraStartPosition;

	// Use this for initialization
	void Start() {
		
		// カメラオブジェクトを取得
		cameraObject = GameObject.Find ("Main Camera");
		// カメラを取得
		mainCamera = cameraObject.GetComponent<Camera> ();
		// カメラを取得の初期座標を取得
		cameraStartPosition = mainCamera.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// マップ番地や以前通過したマップに応じて敵を配置
	public static void enemyPlacements (int mapNum_X, int mapNum_Y){

		// 移動したマップが１つ前のマップなら、２つ前のマップを削除するだけで何もしない
		if (mapNum_X == mapControll.oldestMapNumber_X && mapNum_Y == mapControll.oldestMapNumber_Y) {
			return;
		}

		// --- 2つ前のマップの敵を全て削除する --- //
		// ゲーム上の全てのオブジェクトを取得
		foreach (GameObject allObj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
		{
			// シーン上に２つ前のマップの敵（Enemy_X番地_Y番地)が存在したら削除
			if (allObj.name == "Enemy_" + mapControll.oldestMapNumber_X + "_" + mapControll.oldestMapNumber_Y )
			{
				// ２つ前のマップの敵を全て削除
				Destroy(allObj);
			}
		}

		// --- 現在のマップを番地に合わせて敵キャラを配置する --- //
		// カメラを取得の座標を取得
		cameraStartPosition = mainCamera.transform.position;

		// 敵キャラ複製の準備をする
		GameObject originalEnemy_01 = GameObject.Find("Enemy");
		//GameObject copyEnemy = Object.Instantiate (originalEnemy_01) as GameObject;

		// マップ番地に合わせて敵キャラを配置していく
		switch (mapNum_X) {
		case -1:
			switch(mapNum_Y){
			case 0:

				/*
				 * 敵の配置と名前付け
				 * 第一引数：コピーする敵
				 * 第二引数：番地内の敵の配置_X（中心：０,０）
				 * 第三引数：番地内の敵の配置_Y（中心：０,０）
				 * 第四引数：マップのX番地
	 			 * 第五引数：マップのY番地
	 			 */
				Placement_Naming( originalEnemy_01,  -10, 0, mapNum_X, mapNum_Y);
				Placement_Naming( originalEnemy_01,  -10, 10, mapNum_X, mapNum_Y);
				break;
				
			case 1:
				Placement_Naming( originalEnemy_01,  -10, 0, mapNum_X, mapNum_Y);
				break;
			}

			break;
		case 0:

			switch(mapNum_Y){
			case 0:
				Placement_Naming( originalEnemy_01,  -10, 0, mapNum_X, mapNum_Y);
				break;

			case 1:
				Placement_Naming( originalEnemy_01,  -10, 0, mapNum_X, mapNum_Y);
				break;
			}

			break;

		case 1:
			switch(mapNum_Y){
			case 0:
				Placement_Naming( originalEnemy_01,  -10, 0, mapNum_X, mapNum_Y);
				break;
				
			case 1:
				Placement_Naming( originalEnemy_01,  -10, 0, mapNum_X, mapNum_Y);
				break;
			}
			break;
		}
	}

	/*
	 * 指定した敵をコピーして配置し、番地に応じた名前を付ける 
	 * 
	 * 第一引数：コピーする敵
	 * 第二引数：番地内の敵の配置_X（中心：０,０）
	 * 第三引数：番地内の敵の配置_Y（中心：０,０）
	 * 第四引数：マップのX番地
	 * 第五引数：マップのY番地
	*/
	public static void Placement_Naming(GameObject originalEnemy, int placement_X = 0, int placement_Y = 0, int mapNum_X = 0, int mapNum_Y = 0){

		originalEnemy = GameObject.Find("Enemy");
		GameObject copyEnemy = Object.Instantiate (originalEnemy) as GameObject;

		// 配コピーした敵を配置する
		copyEnemy.transform.position = new Vector3(cameraStartPosition.x + placement_X, cameraStartPosition.y + placement_Y, 0);

		// 敵キャラの名前を（Enemy_X番地_Y番地）に設定する
		copyEnemy.name = "Enemy" + "_" + mapNum_X + "_" + mapNum_Y;
	}
}






