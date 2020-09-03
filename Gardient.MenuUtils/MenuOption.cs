using System;

namespace Gardient.MenuUtils
{
    public class MenuOption
    {
        public ConsoleKey Key { get; protected set; }
        public string Option { get; protected set; }
        public string OptionText { get; protected set; }
        public Action Action { get; protected set; }
        public bool ShowMenu { get; protected set; }

        public MenuOption(ConsoleKey key, string optionText, Action action = null, bool showMenu = false)
        {
            Key = key;
            Option = Key.ToString();
            if (Option.StartsWith("D")) Option = Option.Remove(0, 1);
            OptionText = optionText;
            Action = action;
            ShowMenu = showMenu;
        }

        public MenuOption(ConsoleKey key, string optionText)
            : this(key, optionText, null, false) { }
    }
}
