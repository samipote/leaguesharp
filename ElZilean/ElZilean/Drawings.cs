using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using Color = System.Drawing.Color;

namespace ElZilean
{
    public class Drawings
    {
        public static void Drawing_OnDraw(EventArgs args)
        {
            if (ZileanMenu._menu.Item("ElZilean.Draw.off").GetValue<bool>())
                return;

            if (ZileanMenu._menu.Item("ElZilean.Draw.Q").GetValue<bool>())
                if (Zilean.spells[Spells.Q].Level > 0)
                    Utility.DrawCircle(Zilean.Player.Position, Zilean.spells[Spells.Q].Range, Zilean.spells[Spells.Q].IsReady() ? Color.Green : Color.Red);

            if (ZileanMenu._menu.Item("ElZilean.Draw.W").GetValue<bool>())
                if (Zilean.spells[Spells.W].Level > 0)
                    Utility.DrawCircle(Zilean.Player.Position, Zilean.spells[Spells.W].Range, Zilean.spells[Spells.W].IsReady() ? Color.Green : Color.Red);

            if (ZileanMenu._menu.Item("ElZilean.Draw.E").GetValue<bool>())
                if (Zilean.spells[Spells.E].Level > 0)
                    Utility.DrawCircle(Zilean.Player.Position, Zilean.spells[Spells.E].Range, Zilean.spells[Spells.E].IsReady() ? Color.Green : Color.Red);

            if (ZileanMenu._menu.Item("ElZilean.Draw.R").GetValue<bool>())
                if (Zilean.spells[Spells.R].Level > 0)
                    Utility.DrawCircle(Zilean.Player.Position, Zilean.spells[Spells.R].Range, Zilean.spells[Spells.R].IsReady() ? Color.Green : Color.Red);
        }
    }
}