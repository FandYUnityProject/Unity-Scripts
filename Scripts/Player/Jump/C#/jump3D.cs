/*
  * ジャンプ( 3Dゲーム用 )
  ※ プログラム適用時、適用するオブジェクトに”Rididbody”を適用させる必要がある。
  * 2015/07/26 Sun - Guttyon
 */

using UnityEngine;
using System.Collections;

public class jump3D : MonoBehaviour {
	
	public float jumpPower    = 400.0f;	// ジャンプ力
	public bool  isDoubleJump = true;	// 2段ジャンプ可能か
	
	private bool isJump    = false;		// ジャンプ中か
	private int  jumpCount = 0;			// 回目のジャンプか（2段ジャンプ可能時のみ）
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
	private void _jumpCharactor(Vector2 jumpForce)
	{
		this.GetComponent<Rigidbody>().AddForce( jumpForce );
	}
	
	/// <summary>
	/// 接触した（=着地）
	/// </summary>
	/// <param name="coll">Player以外の物体</param>
	public void OnCollisionEnter(Collision coll)
	{
		jumpCount = 0;
		isJump    = false;
	}
	
	/// <summary>
	/// 接触状態から離れた（=ジャンプ開始）
	/// </summary>
	/// <param name="coll">Player以外の物体</param>
	public void OnCollisionExit(Collision coll)
	{
		isJump = true;
	}
}