#pragma strict

/*
 * 移動( 2Dゲーム用 )
 * プログラム適用時、適用するオブジェクトに”Rididbody2D”を適用させる必要がある。
 *  <!>ゼルダ式移動を採用する場合はJumpスクリプトを外してください。<!>
 * 2015/07/26 Sun - Guttyon
*/

public var isMoveMode_Mario : boolean = false;	// マリオ式移動（横　：重力有り用）
public var isMoveMode_Zelda : boolean = false;	// ゼルダ式移動（縦横：重力無し用）
public var gravityMario : float = 1.01f;		// マリオ式の重力加速度
public var gravityZelda : float = 10.0f;		// ゼルダ式の重力加速度
	
public var playerMoveSpeed : float = 5.0f;	// 移動スピード
	
function Start () {

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
		this.GetComponent.<Rigidbody2D>().gravityScale = gravityMario;
	} else {
		this.GetComponent.<Rigidbody2D>().gravityScale = gravityZelda;
	}
	
}

function Update () {

	var horizonalMove : float = Input.GetAxisRaw("Horizontal");	// 右・左

	if (isMoveMode_Mario) {
		this._moveCharactor (Vector2.right * playerMoveSpeed * horizonalMove);
	}
	if (isMoveMode_Zelda) {
		var verticalMove : float = Input.GetAxisRaw ("Vertical");	// 上・下(ゼルダ式移動)

		// 移動する向きを求める
		var direction : Vector2 = new Vector2 (horizonalMove, verticalMove).normalized;
		// 移動する向きとスピードを代入する
		this.GetComponent.<Rigidbody2D>().velocity = direction * playerMoveSpeed;
	}

}


/// <summary>
/// キャラクターを移動させる
/// </summary>
/// <param name="moveSpeed">移動スピード</param>
private function _moveCharactor(jumpForce: Vector2)
{
	this.GetComponent.<Rigidbody2D>().AddForce( jumpForce );
}