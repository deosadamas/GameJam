using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(Rigidbody2D))]
public class DestructableBase : Indestructible {
	
	public float destructionImpulse = 10000f;
	public bool automaticCalculatePeaceMass = true;

	private float mBreakRandomCofficient = 3.0f;


	protected virtual void Start()
	{				
		if (automaticCalculatePeaceMass) 
		{
			foreach (Transform t in transform)
			{				
				t.gameObject.SetActive(true);					
				
				t.GetComponent<Rigidbody2D>().mass = ( Mathf.Pow( t.GetComponent<Collider2D>().bounds.size.magnitude, 2f )) / ( Mathf.Pow (GetComponent<Collider2D>().bounds.size.magnitude,2f )) * GetComponent<Rigidbody2D>().mass;					

				t.gameObject.SetActive(false);
			}
		}		
	}


	protected virtual void OnCollisionEnter2D( Collision2D collision )
	{
		Vector2 myImpulse = Impulse;

		Vector2 otherImpulse = Vector2.zero;
		foreach (ContactPoint2D cp in collision.contacts ) 
		{
			IPhysics phys = cp.collider.GetComponent(typeof(IPhysics)) as IPhysics;

			if ( phys != null )
			{
				otherImpulse += phys.Impulse;
			}
			else if ( cp.collider.GetComponent<Rigidbody2D>() == null )
			{
				otherImpulse = Vector3.zero;
			}
		}

		Vector2 resultImpulse = myImpulse + otherImpulse;

		float deltaImpulse = Mathf.Abs (myImpulse.magnitude - otherImpulse.magnitude);

		if ( deltaImpulse > destructionImpulse ) 
		{
			StartCoroutine( "CheckDestroySelf" );
		}
	}

	IEnumerator CheckDestroySelf()
	{
		yield return new WaitForFixedUpdate();

		List<Transform> childs = new List<Transform>();

		foreach( Transform t in transform )
		{
			childs.Add( t );
		}

		foreach( Transform t in childs )
		{
			t.parent = null;
			t.gameObject.SetActive( true );
			t.GetComponent<Rigidbody2D>().velocity = ( ( ( mBreakRandomCofficient * Random.insideUnitCircle + GetComponent<Rigidbody2D>().velocity.normalized ).normalized * GetComponent<Rigidbody2D>().velocity.magnitude ));
			t.GetComponent<Rigidbody2D>().angularVelocity = GetComponent<Rigidbody2D>().angularVelocity;
		}

		Destroy( gameObject );
    }
}
