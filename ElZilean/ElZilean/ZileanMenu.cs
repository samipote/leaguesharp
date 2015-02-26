﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace ElZilean
{
    public class ZileanMenu
    {
        public static Menu _menu;

        public static void Initialize()
        {
            _menu = new Menu("ElZilean", "menu", true);

            //ElZilean.Orbwalker
            var orbwalkerMenu = new Menu("Orbwalker", "orbwalker");
            Zilean._orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);
            _menu.AddSubMenu(orbwalkerMenu);

            //ElZilean.TargetSelector
            var targetSelector = new Menu("Target Selector", "TargetSelector");
            TargetSelector.AddToMenu(targetSelector);
            _menu.AddSubMenu(targetSelector);

            //ElZilean.Menu
            var comboMenu = _menu.AddSubMenu(new Menu("Combo", "Combo"));
            comboMenu.AddItem(new MenuItem("ElZilean.Combo.Q", "Use Q").SetValue(true));
            comboMenu.AddItem(new MenuItem("ElZilean.hitChance", "Hitchance").SetValue(new StringList(new[] { "Low", "Medium", "High", "Very High" }, 3)));
            comboMenu.AddItem(new MenuItem("ComboActive", "Combo!").SetValue(new KeyBind(32, KeyBindType.Press)));

            //ElZilean.Misc
            var miscMenu = _menu.AddSubMenu(new Menu("Misc", "Misc"));
            miscMenu.AddItem(new MenuItem("ElZilean.Draw.off", "[Drawing] Drawings off").SetValue(false));
            miscMenu.AddItem(new MenuItem("ElZilean.Draw.Q", "Draw Q").SetValue(true));
            miscMenu.AddItem(new MenuItem("ElZilean.Draw.W", "Draw W").SetValue(true));
            miscMenu.AddItem(new MenuItem("ElZilean.Draw.E", "Draw E").SetValue(true));
            miscMenu.AddItem(new MenuItem("ElZilean.Draw.R", "[Drawing] Draw R").SetValue(true));

            //Here comes the moneyyy, money, money, moneyyyy
            var credits = _menu.AddSubMenu(new Menu("Credits", "jQuery"));
            credits.AddItem(new MenuItem("ElZilean.Paypal", "if you would like to donate via paypal:"));
            credits.AddItem(new MenuItem("ElZilean.Email", "info@zavox.nl"));

            _menu.AddItem(new MenuItem("422442fsaafs4242f", ""));
            _menu.AddItem(new MenuItem("422442fsaafsf", "Version: 1.0.1.8"));
            _menu.AddItem(new MenuItem("fsasfafsfsafsa", "Made By jQuery"));

            _menu.AddToMainMenu();

            Console.WriteLine("Menu Loaded");
        }
    }
}