
using System;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.CustomItems.API.Features;
using MapEditorReborn.API.Features;
using UnityEngine;

namespace SCP1162
{
    public class Main : Plugin<Config>
    {
        public static Main Plugin { get; private set; }
        public override string Author { get; } = "ShoulHate";
        public override string Name { get; } = "SCP1162";
        public override Version Version { get; } = new Version(1, 2, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 7, 0);

        public override void OnEnabled()
        {
            Plugin = this;

            CustomItem.RegisterItems(overrideClass: new Scp1162());

            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            CustomItem.UnregisterItems();
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;

            base.OnDisabled();
        }

        private void OnRoundStarted()
        {
            Door door = Door.Get(Exiled.API.Enums.DoorType.Scp173Armory);
            Vector3 vectorAdd = Vector3.zero;
            int eul = (int)door.Transform.eulerAngles.y;

            if (eul == 0) vectorAdd = new Vector3(-1, 1, 3.9f);
            else if (eul == 89) vectorAdd = new Vector3(3.9f, 1, 1);
            else if (eul == 179) vectorAdd = new Vector3(1, 1, -3.9f);
            else vectorAdd = new Vector3(-3.9f, 1, -1);

            ObjectSpawner.SpawnSchematic("scp1162", position: door.Position + vectorAdd, rotation: door.Rotation);
        }
    }
}
