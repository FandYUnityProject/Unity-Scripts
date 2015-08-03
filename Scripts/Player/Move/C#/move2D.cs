/*
  * 移動( 2Dゲーム用 )
  * プログラム適用時、適用するオブジェクトに”Rididbody2D”を適用させる必要がある。
  *  <!>ゼルダ式移動を採用する場合はJumpスクリプトを外してください。<!>
  * 2015/07/26 Sun - Guttyon
 */

using UnityEngine;
using System.Collections;

public class move2D : MonoBehaviour {

	public bool  isMoveMode_Mario = false;	// マリオ式移動（横　：重力有り用）
	public bool  isMoveMode_Zelda = false;	// ゼルダ式移動（縦横：重力無し用）
	public float gravityMario     = 1.01f;	// マリオ式の重力加速度
	public float gravityZelda     = 10.0f;	// ゼルダ式の重力加速度
	
	public float playerMoveSpeed  = 5.0f;	// 移動スピード

	// Use this for initialization
	void Start () {

		// 両方の移動式フラグがTRUE/FALSEの場合、マリオ式移動を採用
		if (!isMoveMode_Mario && !isMoveMode_Zelda) {
			isMoveMode_Mario = true;
		} else if (isMoveMode_Mario) {
			isMoveMode_Zelda = false;
		} else if (isMoveMode_Zelda) {
			isMoveMode_Mario = false;
		} else {
			isMoveMode_Mario = true;
		}

		if (isMoveMode_Mario) {
			GetComponent<Rigidbody2D>().gravityScale = gravityMario;
		} else {
			GetComponent<Rigidbody2D>().gravityScale = gravityZelda;
		}
	}
	
	// Update is called once per frame
	void Update () {

		float horizonalMove = Input.GetAxisRaw("Horizontal");	// 右・左

		if (isMoveMode_Mario) {
			this._moveCharactor (Vector2.right * playerMoveSpeed * horizonalMove);
		}
		if (isMoveMode_Zelda) {
			float verticalMove = Input.GetAxisRaw ("Vertical");	// 上・下(ゼルダ式移動)

			// 移動する向きを求める
			Vector2 direction = new Vector2 (horizonalMove, verticalMove).normalized;
			// 移動する向きとスピードを代入する
			GetComponent<Rigidbody2D>().velocity = direction * playerMoveSpeed;
		}
	}

	/// <summary>
	/// キャラクターを移動させる
	/// </summary>
	/// <param name="moveSpeed">移動スピード</param>
	private void _moveCharactor(Vector2 jumpForce)
	{
		this.GetComponent<Rigidbody2D>().AddForce( jumpForce );
	}
}
