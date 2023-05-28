using UnityEngine;
using DG.Tweening;

public class BallMechanics : MonoBehaviour
{
    [SerializeField] private float launchPower;
    [SerializeField] private float xMin, xMax;
    private Vector3 _startPosition, _endPosition;
    private bool _canLaunchBall,_hasLauncedBall;
    private Rigidbody _rb;

    private int _currentScore;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _canLaunchBall = true;
        _currentScore = 0;
    }

    private void Update()
    {
        if (!_canLaunchBall) return;

        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = GetMousePositionInWorld();
            GameCanvasController.Instance.DisableShoot();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _endPosition = GetMousePositionInWorld();
           

            if (IsBallOnGround())
            {
                print("In launch ball ");
                Vector2 launchDir =_endPosition - _startPosition;
                _rb.isKinematic = false;
                _rb.AddForce(launchDir * launchPower, ForceMode.Impulse);
                _rb.AddTorque(launchDir * launchPower, ForceMode.Force);
                _hasLauncedBall = true;
               
            }
        }

       /* if (IsBallOnGround() && _rb.velocity.magnitude < 0.1f)
        {
            _canLaunchBall = true;
        }*/
    }

    private Vector2 GetMousePositionInWorld()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(pos);
    }

    private bool IsBallOnGround()
    {
        RaycastHit hit;
        float raycastDistance = 0.6f; // Adjust this distance based on the size of your ball

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Ground"))
            {
               
                return true;
            }
            else
            {
                return false;
            }

        }
        else
        {
            print("No raycast detected");
            return false;
        }


        
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hoop"))
        {
            print("Collision detected");
            Vector3 dir = (other.transform.position - transform.position).normalized;
            if (dir.y < 0)
            {
                //update the score
                print("update the score");
                _currentScore++;
                ScoreCanvasController.Instance.UpdateScore(_currentScore);
            }
        }


        if (other.CompareTag("OutPole"))
        {
            Invoke("ResetPosition", 0.5f);
            _hasLauncedBall = false;
            _canLaunchBall = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            if (_hasLauncedBall)
            {
                Invoke("ResetPosition", 0.5f);
                _hasLauncedBall = false;
                _canLaunchBall = false;
            }
            
        }


        
    }

    public void ResetPosition()
    {
        float pos = Random.Range(xMin, xMax);
        Vector3 newPos = new Vector3(pos, 0.4f, 0);
        _rb.isKinematic = true;
        transform.DOMove(newPos, 0.8f).SetEase(Ease.InOutCirc).OnComplete(() => {

            GameCanvasController.Instance.EnableShoot();
            _canLaunchBall = true;


        });
      
       
    }


    
}