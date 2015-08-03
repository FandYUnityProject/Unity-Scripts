/*
 * 2Dロックマン式カメラ移動
 * カメラの名前は”Main Camera”にすること。
 * Playerの名前は”Player”にすること。
 * "gameControll.cs" をgemeControllオブジェクト(ゲーム全体を管理する空のオブジェクト)にアタッチすること。
 * "mapControll"と連携。
 * 2015/07/26 Sun - Guttyon
*/

/*
 * カメラ座標取得例
 * 	Top,Left = (-16, 12 )
 * 	Bottom,Right = (16 , -12)
*/

/*
 * mapの番地イメージ
 *  [
 *    [-2,2]  ,[-1,2]  ,[0,2]  ,[1,2]  ,[2,2]
 *   ,[-2,1]  ,[-1,1]  ,[0,1]  ,[1,1]  ,[2,2]
 *   ,[-2,0]  ,[-1,0]  ,[0,0]  ,[1,0]  ,[2,0]
 *   ,[-2,-1] ,[-1,-1] ,[0,-1] ,[1,-1] ,[2,-1]
 *   ,[-2,-2] ,[-1,-2] ,[0,-2] ,[1,-2] ,[2,-2]
 *  ]
*/
using UnityEngine;
using System.Collections;

public class moveMapRockman : MonoBehaviour {

	private Camera mainCamera;
	
	// cameraオブジェクト
	private GameObject cameraObject;
	// cameraの初期座標
	public  Vector3    cameraStartPosition;
	// playerオブジェクト
	private GameObject playerObject;

	// 現在のmapの端座標を保存する変数
	public float mapLeftPosition;	// Left
	public float mapRightPosition;	// Right
	public float mapTopPosition;	// Top
	public float mapBottomPosition;	// Bottom

	// mapの縦横の長さを保存する変数
	public float mapWidth;	//横
	public float mapHeight;	//縦

	// mapの番地を保存する変数
	public int   mapNumber_X;
	public int   mapNumber_Y;

	// Use this for initialization
	void Start () {
				
		// カメラオブジェクトを取得
		cameraObject = GameObject.Find ("Main Camera");
		// カメラを取得
		mainCamera = cameraObject.GetComponent<Camera> ();
		// カメラを取得の初期座標を取得
		cameraStartPosition = mainCamera.transform.position;

		// Playerオブジェクトを取得
		playerObject = GameObject.Find ("Player");
		
		// 座標値を出力
		Debug.Log ("Left,  Top" + getScreenTopLeft().x + ", " + getScreenTopLeft().y);
		Debug.Log ("Right, Bottom" + getScreenBottomRight().x + ", " + getScreenBottomRight().y);

		// 初期マップの座標取得
		mapLeftPosition   = getScreenTopLeft ().x;
		mapRightPosition  = getScreenBottomRight ().x;
		mapTopPosition    = getScreenTopLeft ().y;
		mapBottomPosition = getScreenBottomRight ().y;

		// マップの縦横の長さ取得
		mapWidth  = getScreenBottomRight ().x * 2.0f;
		mapHeight = getScreenTopLeft ().y * 2.0f;

		// 初期マップ番地を取得( gameControll.cs で設定 )
		mapNumber_X = mapControll.reStartMapNumber_X;
		mapNumber_Y = mapControll.reStartMapNumber_Y;
		
		// 初期マップ番地に応じて開始地点にカメラ配置
		mainCamera.transform.position = new Vector3( 
		             cameraStartPosition.x + (mapWidth  * mapNumber_X)
		            ,cameraStartPosition.y + (mapHeight * mapNumber_Y)
		            ,cameraStartPosition.z
		            );

		// 初期マップ番地に応じて開始地点にPlayer配置
		playerObject.transform.position = new Vector3( 
		             mapWidth * mapNumber_X
		            ,mapHeight * mapNumber_Y
		            ,0.0f
		            );

		// マップの座標を再取得  (ここより前にコーディングすると、Update()の条件式にも引っかかり、値が意図しないものとなる。)
		mapLeftPosition   = mapLeftPosition   + cameraStartPosition.x + (mapWidth  * mapNumber_X);
		mapRightPosition  = mapRightPosition  + cameraStartPosition.x + (mapWidth  * mapNumber_X);
		mapTopPosition    = mapTopPosition    + cameraStartPosition.y + (mapHeight * mapNumber_Y);
		mapBottomPosition = mapBottomPosition + cameraStartPosition.y + (mapHeight * mapNumber_Y);

	}

	// Update is called once per frame
	void Update () {

		/* --- Playerが画面端に行くとカメラを移動させる --- */

		// 左端
		if (playerObject.transform.position.x < mapLeftPosition) {
			mapNumber_X--;
			mainCamera.transform.position = new Vector3( (cameraStartPosition.x + (mapWidth * mapNumber_X))
			                                            ,(cameraStartPosition.y + (mapHeight * mapNumber_Y))
			                                            , cameraStartPosition.z);
			mapLeftPosition  = mapLeftPosition - mapWidth;
			mapRightPosition = mapRightPosition - mapWidth;

			// マップ管理更新
			mapControll.mapInfoUpdate( mapNumber_X, mapNumber_Y );
			// 敵配置
			enemyPlacement.enemyPlacements(mapNumber_X, mapNumber_Y);
		}
		// 右端
		if (playerObject.transform.position.x > mapRightPosition) {
			mapNumber_X++;
			mainCamera.transform.position = new Vector3( (cameraStartPosition.x + (mapWidth * mapNumber_X))
			                                            ,(cameraStartPosition.y + (mapHeight * mapNumber_Y))
			                                            , cameraStartPosition.z);
			mapLeftPosition  = mapLeftPosition + mapWidth;
			mapRightPosition = mapRightPosition + mapWidth;
			
			// マップ管理更新
			mapControll.mapInfoUpdate( mapNumber_X, mapNumber_Y );
			// 敵配置
			enemyPlacement.enemyPlacements(mapNumber_X, mapNumber_Y);
		}
		// 上端
		if (playerObject.transform.position.y > mapTopPosition) {
			mapNumber_Y++;
			mainCamera.transform.position = new Vector3( (cameraStartPosition.x + (mapWidth * mapNumber_X))
			                                            ,(cameraStartPosition.y + (mapHeight * mapNumber_Y))
			                                            , cameraStartPosition.z);
			mapTopPosition    = mapTopPosition    + mapHeight;
			mapBottomPosition = mapBottomPosition + mapHeight;
			
			// マップ管理更新
			mapControll.mapInfoUpdate( mapNumber_X, mapNumber_Y );
			// 敵配置
			enemyPlacement.enemyPlacements(mapNumber_X, mapNumber_Y);
		}
		// 下端
		if (playerObject.transform.position.y < mapBottomPosition) {
			mapNumber_Y--;
			mainCamera.transform.position = new Vector3( (cameraStartPosition.x + (mapWidth * mapNumber_X))
			                                            ,(cameraStartPosition.y + (mapHeight * mapNumber_Y))
			                                            , cameraStartPosition.z);
			mapTopPosition    = mapTopPosition    - mapHeight;
			mapBottomPosition = mapBottomPosition - mapHeight;
			
			// マップ管理更新
			mapControll.mapInfoUpdate( mapNumber_X, mapNumber_Y );
			// 敵配置
			enemyPlacement.enemyPlacements(mapNumber_X, mapNumber_Y);
		}
	}

	private Vector3 getScreenTopLeft() {

		// 画面の左上を取得
		Vector3 topLeft = mainCamera.ScreenToWorldPoint (Vector3.zero);

		// 上下反転させる
		topLeft.Scale(new Vector3(1f, -1f, 1f));
		return topLeft;
	}
	
	private Vector3 getScreenBottomRight() {

		// 画面の右下を取得
		Vector3 bottomRight = mainCamera.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));

		// 上下反転させる
		bottomRight.Scale(new Vector3(1f, -1f, 1f));
		return bottomRight;
	}
}
