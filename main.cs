using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows;
using System.Timers;
using Timer = System.Timers.Timer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Rainifider
{
#pragma warning disable
    public class Rainifider
    {
        public static string directory;
        public static List<ResultType> CreateModInfo(PlugData data, bool optionalPage)
        {
            List<ResultType> results = new List<ResultType>();
            Console.Write(data.authors);
            if ((data.authors.Length == 0 || data.id.Length == 0 || data.name.Length == 0 || data.version.Length == 0 || directory.Length == 0))
            {
                ResultType.Error err = new ResultType.Error("One or more required fields is blank.", new Point(497, 422)); results.Add(err);
                if (optionalPage) return results;
                if (data.authors.Length == 0)
                {
                    ResultType.Warning res = new ResultType.Warning("You need to include an author(s)!", new Point(12, 125));
                    results.Add(res);
                }
                if (data.id.Length == 0)
                {
                    ResultType.Warning res = new ResultType.Warning("You need to include a mod ID!", new Point(12, 193));
                    results.Add(res);
                }
                if (data.name.Length == 0)
                {
                    ResultType.Warning res = new ResultType.Warning("You need to include a mod name!", new Point(12, 57));
                    results.Add(res);
                }
                if (data.version.Length == 0)
                {
                    ResultType.Warning res = new ResultType.Warning("You need to include a mod version!", new Point(12, 346));
                    results.Add(res);
                }
                if (directory.Length == 0)
                {
                    ResultType.Warning res = new ResultType.Warning("You need to include a mod directory!", new Point(12, 278));
                    results.Add(res);
                }
                return results;
            }
            else
            {
                string To_JSON = ""; string modInfo_path = "";
                try
                {
                    JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
                    To_JSON = JsonSerializer.Serialize(data, jsonSerializerOptions);
                    modInfo_path = Path.Combine(directory, data.name);
                }
                catch (Exception ex)
                {
                    ResultType.Error res = new ResultType.Error(ex.ToString(), new Point(497, 422));
                    results.Add(res);
                }
                try
                {
                    DirectoryInfo dir = Directory.CreateDirectory(modInfo_path);
                    File.WriteAllText(Path.Combine(modInfo_path, "modinfo.json"), To_JSON);
                    string plugin_path = Path.Combine(modInfo_path, "plugins");
                    DirectoryInfo plugin = Directory.CreateDirectory(plugin_path);
                    ResultType.Success res = new ResultType.Success("Success!", new Point(497, 422));
                    results.Add(res);
                    File.WriteAllText(Path.Combine(plugin_path,"template.cs"), "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\nusing BepInEx;\r\nusing MonoMod;\r\nusing Mono;\r\nusing System.IO;\r\nusing On;\r\n\r\nnamespace RainTemplate\r\n{\r\n    [BepInPlugin(MOD_ID, MOD_NAME, MOD_VERSION)]\r\n    public class template : BaseUnityPlugin\r\n    {\r\n        public void OnEnable() //put your hooks here\r\n        {\r\n\r\n        }\r\n        public const string MOD_ID = \"\";\r\n        public const string MOD_NAME = \"\";\r\n        public const string MOD_VERSION = \"\";\r\n    } \r\n}\r\n/* \r\n * make sure to set to your mod's ID, name, and version respectively\r\n * you'll have to manually add references unfortunately, don't mind the errors\r\n * make sure to place your .dll in your plugins folder!\r\n * also make sure to actually make a .sln file. use this file to copy/paste from or something/use in the solution\r\n * Rainifider made by Riv, @noideawhoiam_61759 :3\r\n */".Replace("public const string MOD_ID = \"\";", "public const string MOD_ID = \"" + data.id + "\";").Replace("public const string MOD_NAME = \"\";", "public const string MOD_NAME = \"" + data.name + "\";").Replace("public const string MOD_VERSION = \"\";", "public const string MOD_VERSION = \"" + data.version + "\";"));
                }
                catch (Exception ex)
                {
                    ResultType.Error res = new ResultType.Error("ERROR! Path not found? : " + ex, new Point(497, 422));
                    results.Add(res);
                }
            }
            return results;
        }
        public static List<Label> ApplyData(PlugData pluginData, bool optionalPage)
        {
            List<ResultType> results = CreateModInfo(pluginData,optionalPage);
            List<Label> labels = new List<Label>();
            for (int i = 0; i < results.Count; i++)
            {
                string message = ""; Point position = new Point(); Color color = new Color();
                try
                {
                    if (results[i] is ResultType.Error) { ResultType.Error rType = (results[i] as ResultType.Error); message = rType.message; position = rType.TextPosition; color = rType.CodeColor;}
                    if (results[i] is ResultType.Warning) { ResultType.Warning rType = (results[i] as ResultType.Warning); message = rType.message; position = rType.TextPosition; color = rType.CodeColor;}
                    if (results[i] is ResultType.Debug) { ResultType.Debug rType = (results[i] as ResultType.Debug); message = rType.message; position = rType.TextPosition; color = rType.CodeColor;}
                    if (results[i] is ResultType.Message) { ResultType.Message rType = (results[i] as ResultType.Message); message = rType.message; position = rType.TextPosition; color = rType.CodeColor;}
                    if (results[i] is ResultType.Success) { ResultType.Success rType = (results[i] as ResultType.Success); message = rType.message; position = rType.TextPosition; color = rType.CodeColor;}
                }
                catch (Exception ex)
                {
                    // idk?? do nothing?
                }
                Label mLabel = new Label();
                mLabel.Text = message;
                mLabel.Location = position;
                mLabel.BackColor = color;

                if (results[i] is ResultType.Success)
                {
                    time.Start();
                    time.Elapsed += Time_Elapsed;
                }
                labels.Add(mLabel);
            }
            return labels;
        }

        private static void Time_Elapsed(object? sender, ElapsedEventArgs e)
        {
            //close program
        }
        public static void CreateResultLog()
        {
            Form1.ActiveForm.Close();
        }
        public static string GetData()
        {
            return Form1.ActiveForm.Text;
        }
        public static Timer time = new Timer(interval: 5000);
    }
}

// Creates a modinfo.json (use template for this pff)
// you need to input the mod folder path, if provided, save it automatically for future use
// ^ say it should be in "Rain World\RainWorld_Data\StreamingAsinits\mods"

// INPUTS:
/* AUTHORS: authors who've made the mod
 * MOD_ID: id of the mod
 * MOD_NAME: name of the mod
 * version: initial mod version
 * [OPTIONAL]
 * description: description of the mod
 * more explanations later im exhausted
 */