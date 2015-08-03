#pragma strict

 /*
  * ジャンプ( 3Dゲーム用 )
  ※ プログラム適用時、適用するオブジェクトに”Rididbody”を適用させる必要がある。
  * 2015/07/26 Sun - Guttyon
 */
 
public var jumpPower    : float   = 400.0f;	// ジャンプ力
public var isDoubleJump : boolean = true;	// 2段ジャンプ可能か

private var isJump : boolean  = false;		// ジャンプ中か
private var jumpCount : int   = 0;			// 何回目のジャンプか（2段ジャンプ可能時のみ）

function Start () {

}

function Update () {

	// Spaceキー - ジャンプ
    if (Input.GetKeyDown(KeyCode.Space)){
    
    	jumpCount++;
    	
    	if( isDoubleJump ){
    		if( jumpCount <= 2 ){		
    			_jumpCharactor( Vector2.up * jumpPower );
    		}
    	} else {
    		if( !isJump ){
    			_jumpCharactor( Vector2.up * jumpPower );
    		}
    	}
	}
}

/// <summary>
/// キャラクターをジャンプさせる
/// </summary>
/// <param name="force">ジャンプ力</param>   
private function _jumpCharactor( jumpForce ){
	
	this.GetComponent.<Rigidbody>().AddForce( jumpForce );
}

/// <summary>
/// 接触した（=着地）
/// </summary>
/// <param name="coll">Player以外の物体</param>
public function OnCollisionEnter(coll: Collision)
{
	jumpCount = 0;
	isJump    = false;
}

/// <summary>
/// 接触状態から離れた（=ジャンプ開始）
/// </summary>
/// <param name="coll">Player以外の物体</param>
public function OnCollisionExit(coll: Collision)
{
	isJump = true;
}