using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TargetActionController : MonoBehaviour {

	public LayerMask targetMask;
	public Color defaultCursorColor;
	public Color highlightCursorColor;

	[SerializeField]
	private Image cursorImageObject;
	[SerializeField]
	private Sprite defaultCursor;
	[SerializeField]
	private Sprite moveCursor;
	[SerializeField]
	private Sprite triggerCursor;
	[SerializeField]
	private Sprite inspectCursor;

	private Collider lastColliderHit;
	private Target currentTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount%3==0)
		{
			RaycastHit hit;
			if(Physics.Raycast(transform.position,transform.forward, out hit, 100.0f,targetMask,QueryTriggerInteraction.Collide))
			{
				if(hit.collider != lastColliderHit)
				{
					currentTarget = hit.collider.GetComponent<Target>();
					UpdateCursorUI(currentTarget.type);
					lastColliderHit = hit.collider;
				}
			}
			else{
				UpdateCursorUI();
				currentTarget = null;
				lastColliderHit = null;
			}
		}
	}

	private void UpdateCursorUI(Target.TargetType type)
	{
		cursorImageObject.color = highlightCursorColor;
		if(type.Equals(Target.TargetType.Move))
		{
			cursorImageObject.sprite = moveCursor;
		}
		else if(type.Equals(Target.TargetType.Inspect))
		{
			cursorImageObject.sprite = inspectCursor;
		}
		else if(type.Equals(Target.TargetType.Trigger))
		{
			cursorImageObject.sprite = triggerCursor;
		}
	}

	private void UpdateCursorUI()
	{
		cursorImageObject.color = defaultCursorColor;
		cursorImageObject.sprite = defaultCursor;
	}
}
