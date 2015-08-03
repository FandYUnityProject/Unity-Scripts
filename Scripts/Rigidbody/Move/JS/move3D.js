#pragma strict

/*
 * 移動( 3Dゲーム用 )
 * プログラム適用時、適用するオブジェクトに”Rididbody”, ""CupsleColliderを適用させる必要がある。
 * 2015/07/26 Sun - Guttyon
*/
	
public var lookSmoother : float = 3.0f;			// a smoothing setting for camera motion
public var useCurves : boolean  = true;			// Mecanimでカーブ調整を使うか設定する

// このスイッチが入っていないとカーブは使われない
public var useCurvesHeight : float = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）
		
// 以下キャラクターコントローラ用パラメタ
// 前進速度
public var forwardSpeed  : float = 7.0f;
// 後退速度
public var backwardSpeed : float = 2.0f;
// 旋回速度
public var rotateSpeed   : float = 2.0f;
// ジャンプ威力
public var jumpPower : float = 3.0f; 
// キャラクターコントローラ（カプセルコライダ）の参照
private var coll : CapsuleCollider;
private var rb : Rigidbody;
// キャラクターコントローラ（カプセルコライダ）の移動量
private var velocity : Vector3;
// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
private var orgColHight : float;
private var orgVectColCenter : Vector3 ;
		
private var cameraObject : GameObject;	// メインカメラへの参照
	
function Start () {
	// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
	coll = GetComponent.<CapsuleCollider>();
	rb   = GetComponent.<Rigidbody>();

	//メインカメラを取得する
	cameraObject = GameObject.FindWithTag ("MainCamera");
	
	// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
	orgColHight = coll.height;
	orgVectColCenter = coll.center;
}

function FixedUpdate () {
	var h : float = Input.GetAxis ("Horizontal");				// 入力デバイスの水平軸をhで定義
	var v : float = Input.GetAxis ("Vertical");				// 入力デバイスの垂直軸をvで定義
	rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする
			
	// 以下、キャラクターの移動処理
	velocity = new Vector3 (0, 0, v);		// 上下のキー入力からZ軸方向の移動量を取得
	// キャラクターのローカル空間での方向に変換
	velocity = transform.TransformDirection (velocity);
	//以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
	if (v > 0.1) {
		velocity *= forwardSpeed;		// 移動速度を掛ける
	} else if (v < -0.1) {
		velocity *= backwardSpeed;	// 移動速度を掛ける
	}
		
	// 上下のキー入力でキャラクターを移動させる
	transform.localPosition += velocity * Time.fixedDeltaTime;
			
	// 左右のキー入力でキャラクタをY軸で旋回させる
	transform.Rotate (0, h * rotateSpeed, 0);
}