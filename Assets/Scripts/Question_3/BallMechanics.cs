using UnityEngine;

public class BallMechanics : MonoBehaviour
{
	[SerializeField] private float launchPower;
	
	private Vector3 _startPosition, _endPosition;
	private bool _canLaunchBall;

	private Rigidbody _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_canLaunchBall = true;
	}

	private void Update()
	{
		if (!_canLaunchBall) return;

		if (Input.GetMouseButtonDown(0))
		{
			_startPosition = GetMousePositionInWorld();
			Debug.Log("Start: " + _startPosition);
			//_rb.isKinematic = true;
		}

		if (Input.GetMouseButtonUp(0))
		{
			_endPosition = GetMousePositionInWorld();
			Debug.Log("End: " + _endPosition);
			Vector2 launchDir = _endPosition - _startPosition;
			_rb.isKinematic = false;
			Debug.Log(launchDir);
			_rb.AddForce(launchDir * launchPower, ForceMode.Impulse);
		}
	}

	private Vector2 GetMousePositionInWorld()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = Camera.main.transform.position.z;
		
		return Camera.main.ScreenToWorldPoint(pos);
	}
}