using System.Collections.Generic;
using UnityEngine;

public class TestQuestion_1 : MonoBehaviour
{
	
	void Start()
	{
		List<char> originalList = new List<char>();

		// Generate a list of characters from 'a' to 'z'
		for (char c = 'a'; c <= 'z'; c++)
		{
			originalList.Add(c);
		}

		// Shuffle the list randomly
		System.Random rng = new System.Random();
		List<char> shuffledList = new List<char>(originalList);
		int n = shuffledList.Count;
		while (n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			char value = shuffledList[k];
			shuffledList[k] = shuffledList[n];
			shuffledList[n] = value;
		}

		
		int randomIndex = rng.Next(shuffledList.Count);
		char removedCharacter = shuffledList[randomIndex];
		shuffledList.RemoveAt(randomIndex);

		
		Debug.Log("Removed Character: " + removedCharacter);

		
		char missingCharacter = ' ';
		HashSet<char> characterSet = new HashSet<char>(shuffledList);
		foreach (char c in originalList)
		{
			if (!characterSet.Contains(c))
			{
				missingCharacter = c;
				break;
			}
		}

		
		Debug.Log("Missing Character: " + missingCharacter);
	}

	

}