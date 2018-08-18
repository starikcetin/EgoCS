﻿using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
	[DisallowMultipleComponent]
	public class OnMouseUpAsButtonComponent : MonoBehaviour
	{
		EgoComponent egoComponent;

		void Awake()
		{
			egoComponent = GetComponent<EgoComponent>();
		}

		void OnMouseUpAsButton()
		{
			var onMouseDownEvent = new MouseUpAsButtonEvent( egoComponent );
			EgoEvents<MouseUpAsButtonEvent>.AddEvent( onMouseDownEvent );
		}
	}
}
