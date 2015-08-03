/*
  * 敵の移動( 2Dゲーム用 )
  * プログラム適用時、適用するオブジェクトに”Rididbody2D”を適用させる必要がある。
  * Move...一方向移動
  * PingPong...往復移動
  * 2015/07/29 Wed - Guttyon
 */

using UnityEngine;
using System.Collections;

public class enemyMove2D : MonoBehaviour {
	
	public bool  isMove_X		= false;	// 敵を左右に動かす
	public bool  isMove_Y		= false;	// 敵を上下に動かす
	public bool  isPingPong_X	= false;	// 敵を左右に往復させる
	public bool  isPingPong_Y	= false;	// 敵を上下に往復させる

	public float enemyMoveSpeed_X   		= 5.0f;	// X軸の移動スピード
	public float enemyMoveSpeed_Y   		= 5.0f;	// Y軸の移動スピード
	
	public float sumPingPongTime_X	= 0.0f;	// 左右に往復させるためのタイマー
	public float sumPingPongTime_Y	= 0.0f;	// 上下にさせるためのタイマー
	public float pingPongLength_X	= 5.0f;	// 左右に往復する距離
	public float pingPongLength_Y	= 5.0f;	// 上下に往復する距離

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// 敵を左(右)に移動
		if (isMove_X) {
			
			transform.Translate(new Vector2(enemyMoveSpeed_X * Time.deltaTime, 0));
		}
		
		// 敵を上下に動かす場合、重力を0にする
		// 敵を上(下)に移動
		if (isMove_Y) {
			
			transform.Translate(new Vector2(0, enemyMoveSpeed_Y * Time.deltaTime));
			GetComponent<Rigidbody2D> ().gravityScale = 0;
		}


		// --- 往復移動時 ---- //
		// 敵を左(右)に往復
		if (isPingPong_X) {

			// 往復タイマーを加算
			if( sumPingPongTime_X < pingPongLength_X * 2 ){
				sumPingPongTime_X += Time.deltaTime;
			} else {
				sumPingPongTime_X = 0;
			}

			// 往復移動
			transform.position = new Vector2(Mathf.PingPong( sumPingPongTime_X * pingPongLength_X / ( 1 / ( enemyMoveSpeed_X / 5 )), pingPongLength_X)
				                            ,transform.position.y
				                            );
			}

		// 敵を上(下)に往復
		if (isPingPong_Y) {

			// 往復タイマーを加算
			if( sumPingPongTime_Y < pingPongLength_Y * 2 ){
				sumPingPongTime_Y += Time.deltaTime;
			} else {
				sumPingPongTime_Y = 0;
			}

			// 往復移動
			transform.position = new Vector2(transform.position.x
			                                 ,Mathf.PingPong( sumPingPongTime_Y * pingPongLength_Y / ( 1 / ( enemyMoveSpeed_Y / 5 )), pingPongLength_Y)
			                                 );
		}
	}

	/// <summary>
	/// 接触したオブジェクトのタグ/名前毎に処理
	/// </summary>
	/// <param name="coll">Player以外の物体</param>
	public void OnCollisionEnter2D(Collision2D coll)
	{
		
		// プレイヤーに接触した時の処理など
		switch (coll.gameObject.tag) {
		case "Player":
			// 処理内容
			
			break;
		}
		
		// プレイヤーに接触した時の処理など
		switch (coll.gameObject.name) {
		case " Player":
			// 処理内容
			
			break;
		}
	}
}
