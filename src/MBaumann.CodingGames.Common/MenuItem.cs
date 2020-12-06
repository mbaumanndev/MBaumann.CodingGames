using System;

namespace MBaumann.CodingGames.Common
{
    public class MenuItem
    {
        public MenuItem(string p_Title, MenuItem[] p_Items) : this(p_Title, null, p_Items)
        {
        }
        public MenuItem(string p_Title, PuzzleMenuItem[] p_Items) : this(p_Title, null, p_Items)
        {
        }

        public MenuItem(string p_Title, Action p_Action) : this(p_Title, p_Action, new MenuItem[0])
        {
        }

        public MenuItem(string p_Title, Action p_Action, MenuItem[] p_Items)
        {
            Title = p_Title;
            Action = p_Action;
            Items = p_Items;

            foreach (MenuItem v_Item in Items)
            {
                v_Item.Parent = this;
            }
        }

        public MenuItem Parent { get; private set; }
        public string Title { get; protected set; }
        public MenuItem[] Items { get; }
        public Action Action { get; protected set; }
    }
}