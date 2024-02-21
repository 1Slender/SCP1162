
using System;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using MapEditorReborn.API.Features;
using MapEditorReborn.API.Features.Objects;
using UnityEngine;

namespace SCP1162
{
    public class Main : Plugin<Config>
    {
        public static Main Plugin { get; private set; }
        public override string Author { get; } = "Shoulate";
        public override string Name { get; } = "SCP1162";
        public override Version Version { get; } = new Version(1, 2, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 0);

        private static SchematicObject objectScp1162 = null;

        public override void OnEnabled()
        {
            Log.Debug("OnEnabled");
            Plugin = this;

            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Log.Debug("OnDisabled");

            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            base.OnDisabled();
        }
        public override void OnReloaded()
        {
            Log.Debug("OnReloaded");
            UnSpawnScp();
            base.OnReloaded();
        }

        private void OnRoundStarted()
        {
            SpawnScp();
        }

        private void SpawnScp()
        {
            Log.Debug("objectScp1162 " + objectScp1162 == null);
            Log.Debug("new Scp1162() " + Config.scp1162 == null);
            Log.Debug("SpawnScp()");
            Config.scp1162 = new Scp1162();
            Log.Debug("new Scp1162() " + Config.scp1162 == null);
            CustomItem.RegisterItems(overrideClass:Config.scp1162);
            Log.Debug("Config.scp1162.Register() " + Config.scp1162.Name);

            Door door = Door.Get(Exiled.API.Enums.DoorType.Scp173Armory);
            Vector3 vectorAdd = Vector3.zero;
            int eul = (int)door.Transform.eulerAngles.y;

            if (eul == 0) vectorAdd = new Vector3(-1, 1, 3.9f);
            else if (eul == 89) vectorAdd = new Vector3(3.9f, 1, 1);
            else if (eul == 179) vectorAdd = new Vector3(1, 1, -3.9f);
            else vectorAdd = new Vector3(-3.9f, 1, -1);

            Log.Debug("objectScp1162 " + objectScp1162 == null);
            objectScp1162 = ObjectSpawner.SpawnSchematic("scp1162", position: door.Position + vectorAdd, rotation: door.Rotation, data: null, isStatic: false);
            Log.Debug("objectScp1162 " + objectScp1162 == null);

        }
        private void UnSpawnScp()
        {
            Log.Debug("UnSpawnScp()");
            Log.Debug(Config.scp1162 != null);
            Config.scp1162.Unregister();
            Log.Debug(objectScp1162 != null);
            if (objectScp1162 != null) objectScp1162.Destroy();
            //if (Config.scp1162 != null) Config.scp1162.Destroy();
            Log.Debug(objectScp1162 != null);
            SpawnScp();
        }
    }
}
