using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public enum TargetType{
		Move,
		Inspect,
		Trigger
	}

	public TargetType type;
}
