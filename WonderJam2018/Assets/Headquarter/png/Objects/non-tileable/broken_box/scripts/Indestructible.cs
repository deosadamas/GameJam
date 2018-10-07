using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Indestructible : MonoBehaviour, IPhysics {
		
	protected Vector2 mVelocity;

	protected virtual void FixedUpdate()
	{
		mVelocity = GetComponent<Rigidbody2D>().velocity;
	}
			
	#region IPhysics implementation
	public virtual Vector2 Impulse
	{
		get
		{
			return mVelocity * GetComponent<Rigidbody2D>().mass;
		}
	}
	#endregion
}
