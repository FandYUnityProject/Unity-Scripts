using UnityEngine;
using System.Collections;

public class triggerEnter2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// 接触したトリガーのタグ/名前毎に処理
	/// </summary>
	/// <param name="other">接触したトリガー</param>
	public void OnCollisionEnter2D(Collision2D other)
	{
		
		// 接触した物体のタグ毎に処理
		switch (other.gameObject.tag) {
		case "Zone":
			// 処理内容
			
			break;
			
		case "Item":
			// 処理内容

			break;
		}
		
		// 接触した物体の名前毎に処理
		switch (other.gameObject.name) {
		case "slowZone":
			// 処理内容
			
			break;
			
		case "Item01":
			// 処理内容

			break;
		}
	}
}
