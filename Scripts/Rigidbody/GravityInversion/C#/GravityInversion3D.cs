/*
  * 重力反転( 3Dゲーム用 )
  ※ プログラム適用時、適用するオブジェクトに”Rididbody”を適用させる必要がある。
  * 2015/07/25 Sat - Guttyon
 */

using UnityEngine;
using System.Collections;

public class GravityInversionD : MonoBehaviour {
	
	bool isGravity = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Spaceキー入力を受け取る
		if (Input.GetKeyDown (KeyCode.Space)){
			isGravity = !isGravity;
		}
		
		if ( isGravity ){
			Physics.gravity = Vector3.down;
		} else {
			Physics.gravity = Vector3.up;
		}
		
	}
}
