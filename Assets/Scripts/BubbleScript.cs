using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class BubbleScript : MonoBehaviour {

	Animator anim;
	private int frame;
	public GameObject master;
	private GameObject clone;
	public static int counter = 0;
	private Rigidbody2D rigidBody;
	private bool isDetroyed = false;
	private float defaultGravity = -0.1f;
    public Text countText;
    public Text winText;
    //private int count;
    public AudioClip burstSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

  
  

    public class Global
    {
        public static int count = 0;
    }
    

    // Use this for initialization

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        
    }

    void Start () {
		anim = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.gravityScale = defaultGravity;
        
        SetCountText();
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Frame: " + frame);
		frame++;

	}

	void OnMouseDown()
	{
		if(Input.GetMouseButton(0)&&!isDetroyed)
		{
			isDetroyed = true;
			playAnimation ("bubble_burst");
            source.PlayOneShot(burstSound, 1F);
            regenerateBubble ();
            Global.count = Global.count + 1;
            SetCountText();
        }
	}

	/** OnClick event
	 */ 
	private void regenerateBubble ()
	{
			clone = Instantiate (master, GeneratedPosition (), Quaternion.identity) as GameObject;
			master.GetComponent<Rigidbody2D> ().gravityScale = 0.0F;
			Destroy (master,1);
	}

	private void playAnimation(string animName)
	{
		anim.Play(animName,-1,0f);
	}

	IEnumerator Waiting()
	{
		Debug.Log("Waiting for bubble to be burst...");
		yield return new WaitUntil(() => frame >= 10);
		Debug.Log("Bubble was burst!");
	}

	Vector3 GeneratedPosition()
	{
		int x;
		x = Random.Range(-3,3);
		return new Vector3(x,-5,0);
	}

    void SetCountText ()
    {
        
       countText.text = "Score: " + Global.count.ToString ();
       if (Global.count >= 5)
        {
            winText.text = "Congrtulations! You Win.";
        }
    }


}
