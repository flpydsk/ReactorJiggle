//Copyright 2023 (c) Floppydisk
//GPL 3.0-only
using PulsarModLoader;

namespace ReactorJiggle
{
    public class Mod : PulsarMod
    {
        public override string Version => "0.1";
        public override string Author => "FloppyDisk&18107";
        public override string Name => "ReactorJiggle";
        public override string HarmonyIdentifier() => $"{Author}.{Name}";
        public override string ShortDescription => "Jiggles the reactor core";
        public override string LongDescription => "Licence: GPL 3.0-only";

    }
}
