using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace ElZilean
{
    enum Spells
    {
        Q, W, E, R
    }

    /// <summary>
    ///     Handle all stuff what is going on with Rengar.
    /// </summary>
    internal class Zilean
    {
        private static String hero = "Zilean";
        public static Obj_AI_Hero Player { get { return ObjectManager.Player; } }
        public static Orbwalking.Orbwalker _orbwalker;

        public static Dictionary<Spells, Spell> spells = new Dictionary<Spells, Spell>()
        {
            { Spells.Q, new Spell(SpellSlot.Q, 700)},
            { Spells.W, new Spell(SpellSlot.W, 0)},
            { Spells.E, new Spell(SpellSlot.E, 700)},
            { Spells.R, new Spell(SpellSlot.R, 900)}
        };


        #region hitchance

        private static HitChance CustomHitChance
        {
            get { return GetHitchance(); }
        }

        private static HitChance GetHitchance()
        {
            switch (ZileanMenu._menu.Item("ElZilean.hitChance").GetValue<StringList>().SelectedIndex)
            {
                case 0:
                    return HitChance.Low;
                case 1:
                    return HitChance.Medium;
                case 2:
                    return HitChance.High;
                case 3:
                    return HitChance.VeryHigh;
                default:
                    return HitChance.Medium;
            }
        }

        #endregion


        #region Gameloaded 

        public static void Game_OnGameLoad(EventArgs args)
        {
            if (ObjectManager.Player.BaseSkinName != hero)
                return;

            /*new SpellData
                           {
                    +ChampionName = "Zilean",
                    +SpellName = "ZileanQ",
                    +Slot = SpellSlot.Q,
                    +Type = SkillShotType.SkillshotCircle,
                    +Delay = 300,
                    +Range = 900,
                    +Radius = 210,
                    +MissileSpeed = 2000,
                    +FixedRange = false,
                    +AddHitbox = true,
                    +DangerValue = 2,
                    +IsDangerous = false,
                    +MissileSpellName = "ZileanQMissile",                    
                    +CollisionObjects = new[] { CollisionObjectTypes.YasuoWall }
              });*/


            Notifications.AddNotification("ElZilean by jQuery v1.0.0.0", 10000);
            spells[Spells.Q].SetSkillshot(0.30f, 210f, 2000f, true, SkillshotType.SkillshotCircle);

            ZileanMenu.Initialize();
            Game.OnGameUpdate += OnGameUpdate;
            Drawing.OnDraw += Drawings.Drawing_OnDraw;
        }

        #endregion

        #region OnGameUpdate

        private static void OnGameUpdate(EventArgs args)
        {
            switch (_orbwalker.ActiveMode)
            {
                case Orbwalking.OrbwalkingMode.Combo:
                    Combo();
                    break;
            }
        }

        #endregion

        private static void Combo()
        {
            var target = TargetSelector.GetTarget(spells[Spells.Q].Range, TargetSelector.DamageType.Magical);
            if (target == null || !target.IsValid)
                return;

            //Console.WriteLine("Buffs: {0}", string.Join(" | ", target.Buffs.Select(b => b.DisplayName)));
            //Console.WriteLine("Buffs: {0}", string.Join(" | ", target.Buffs.Where(b => b.Caster.NetworkId == Player.NetworkId).Select(b => b.DisplayName)));

            var qCombo = ZileanMenu._menu.Item("ElZilean.Combo.Q").GetValue<bool>();

            if (qCombo && spells[Spells.Q].IsReady() && Player.Distance(target) <= spells[Spells.Q].Range)
            {
                //spells[Spells.Q].Cast(target);
                spells[Spells.Q].CastIfHitchanceEquals(target, HitChance.VeryHigh);
            }

            if (target.HasBuff("ZileanQEnemyBomb"))
            {
                spells[Spells.W].Cast();
            }
        }
    }
}