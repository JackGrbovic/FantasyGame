using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;
using FantasyGame1.GameItems;
using FantasyGame1.Scenarios;

namespace FantasyGame1
{
    public static class ProgUtilities
    {
        public static string newLine = "\n";

        public static void WriteText(string text, string colour = "")
        {
            int maxLength = 50;

            switch (colour)
            {
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case "DarkGreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;

                case "Cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            List<string> lines = new List<string>();
            int j = 0;
            string currentLine = "";
            char finder = ' ';

            //for loop used to increment an int i as long as characters are added to the string with the 'currentLine += c' operand
            for (int i = 0; i < text.Length; i++)
            {
                if (j < maxLength)
                {
                    //Where currentLine += text[i] takes the character that is at the index numberthat i is equal to, and appends it to the currentLine string
                    //while i is used to index the characters, j is usaed as a market to determine when our linehas reached its maximum length

                    if (text[i] == '\n')
                        j = 0;

                    currentLine += text[i];
                    j++;

                    if (i == text.Length - 1)
                    {
                        lines.Add(currentLine);
                    }
                }
                else
                {
                    i--;
                    j--;

                    //this will decrement i after the max length has been reached, until the console encounters a space
                    int oldJ = j;
                    while (currentLine[j] != finder)
                    {
                        j--;
                        i--;
                    }

                    //remove starts with index you want to start at and the second parameter is how many character from the starting index you would like to remove
                    currentLine = currentLine.Remove(j, (oldJ - j) + 1);
                    lines.Add(currentLine);
                    currentLine = "";
                    j = 0;
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                if (i != 0)
                {
                    Console.Write(newLine);
                }
                else
                {
                    Console.WriteLine();
                }

                // for every character in the passed in string of text, the console will write one character, wait a specified amount of time and then repeat       
                foreach (char c in lines[i])
                {
                    Console.Write(c);
                    Thread.Sleep(30);
                }
            }

            WriteEmptyLine();


            #region
            //j = 0;
            ////foreach loop used to increment an int i as long as characters are added to the string with the 'currentLine += c' operand
            //for (int i = 0; i < text.Length; i++)
            //{
            //    if (j >= maxLength)
            //    {
            //        int f = i;
            //        while (currentLine[f] != finder)
            //        {
            //            f--;
            //        }
            //        text = text.Remove(f, 1);
            //        text.Insert(f, newLine);
            //        j = 0;
            //    }               
            //}

            //Console.WriteLine();
            //foreach (char c in text)
            //{
            //    Console.Write(c);
            //    if (c != '\n' && c != '\t')
            //    {
            //        Thread.Sleep(30);
            //    }
            //}





            //foreach (char c in text)
            //{
            //    Console.Write(c);
            //    Thread.Sleep(30);


            //    // this will set a maximum length of a string when written. When the string reaches or exceeds that length, the console will put the rest of the string on a new line
            //    // currently, if a string is over the specified amount it starts a new line every time a character is written
            //    // if we could get it to do this action not once per character, but once per 50 for example, this would function correctly
            //    // this could be remedied by doing a for loop with the whole int i = 0; i < 50; i++ business
            //    // alternatively, we could sort this out by parsing the string to a char, then putting that into an array and ensuring that at a particular point in the array, a \n happens, making a new line
            //    // come in while the string is still being written out

            //    /*StringBuilder sb = new StringBuilder();
            //    int maxLength = 50;
            //    int stringLength = text.Length;

            //    if (stringLength > maxLength)
            //    {
            //        stringLength -= maxLength;
            //        Console.Write("\n\t");
            //    }*/
            //}


            //int stringLength = text.Length;
            //foreach (stringLength in text)
            //{
            //    if (stringLength > maxLength)
            //    {
            //        stringLength -= maxLength;
            //        Console.Write("\n\t");
            //    }
            //}

        }

        public static void Pause()
        {
            Thread.Sleep(1000);
        }

        public static void WriteTextWithSkip(string text, string colour = "")
        {
            //Thread writer = new Thread(() => WriteText(text));
            //writer.Start();

            //while(writer.ThreadState == ThreadState.Running)
            //{
            //    if (Console.KeyAvailable)
            //    {
            //        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            //        {
            //            writer.Abort();
            //            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            //            Console.Write(text);
            //        }
            //    }
            //}

            //writer.Join();

            WriteText(text, colour);
        }
        #endregion

        public static bool MoveOn()
        {
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    return true;
                }
            }

            //return false;
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }



        //SAVING ---

        /*
          First we use CheckIfDirectoryExists() to see if there is a location already made to save the game files to. If not, one will be created
          SaveGame() works by first calling CreateSaveFile(), which uses GetSaveFileList() to return a List of the save files in the directory
          It then uses CheckIfSaveFileExists(potentialName) to see if the text entered by the user matches the name of any of the save files in the directory
          If it does, it says save file exists, try another name, if not, it will create a new save file with the name the player input
          SaveGame() takes in a list of all of the objects within the scenario, and then serializes them into JSON
          It then takes wipes the save file, and writes the new JSON to it, updated and ready to load
        */

        //static List<string> saveFileNames = new List<string>();
        static List<string> saveFileNames = new List<string>();
        public static void PopulateSaveFileNames()
        {
            string saveFileName1;
            string saveFileName2;
            string saveFileName3;
            if (saveFileNames.Count == 0)
            {
                saveFileName1 = null;
                saveFileName2 = null;
                saveFileName3 = null;
                saveFileNames.Add(saveFileName1);
                saveFileNames.Add(saveFileName2);
                saveFileNames.Add(saveFileName3);
            }
            if (saveFileNames.Count == 1)
            {
                saveFileName2 = null;
                saveFileName3 = null;
                saveFileNames.Add(saveFileName2);
                saveFileNames.Add(saveFileName3);
            }
            if (saveFileNames.Count == 2)
            {
                saveFileName3 = null;
                saveFileNames.Add(saveFileName3);
            }
            if (saveFileNames.Count == 3)
            {

            }
            return;
        }

       
        public static bool IsNameAcceptable(string saveName)
        {
            bool isNameAcceptable = true;
            foreach (char c in saveName)
            {
                switch (c)
                {
                    case '<':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;
                    case '>':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;
                    case ':':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;
                    case '"':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;
                    case '/':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;
                    case '\\':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;
                    case '|':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;
                    case '?':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;
                    case '*':
                        isNameAcceptable = false;
                        NameNotAccepted();
                        return isNameAcceptable;

                }
            }

            switch (saveName)
            {
                case "CON":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "PRN":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "AUX":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "NUL":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM1":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM2":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM3":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM4":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM5":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM6":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM7":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM8":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "COM9":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT1":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT2":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT3":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT4":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT5":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT6":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT7":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT8":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
                case "LPT9":
                    isNameAcceptable = false;
                    NameNotAccepted();
                    return isNameAcceptable;
            }

            int i = saveName.Length - 1;
            if (saveName[i] == ' ' | saveName[i] == '.' | saveName == "")
            {
                isNameAcceptable = false;
                NameNotAccepted();
                return isNameAcceptable;
            }

            return isNameAcceptable;
        }


        public static void NameNotAccepted()
        {
            WriteText("This name contained either banned characters, or was a reserved filename.\nPlease rename your file accordingly.");
        }

        
        public static string CreateSaveFile()
        {
            string createdSaveName = "";
            for (int i = 0; i < saveFileNames.Count; i++)
            {
                if (saveFileNames[i] == null | saveFileNames[i] != "")
                {
                    while (true)
                    {
                        WriteText("Name your save file:");
                        string potentialName = Console.ReadLine();
                        potentialName = potentialName.ToUpper();
                        bool isNameAcceptable = IsNameAcceptable(potentialName);
                        if (!isNameAcceptable) break;
                        GetSaveFileList();
                        if (CheckIfSaveExists(potentialName) == true)
                        {
                            WriteText("A save file with this name already exists. Please choose a different name.");
                            break;
                        }
                        else
                        {
                            List<Object> gFContainer = new List<Object>();
                            int gameFlag = 1;
                            gFContainer.Add(gameFlag);
                            saveFileNames[i] = potentialName + ".txt";
                            using (StreamWriter sw = new StreamWriter(saveLocation + "\\" + saveFileNames[i]))
                            {
                                string gameFlagJSON = JsonConvert.SerializeObject(gFContainer, Formatting.Indented, new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All});
                                sw.Write(gameFlagJSON);
                            }
                            GetSaveFileList();
                            WriteText("Save file with the name \"" + potentialName + "\" has been created.");
                            createdSaveName = potentialName;
                            return createdSaveName;
                        }
                    }
                }
            }
            return createdSaveName;
        }


        public static string CreateAdditionalSaveFile()
        {
            if (saveFileNames[0] == null)
            {
                string createdSaveFile = CreateSaveFile();
                return createdSaveFile;
            }
            if (saveFileNames[1] == null)
            {
                string createdSaveFile = CreateSaveFile();
                return createdSaveFile;
            }
            else if (saveFileNames[2] == null)
            {
                string createdSaveFile = CreateSaveFile();
                return createdSaveFile;
            }
            else return "";
        }


        public static void UpdateGameFlag(List<Object> objectsToSave, int number)
        {
            for (int i = 0; i < objectsToSave.Count; i++)
            {
                if (objectsToSave[i] is System.Int64)
                {
                    objectsToSave[i] = number;
                }
            }
        }


        static string appLocation = AppDomain.CurrentDomain.BaseDirectory;
        static string saveLocation = appLocation + "saves";
        public static void CheckIfDirectoryExists()
        {
            //use this to get a list of the saves
            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
                WriteText("Save Folder Created.");
            }
        }


        public static void GetSaveFileList()
        {
            saveFileNames.Clear();
            string[] directoryList = Directory.GetFiles(saveLocation, "*", SearchOption.AllDirectories);
            List<string> extractedFileNames = new List<string>();
            foreach (string nameWithDirectory in directoryList)
            {
                string fileName = RemoveDotTXT(nameWithDirectory);
                extractedFileNames.Add(fileName);
            }
            saveFileNames.AddRange(extractedFileNames);
            PopulateSaveFileNames();
        }


        public static bool? CheckIfSaveExists(string input)
        {
            for (int i = 0; i < saveFileNames.Count; i++)
            {
                if (input == saveFileNames[i])
                {
                    return true;
                }
                else return false;
            }
            return null;
        }



        public static void SaveGame(List<Object> toSave)
        {
            string saveFileJSON = JsonConvert.SerializeObject(toSave, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            File.WriteAllText(saveLocation + "\\" + currentSaveLoaded + ".txt", string.Empty);
            File.WriteAllText(saveLocation + "\\" + currentSaveLoaded + ".txt", saveFileJSON);
        }


        public static void PlayerSaveGame(List<Object> toSave)
        {
            while (true)
            {
                Console.WriteLine("Would you like to save the game?");
                Console.WriteLine("1. Yes.   2. No.");
                char answer = Console.ReadKey().KeyChar;
                if (answer == '1')
                {
                    SaveGame(toSave);
                    WriteText("You saved the game.");
                    return;
                }
                else if (answer == '2')
                {
                    WriteText("You didn't save the game.");
                    return;
                }
            }
        }


        public static string RemoveDotTXT(string fileName)
        {
            string extractedFileName = "";
            int i = fileName.Length;
            i --;
            while (fileName[i] != '\\')
            {
                extractedFileName += fileName[i];
                i--;
            }
            string reversedString = "";
            if (extractedFileName[3] == '.')
            {
                for (int j = extractedFileName.Length - 1; extractedFileName[j] != '.'; j--)
                {
                    reversedString += extractedFileName[j];
                }
            }
            else
            {
                for (int j = extractedFileName.Length - 1; j > 0; j--)
                {
                    reversedString += extractedFileName[j];
                }
            }
            return reversedString;
        }


        public static void DeleteFile(string saveFile)
        {
            WriteText("Are you sure?");
            Console.WriteLine("1. Yes.   2. No.");
            char answer = Console.ReadKey().KeyChar;
            if (answer == '1')
            {
                File.Delete(saveLocation + "\\" + saveFile + ".txt");
                WriteText("You deleted " + saveFile + ".");
            }
            else
            {
                WriteText("You did not delete the save file.");
            }
        }


        



        //LOADING ---

        /*
          Loading works by calling the ChooseSave() method, which provides the user with a list of strings, showing the name of each save file
          The user will input a char that corresponds to the save they want to choose and the string finalSaveChoice will take on the name of the chosen file
          This is passed into LoadChosenSave(finalSaveChoice) and we then we use that string to locate the file, then we create a var which hosts the content of the file when read
          We then take that var and deserialize it back to a List of Objects, and pass those Objects to a List<Object> that stis outside of the method called deserializedObjects
          Then we've finished with LoadChosenSave(), and we write a foreach loop, which calls the CastObjectBack() method. This casts the argument as a SaveItem, then gets the ClassName property of the save item
          It uses a switch statement, to choose what object type to cast the SaveItem back to, and then when it decides, it sets an Object called objectReadyToLoad, to the value of the object that has just been cast back
          Now we have a complete List<Object> to pass back into the scenario.
        */



        public static void ChooseOptionOnSave(string saveChoice)
        {
            WriteText("1. Load Save.   2. Delete Save.");
            char secondInput = Console.ReadKey().KeyChar;
            if (saveChoice != null & saveChoice != "")
            {
                if (secondInput == '1')
                {
                    LoadChosenSave(saveChoice);
                    return;
                }
                if (secondInput == '2')
                {
                    DeleteFile(saveChoice);
                    for (int i = 0; i < saveFileNames.Count; i++)
                    {
                        if (saveFileNames[i] == saveChoice)
                        {
                            saveFileNames[i] = null;
                        }
                    }

                    if (saveFileNames[0] == null & saveFileNames[1] == null & saveFileNames[2] == null)
                    {
                        string createdSaveName = CreateSaveFile();
                        currentSaveLoaded = createdSaveName;
                        LoadChosenSave(createdSaveName);
                        DetermineScenario();
                    }
                    else ChooseAndLoadSave();

                    return;
                }
                else ChooseAndLoadSave();
            }
            else
            {
                WriteText("You cannot select an empty save. Please either choose an existing save, or create a new one.");
                ChooseAndLoadSave();
            }
        }
        

        public static string currentSaveLoaded = null;
        public static string ChooseAndLoadSave()
        {
            string finalSaveChoice = "";

            for (int i = 0; i < 3; i++)
            {
                if (saveFileNames[i] != null)
                {
                    WriteText(i + 1 + ". " + saveFileNames[i]);
                }
                else
                {
                    WriteText(i + 1 + ". Empty Save Slot.");
                }
            }

            if (saveFileNames[0] != null & saveFileNames[1] != null & saveFileNames[2] != null)
            {
                WriteText("\nType the corresponding number of the save you would like to choose.");
            }
            else WriteText("\nType the corresponding number of the save you would like to choose, or press 4 to create a save file.");
              

            List<char?> charList = new List<char?>() { '1', '2', '3', '4' };
            bool? decisionMade = null;
            while (decisionMade != true)
            {
                char? chosenOption = null;
                while (chosenOption == null)
                {
                    chosenOption = Console.ReadKey().KeyChar;
                    if (!charList.Contains(chosenOption))
                    {
                        chosenOption = null;
                    }
                }
                switch (chosenOption)
                {
                    case '1':
                        finalSaveChoice = saveFileNames[0];
                        ChooseOptionOnSave(finalSaveChoice);
                        currentSaveLoaded = finalSaveChoice;
                        decisionMade = true;
                        break;
                    case '2':
                        finalSaveChoice = saveFileNames[1];
                        ChooseOptionOnSave(finalSaveChoice);
                        currentSaveLoaded = finalSaveChoice;
                        decisionMade = true;
                        break;
                    case '3':
                        finalSaveChoice = saveFileNames[2];
                        ChooseOptionOnSave(finalSaveChoice);
                        currentSaveLoaded = finalSaveChoice;
                        decisionMade = true;
                        break;
                    case '4':
                        string createdSaveFile = CreateAdditionalSaveFile();
                        LoadChosenSave(createdSaveFile);
                        currentSaveLoaded = createdSaveFile;
                        decisionMade = true;
                        break;
                }
            }
            return finalSaveChoice;
        }



        static List<Object> objectsToLoadIntoSave = new List<Object>();
        public static void LoadChosenSave(string saveToLoad)
        {
            if (saveToLoad == ". Empty Save Slot.")
            {
                WriteText("You cannot load an empty save file. Please choose another.");
                return;
            }
            else
            {
                using (StreamReader sr = new StreamReader(saveLocation + "\\" + saveToLoad + ".txt"))
                {
                    string textRead = sr.ReadToEnd();
                    List<Object> objectsToLoad = JsonConvert.DeserializeObject<List<Object>>(textRead, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                    objectsToLoadIntoSave.AddRange(objectsToLoad);
                }
            }
        }


        public static void DetermineScenario()
        {
            for (int i = 0; i < objectsToLoadIntoSave.Count; i++)
            {
                if (objectsToLoadIntoSave[i] is System.Int64 objInt)
                {
                    if (objInt == 1)
                    {
                        Scenario1 scenario1 = new Scenario1(objectsToLoadIntoSave);
                        scenario1.Launch();
                    }
                    if (objInt == 2)
                    {
                        Scenario2 scenario2 = new Scenario2(objectsToLoadIntoSave);
                        Scenario2.AddObjectsToScenario2();
                        scenario2.Launch();
                    }
                    if (objInt == 3)
                    {

                    }
                }
            }
        }


        public static void DistributeObjectsInScenario(List<Object> saveItems, List<Character> charactersToLoad)
        {
            for (int i = 0; i < saveItems.Count; i++)
            {
                if (saveItems[i] is Character)
                {
                    charactersToLoad.Add((Character)saveItems[i]);
                    saveItems.Remove(saveItems[i]);
                }
            }
        }

       
        //LAUNCHING THE GAME ---
        /*
          Here we need to have a starting screen, which then brings us to the save menu
          If there are no saves we need to create a save
          Then, when the save has been created we start with Scenario1
        */
        
        public static void LaunchGame()
        {
            TitleScreen();
            CheckIfDirectoryExists();
            GetSaveFileList();
            //now display file names to save over and allow user to choose a slot, and create a save file 

            if (saveFileNames[0] == null & saveFileNames[1] == null & saveFileNames[2] == null)
            {
                currentSaveLoaded = CreateSaveFile();
                LoadChosenSave(currentSaveLoaded);
                DetermineScenario();
            }
            else
            {
                currentSaveLoaded = ChooseAndLoadSave();
                DetermineScenario();
            }
            //we want to give the option to create a new save as well
        }


        public static void TitleScreen()
        {
            WriteText("Welcome to my short fantasy game.");
            WriteText("Press the enter key to start.");
            Console.ReadLine();
        }


    }
}
