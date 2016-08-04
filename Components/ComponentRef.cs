using UnityEngine;
using System.Collections;

public class ComponentRef<C> : MonoBehaviour
	where C : Component
{
	[SerializeField]
	private C _ref;
	public C Ref
	{
		get
		{
			return _ref;
		}
		set
		{
			if( value == null )
			{
				Debug.LogAssertionFormat( "Cannot set ComponentRef<{0}>.Ref to null. Destroy the ComponentRef<{0}> instead.", typeof( C ).Name );
				UnityEditor.Selection.activeGameObject = gameObject;
			}
			else if( _ref != null )
			{
				Debug.LogAssertionFormat( "Cannot reassign ComponentRef<{0}>.Ref. Destroy the ComponentRef<{0}> and attach a new ComponentRef<{0}> instead.", typeof( C ).Name );
				UnityEditor.Selection.activeGameObject = gameObject;
			}
			else if( gameObject == value.gameObject )
			{
				Debug.LogAssertionFormat( "ComponentRef<{0}> and ComponentRef<{0}>.Ref cannot be attached to the same GameObject.", typeof( C ).Name );
				UnityEditor.Selection.activeGameObject = gameObject;
			}
			else
			{
				_ref = value;
			}
		}
	}

	void Start()
	{
		if( _ref == null )
		{
			Debug.LogAssertionFormat( "ComponentRef<{0}>.Ref on {1} is invalid.", typeof( C ).Name, gameObject.name );
			UnityEditor.Selection.activeGameObject = gameObject;
		}
		else if( _ref.gameObject == gameObject )
		{
			Debug.LogAssertionFormat( "ComponentRef<{0}> and ComponentRef<{0}>.Ref cannot be attached to the same GameObject.", typeof( C ).Name );
			UnityEditor.Selection.activeGameObject = gameObject;
		}		
	}
}
