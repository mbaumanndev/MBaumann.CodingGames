using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBaumann.CodingGames.Common
{
    public sealed class Menu
    {
        private bool m_CanWork = true;
        private int lasLen;

        public MenuItem Main { get; }
        public List<MenuItem> Items { get; }
        public MenuItem Current { get; private set; }
        public MenuItem Selected { get; private set; }

        private const int COLUMN_GAP = 5;

        public Menu(string p_Title, MenuItem[] p_Items)
        {
            Main = new MenuItem(p_Title, p_Items);
            Items = new List<MenuItem>(p_Items);

            Current = Main;

            if (p_Items.Length > 0)
                Selected = Items[0];
            else
                Selected = Main;
        }

        public void Close()
        {
            m_CanWork = false;
        }

        public void LaunchMenu()
        {
            Console.CursorVisible = false;

            while (m_CanWork)
            {
                Redraw();

                ConsoleKeyInfo v_Infos = Console.ReadKey(true);

                var v_Index = GetIndex();

                switch (v_Infos.Key)
                {
                    case ConsoleKey.Backspace when Current.Parent != null:
                        var v_Selected = Current.Parent.Items.FirstOrDefault();

                        if (v_Selected != null)
                            Selected = v_Selected;

                        Current = Current.Parent;
                        break;

                    case ConsoleKey.Escape:
                        Current = Main;

                        if (Main.Items.Length > 0)
                            Selected = Main.Items[0];

                        break;

                    case ConsoleKey.Enter:
                        Selected.Action?.Invoke();

                        if (Selected.Items?.Length > 0)
                        {
                            Current = Selected;
                            Selected = Current.Items[0];
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (v_Index > -1)
                        {
                            v_Index -= lasLen;

                            if (v_Index < 0)
                            {
                                v_Index += Current.Items.Length;

                                if (v_Index < 0)
                                    break;
                            }
                        }

                        Selected = Current.Items[v_Index];

                        break;

                    case ConsoleKey.DownArrow:
                        if (v_Index > -1)
                        {
                            v_Index += lasLen;

                            if (v_Index >= Current.Items.Length)
                            {
                                v_Index -= Current.Items.Length;

                                if (v_Index >= Current.Items.Length)
                                    break;
                            }
                        }

                        Selected = Current.Items[v_Index];

                        break;

                    case ConsoleKey.LeftArrow:
                        if (v_Index > -1)
                        {
                            v_Index--;

                            if (v_Index < 0)
                            {
                                v_Index = Current.Items.Length - 1;
                            }
                        }

                        Selected = Current.Items[v_Index];

                        break;

                    case ConsoleKey.RightArrow:
                        if (v_Index > -1)
                        {
                            v_Index++;

                            if (v_Index == Current.Items.Length)
                            {
                                v_Index = 0;
                            }
                        }

                        Selected = Current.Items[v_Index];

                        break;
                }

                int GetIndex()
                {
                    var sel = -1;

                    for (var i = 0; i < Current.Items.Length; ++i)
                    {
                        if (Selected == Current.Items[i])
                        {
                            sel = i;

                            break;
                        }
                    }

                    if (sel == -1 && Current.Items.Length > 0)
                    {
                        sel = 0;
                    }

                    return sel;
                }
            }
        }

        private void Redraw()
        {
            Console.Clear();

            StringBuilder v_NavBuilder = new StringBuilder(Current.Title);
            MenuItem v_Parent = Current.Parent;

            while (v_Parent != null)
            {
                v_NavBuilder.Insert(0, $"{v_Parent.Title} => ");

                v_Parent = v_Parent.Parent;
            }

            Console.WriteLine(v_NavBuilder.ToString());
            Console.WriteLine();

            int v_MaxLength = Current.Items.Max(p_Item => p_Item.Title.Length);
            var v_Len = Console.WindowWidth / (v_MaxLength + COLUMN_GAP) - 1;

            lasLen = v_Len;

            for (int i = 0; i < Current.Items.Length; i += v_Len)
            {
                for (int j = 0; j < v_Len && i + j < Current.Items.Length; ++j)
                {
                    var v_Item = Current.Items[i + j];

                    if (v_Item == Selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    var v_Title = v_Item.Title.PadRight(v_MaxLength + 2);

                    if (v_Title.Length >= Console.LargestWindowWidth)
                    {
                        v_Title = v_Title.Substring(0, Console.LargestWindowWidth - COLUMN_GAP) + "...";
                    }

                    Console.Write(v_Title);
                    Console.ResetColor();

                    Console.Write("".PadRight(COLUMN_GAP));
                }

                Console.WriteLine();
            }
        }
    }
}