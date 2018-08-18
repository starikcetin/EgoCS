using EgoCS.Components;

namespace EgoCS.Events.MonobehaviorMessages
{
	public class MouseDragEvent : EgoEvent
	{
		public readonly EgoComponent egoComponent;

		public MouseDragEvent( EgoComponent egoComponent )
		{
			this.egoComponent = egoComponent;
		}
	}
}
