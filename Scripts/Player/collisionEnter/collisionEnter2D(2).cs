using UnityEngine;
using System.Collections;

public class collisionEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// 接触したオブジェクトのタグ/名前毎に処理
	/// </summary>
	/// <param name="coll">Player以外の物体</param>
	public void OnCollisionEnter2D(Collision2D coll)
	{

		// 接触した物体のタグ毎に処理
		switch (coll.gameObject.tag) {
			case "Enemy":
			// 処理内容

			break;

			case "Item":
			// 処理内容
			Destroy(coll.gameObject);
			break;
		}

		// 接触した物体の名前毎に処理
		switch (coll.gameObject.name) {
		case "bossName":
			// 処理内容
			
			break;
			
		case "Item01":
			// 処理内容
			Destroy(coll.gameObject);
			break;
		}
	}
}
