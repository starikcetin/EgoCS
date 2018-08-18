using EgoCS.Components;

namespace EgoCS.Events.MonobehaviorMessages
{
    public class MouseEnterEvent : EgoEvent
    {
        public readonly EgoComponent egoComponent;

        public MouseEnterEvent(EgoComponent egoComponent)
        {
            this.egoComponent = egoComponent;
        }
    }
}