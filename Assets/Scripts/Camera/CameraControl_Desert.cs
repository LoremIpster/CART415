using UnityEngine;

public class CameraControl_Desert : MonoBehaviour
{
    public float m_DampTime = 0.2f;                   
    public float m_ScreenEdgeBuffer = 4f;           
    public float m_MinSize = 6.5f;                  

    private Camera m_Camera;                        
    private float m_ZoomSpeed;                      
    private Vector3 m_MoveVelocity;                 
	private Vector3 m_DesiredPosition;

	// desert variables
	private float zoomSize;
	public bool tankMoving;

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

	private void Start(){
		m_Camera.orthographicSize = 5;
	}


    private void FixedUpdate()
    {
		//Debug.Log (m_ZoomSpeed);
		Move ();
		if (tankMoving) {
			ZoomOut ();
		} else {
			ZoomIn ();
		}
    }


    private void Move()
    {
		transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void ZoomOut()
    {
		m_ZoomSpeed = 1f;
		zoomSize += Time.deltaTime;
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, zoomSize, ref m_ZoomSpeed, m_DampTime);
    }

	private void ZoomIn()
	{
		if (m_Camera.orthographicSize > 5) {
			m_ZoomSpeed = 0.01f;
			zoomSize -= Time.deltaTime;
			m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize, zoomSize, ref m_ZoomSpeed, m_DampTime);
		}
	}

}