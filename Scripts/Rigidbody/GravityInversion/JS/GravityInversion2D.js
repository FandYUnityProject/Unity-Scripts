#pragma strict

 /*
  * 重力反転( 2Dゲーム用 )
  ※ プログラム適用時、適用するオブジェクトに”Rididbody2D”を適用させる必要がある。
  * 2015/07/25 Sat - Guttyon
 */
 
private var isGravity : boolean = true;

function Start () {

}

function Update () {
	
	// Spaceキー入力を受け取る
    if (Input.GetKeyDown (KeyCode.Space)){
    	isGravity = !isGravity;
	}
	
	if ( isGravity ){
		Physics2D.gravity = Vector2.down;
	} else {
		Physics2D.gravity = Vector2.up;
	}
}