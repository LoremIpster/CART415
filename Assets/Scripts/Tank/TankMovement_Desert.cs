using UnityEngine;

public class TankMovement_Desert : MonoBehaviour
{
    public int m_PlayerNumber = 1;         
    public float m_Speed = 12f;            
    public float m_TurnSpeed = 180f;       
    public AudioSource m_MovementAudio;    
    public AudioClip m_EngineIdling;       
    public AudioClip m_EngineDriving;      
    public float m_PitchRange = 0.2f;

    
    private string m_MovementAxisName;     
    private string m_TurnAxisName;         
    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue;    
    private float m_TurnInputValue;        
    private float m_OriginalPitch;

	// desert variables
	private float xPos;
	private float zPos;
	private bool isMoving;

	public GameObject cameraRig;
	private CameraControl_Desert cameraScript;

	// camera frustum detection
	public Collider col;
	private Camera cam;
	private Plane[] planes;
	private bool isOutOfBounds;



    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

		cam = Camera.main;
		planes = GeometryUtility.CalculateFrustumPlanes (cam);
		col = GetComponent<Collider> ();
    }


    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;

        m_OriginalPitch = m_MovementAudio.pitch;



		xPos = transform.position.x;
		zPos = transform.position.z;
		cameraScript = cameraRig.GetComponent<CameraControl_Desert>();
    }
    

    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.

		m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
		m_TurnInputValue = Input.GetAxis (m_TurnAxisName);

		EngineAudio ();

		planes = GeometryUtility.CalculateFrustumPlanes (cam);
		if (GeometryUtility.TestPlanesAABB(planes, col.bounds)){
			//Debug.Log(col.name + "IS INSIDE");
			isOutOfBounds = false;
			}
			else{
			//Debug.Log(col.name + "IS OUTSIDE");
			isOutOfBounds = true;
			}
		}


    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.

		// if there is no input (the tank is stationary)
		if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f) 
		{
			// and if the audio source is currently playing the driving clip
			if(m_MovementAudio.clip == m_EngineDriving)
			{
				// change the clip to idling and play it
				m_MovementAudio.clip = m_EngineIdling;
				m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				m_MovementAudio.Play ();
			}
		} else 
		{
			// otherwise if the tank is moving and if the idling clip is currently playing
			if(m_MovementAudio.clip == m_EngineIdling)
			{
				// change the clip to driving and play it
				m_MovementAudio.clip = m_EngineDriving;
				m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				m_MovementAudio.Play ();
			}			
		}
    }


    private void FixedUpdate()
    {
		if(Input.anyKey){
			Move();
			Turn();
		}

		if (xPos != transform.position.x || zPos != transform.position.z) {
			xPos = transform.position.x;
			zPos = transform.position.z;

			cameraScript.tankMoving = true;
		} else {
			cameraScript.tankMoving = false;
		}
    }


    private void Move()
    {
		if (!isOutOfBounds) {
			Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
			m_Rigidbody.MovePosition (m_Rigidbody.position + movement);
		}
    }


    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
    }

	private void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Tank") {
			cameraScript.tankProximity = true;
		}

	}

}

























