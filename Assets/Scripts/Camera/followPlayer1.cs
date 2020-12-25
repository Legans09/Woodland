using UnityEngine;
using System.Collections;

public class followPlayer1 : MonoBehaviour
{
	public float delay = 4f;
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject player;
	public GameObject npc;
	public Vector3 offset;
	public Vector3 rOffset;
	Vector3 targetPos;
	
	public bool startDlelay = true;
	private bool faceRight=false;
	private bool dialogue = false;

  

    void FixedUpdate()
	{
		if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d")) && !dialogue)
		{
			faceRight = true;
		}
		if (((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))) && !dialogue)
		{

			faceRight = false;

		}

		if (player)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = player.transform.position.z;
			Vector3 targetDirection = (player.transform.position - posNoZ);
			interpVelocity = targetDirection.magnitude * 10f;
			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);


			rOffset = offset;
			rOffset.x = offset.x * -1f;
			if (dialogue)
			{
				rOffset.x = -0.5f;
				offset.x = 0.5f;
			}
			else 
			{ 
			rOffset.x = -1f;
			offset.x = 1f;
			}

			if (faceRight == false)
				{
					transform.position = Vector3.Lerp(transform.position, targetPos + rOffset, 0.30f);
				}
				else
				{
					transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.30f);
				}
		
		}
	}


	public void setDialogue(bool isTalking)
	{
		dialogue = isTalking;
	}

	void setStart()
	{
		startDlelay = false;
	
	}

}