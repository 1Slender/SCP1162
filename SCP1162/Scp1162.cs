
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace SCP1162
{
    [CustomItem(ItemType.Coin)]
    public class Scp1162 : CustomItem
    {
        public override uint Id { get; set; } = 200;
        public override string Name { get; set; } = "Scp1162";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 1;
        public override SpawnProperties SpawnProperties { get; set; }

        private System.Random random = new System.Random();

        protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            Log.Debug(ev.Player);
            ev.IsAllowed = false;
            Log.Debug(ev.IsAllowed);

            if (ev.Player.Role.Team == PlayerRoles.Team.SCPs) return;

            if (ev.Player.CurrentItem == null)
            {
                Log.Debug(ev.Player.CurrentItem);
                ev.Player.EnableEffect(Exiled.API.Enums.EffectType.SeveredHands);
            }
            else
            {
                Dictionary<ItemType, float>.Enumerator listItems = Main.Plugin.Config.ItemСhances.GetEnumerator();
                ev.Player.CurrentItem.Destroy();
                Log.Debug("ev.Player.CurrentItem.Destroy");
                if (Tools.Chance(Main.Plugin.Config.RandomnessMultiplier))
                {
                    while (listItems.MoveNext())
                    {
                        if (Tools.Chance(listItems.Current.Value))
                        {
                            ev.Player.AddItem(listItems.Current.Key);
                            break;
                        }
                    }
                }
                else if (Tools.Chance(Main.Plugin.Config.GrenadeSurprise))
                {
                    SCPsl.SpawnDelayActiveGrenadeHE(ev.Pickup.Position, random.Next(Main.Plugin.Config.MaxQuantityPomegranate), random.Next(3, 6), random.Next(1, 10) / 10);
                }

                Log.Debug($"ev.Player.AddItem: {listItems.Current.Key}");
            }

            base.OnPickingUp(ev);
        }
    }
}