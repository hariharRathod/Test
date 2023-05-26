using UnityEngine;

public class CubeWander : MonoBehaviour
{
	
	public float wanderRadius = 50f; // Radius within which the cubes can wander
	public float wanderSpeed = 2f; // Speed at which the cubes move

	private Vector3 targetPosition; // The target position for the cube to move towards

	private void Start()
	{
		// Initialize the target position to a random position within the wander radius
		targetPosition = GetRandomPosition();
	}

	private void Update()
	{
		// Move towards the target position
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, wanderSpeed * Time.deltaTime);

		// If the cube has reached the target position, get a new random position
		if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
		{
			targetPosition = GetRandomPosition();
		}
	}

	private Vector3 GetRandomPosition()
	{
		
		Vector3 randomPosition = new Vector3(
			Random.Range(-wanderRadius, wanderRadius), // Random X position within the plane's bounds
			transform.position.y, // Y position stays at 0 to stay on the same plane
			Random.Range(-wanderRadius, wanderRadius) // Random Z position within the plane's bounds
			);

		return randomPosition;
	}
	
	
	
}