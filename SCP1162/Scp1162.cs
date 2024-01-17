
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using System;


namespace SCP1162
{
    [CustomItem(ItemType.Medkit)]
    public class Scp1162 : CustomItem
    {
        public override uint Id { get; set; } = 100;
        public override string Name { get; set; } = "Scp1162";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 5;
        public override SpawnProperties SpawnProperties { get; set; }

        private Random random = new Random();

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
        }

        protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            Log.Debug(ev.Player);
            ev.IsAllowed = false;
            Log.Debug(ev.IsAllowed);

            if (ev.Player.CurrentItem == null)
            {
                Log.Debug(ev.Player.CurrentItem);
                ev.Player.EnableEffect(Exiled.API.Enums.EffectType.SeveredHands);
            }
            else
            {
                ev.Player.CurrentItem.Destroy();
                Log.Debug("ev.Player.CurrentItem.Destroy");
                ev.Player.AddItem((ItemType)random.Next(51));
                Log.Debug("ev.Player.AddItem");
            }
            Log.Debug("OK");

            base.OnPickingUp(ev);
        }
    }
}