using System.Collections.Generic;

namespace Gardient.MenuUtils
{
    public class MenuFunctionGenerationSettings
    {

        public IEnumerable<MenuOption> MenuOptions { get; set; }
        public string PreMenuText { get; set; }
        public string OptionFormat { get; set; }
        public string Prompt { get; set; }
        public bool ClearConsole { get; set; }
        public bool IncludeX { get; set; }

        public MenuFunctionGenerationSettings(IEnumerable<MenuOption> menuOptions)
        {
            MenuOptions = menuOptions;
            PreMenuText = "Choose an option";
            OptionFormat = "{0}) {1}";
            Prompt = "Please choose: ";
            ClearConsole = false;
            IncludeX = false;
        }
    }
}
