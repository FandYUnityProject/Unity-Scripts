/*
 * OSに応じて共有可能なアプリ（SNS)一覧を表示
 * 2015/08/04 Tue - Guttyon
*/

using UnityEngine;
using System.Collections;

public class SocialButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	string imagePath
	{
		get
		{
			return Application.persistentDataPath + "/image.png";
		}
	}
	
	void OnGUI () {
		
		// Twitter Share
		if (GUI.Button (new Rect (215, 170, 200, 50), "SNS Share")) {

			SocialConnector.Share("Message", "http://gameSite.com", imagePath);
		}

	}
}
