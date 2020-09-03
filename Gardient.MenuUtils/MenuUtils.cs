using System;
using System.Collections.Generic;
using System.Linq;

namespace Gardient.MenuUtils
{
    public class MenuUtils
    {
        public static void ShowMenu(Func<bool> menuFunction)
        {
            if (menuFunction == null)
                throw new ArgumentNullException(nameof(menuFunction));

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = menuFunction();
            }
        }

        public static void ShowMenu(MenuFunctionGenerationSettings menuFunctionGenerationSettings)
        {
            ShowMenu(GenerateMenuFunction(menuFunctionGenerationSettings));
        }

        public static Func<bool> GenerateMenuFunction(MenuFunctionGenerationSettings menuFunctionGenerationSettings)
        {
            Dictionary<ConsoleKey, MenuOption> optionsDictionary = menuFunctionGenerationSettings.MenuOptions.ToDictionary(k => k.Key);
            if (menuFunctionGenerationSettings.IncludeX && !optionsDictionary.ContainsKey(ConsoleKey.X))
                optionsDictionary.Add(ConsoleKey.X, new MenuOption(ConsoleKey.X, "Exit"));

            return () =>
            {
                if (menuFunctionGenerationSettings.ClearConsole) Console.Clear();
                Console.WriteLine(menuFunctionGenerationSettings.PreMenuText);
                foreach (var kvp in optionsDictionary)
                    Console.WriteLine(string.Format(menuFunctionGenerationSettings.OptionFormat, kvp.Value.Option, kvp.Value.OptionText));
                Console.Write($"{Environment.NewLine}{menuFunctionGenerationSettings.Prompt}");

                ConsoleKey chosenKey = Console.ReadKey().Key;
                Console.WriteLine();
                if (optionsDictionary.TryGetValue(chosenKey, out MenuOption chosenOption))
                {
                    chosenOption.Action?.Invoke();

                    return chosenOption.ShowMenu;
                }
                else return true;
            };
        }
    }
}
