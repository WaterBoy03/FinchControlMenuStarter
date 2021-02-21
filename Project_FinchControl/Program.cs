using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control 
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    //              with code from John Velis from GitHub
    // Application Type: Console
    // Author: Momrik, A.J.
    // Dated Created: 2/19/2021
    // Last Modified: 
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                // I turned off C, D, and E because that isn't being worked on yet.
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                //Console.WriteLine("\tc) Data Recorder");
                //Console.WriteLine("\td) Alarm System");
                //Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                // I turned off C, D, and E because that isn't being worked on yet.
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    //case "c":

                    //    break;

                    //case "d":

                    //    break;

                    //case "e":

                    //    break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\td) Color Show");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(finchRobot);
                        break;

                    case "d":
                        TalentShowDisplayColorShow(finchRobot);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// This method invokes the Song of Storms method for lights and sounds.
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now play 'Song of Storms'!");
            Console.WriteLine("\tAnd glow depending on the note.");
            DisplayContinuePrompt();

            SongOfStorms(finchRobot);
            DisplayMenuPrompt("Talent Show Menu");
        }

        /// *****************************************************************
        /// *               Talent Show > Dance                 *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now BUST A MOVE!");
            DisplayContinuePrompt();
            BustAMove(finchRobot);


            DisplayMenuPrompt("Talent Show Menu");
        }

        /// *****************************************************************
        /// *               Talent Show > Mixing It Up                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("\tThe Finch robot will now MIX IT UP!");
            DisplayContinuePrompt();
            Console.WriteLine("\tThe Forward Circle!");
            ForwardCircle(finchRobot);
            DisplayContinuePrompt();
            Console.WriteLine("\tThe Reverse Circle!");
            ReverseCircle(finchRobot);

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// *****************************************************************
        /// *               Talent Show > Color Show                        *
        /// *****************************************************************
        /// The Color Show was my idea on how to incorporate methods that return
        /// a value and requires an argument. It also has a while number validation
        /// statment.
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayColorShow(Finch finchRobot)
        {
            string colorNumber;
            int colorInteger;
            int redLight;
            int greenLight;
            int blueLight;
            Console.CursorVisible = false;

            DisplayScreenHeader("Color Show");

            Console.WriteLine("\tThe Finch robot will glow in the color you enter! The colors are:");
            Console.WriteLine("\t0) None");
            Console.WriteLine("\t1) Red");
            Console.WriteLine("\t2) Orange");
            Console.WriteLine("\t3) Yellow");
            Console.WriteLine("\t4) Green");
            Console.WriteLine("\t5) Cyan");
            Console.WriteLine("\t6) Blue");
            Console.WriteLine("\t7) Purple");
            Console.WriteLine("\t8) White");
            colorNumber = Console.ReadLine();
            Console.WriteLine();
            while (!Int32.TryParse(colorNumber, out colorInteger)||!(colorInteger >= 0 && colorInteger <= 8))
            {
                if (colorInteger < 0 || colorInteger > 9)
                {
                    Console.WriteLine("\tPlease enter an integer from 0 to 8");
                    colorNumber = Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\tPlease do not enter letters");
                    Console.WriteLine("\tPlease enter an integer from 0 to 8.");
                    colorNumber = Console.ReadLine();
                    Console.WriteLine();
                }
            }
            //The variable colorInteger invokes three different arguments.
            //The arguments return with values to determine how much RGB light based on a switch and case statement.
            redLight = RedColorShow(colorInteger);
            greenLight = GreenColorShow(colorInteger);
            blueLight = BlueColorShow(colorInteger);
            finchRobot.setLED(redLight, greenLight, blueLight);
            finchRobot.wait(1500);
            finchRobot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }
        //The Light and Sound method invokes this method and plays the Song of Storms while changing colors.
        //This is a song from the Legend of Zelda.
        static void SongOfStorms(Finch finchRobot)
        {
            //Note A in Octave 4 and color blue
            finchRobot.setLED(0, 0, 255);
            finchRobot.noteOn(440);
            finchRobot.wait(400);
            //Note C in Octave 5 and color green
            finchRobot.setLED(0, 255, 0);
            finchRobot.noteOn(523);
            finchRobot.wait(400);
            //Note A in Octave 5 and color yellow
            finchRobot.setLED(245, 239, 66);
            finchRobot.noteOn(880);
            finchRobot.wait(400);
            //A break
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.wait(100);
            //Note A in Octave 4 and color blue
            finchRobot.setLED(0, 0, 255);
            finchRobot.noteOn(440);
            finchRobot.wait(400);
            //Note C in Octave 5 and color green
            finchRobot.setLED(0, 255, 0);
            finchRobot.noteOn(523);
            finchRobot.wait(400);
            //Note A in Octave 5 and color yellow
            finchRobot.setLED(245, 239, 66);
            finchRobot.noteOn(880);
            finchRobot.wait(400);
            //A break
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.wait(100);
            //Note B in Octave 4 and color red
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(494);
            finchRobot.wait(400);
            //A break
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.wait(100);
            //Note C in Octave 5 and color green
            finchRobot.setLED(0, 255, 0);
            finchRobot.noteOn(523);
            finchRobot.wait(400);
            //Note B in Octave 4 and color red
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(494);
            finchRobot.wait(400);
            //Note C in Octave 5 and color green
            finchRobot.setLED(0, 255, 0);
            finchRobot.noteOn(523);
            finchRobot.wait(400);
            //Note B in Octave 4 and color red
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(494);
            finchRobot.wait(400);
            //Note G in Octave 5 and color purple
            finchRobot.setLED(147, 66, 245);
            finchRobot.noteOn(784);
            finchRobot.wait(400);
            //Note E in Octave 5 and color cyan
            finchRobot.setLED(66, 182, 245);
            finchRobot.noteOn(659);
            finchRobot.wait(400);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
        }

        /// Color Show objects
        /// The enumeration and the int _ColorShow methods are for the Color Show
        /// of Talent Show. This allowed me to have one variable lead to three 
        /// different values for amount of RGB light.
        enum lightColors
        {
            NONE, RED, ORANGE, YELLOW, GREEN, CYAN, BLUE, PURPLE, WHITE
        }
        static int RedColorShow(int redDigit)
        {
            int redLight;
            switch ((lightColors)redDigit)
            {
                case lightColors.NONE:
                    redLight = 0;
                    break;
                case lightColors.RED:
                    redLight = 255;
                    break;
                case lightColors.ORANGE:
                    redLight = 255;
                    break;
                case lightColors.YELLOW:
                    redLight = 235;
                    break;
                case lightColors.GREEN:
                    redLight = 0;
                    break;
                case lightColors.CYAN:
                    redLight = 66;
                    break;
                case lightColors.BLUE:
                    redLight = 0;
                    break;
                case lightColors.PURPLE:
                    redLight = 147;
                    break;
                case lightColors.WHITE:
                    redLight = 255;
                    break;
                default:
                    redLight = 0;
                    break;
            }
            return redLight;
        }
        static int GreenColorShow(int greenDigit)
        {
            int greenLight;
            switch ((lightColors)greenDigit)
            {
                case lightColors.NONE:
                    greenLight = 0;
                    break;
                case lightColors.RED:
                    greenLight = 0;
                    break;
                case lightColors.ORANGE:
                    greenLight = 132;
                    break;
                case lightColors.YELLOW:
                    greenLight = 235;
                    break;
                case lightColors.GREEN:
                    greenLight = 255;
                    break;
                case lightColors.CYAN:
                    greenLight = 182;
                    break;
                case lightColors.BLUE:
                    greenLight = 0;
                    break;
                case lightColors.PURPLE:
                    greenLight = 66;
                    break;
                case lightColors.WHITE:
                    greenLight = 255;
                    break;
                default:
                    greenLight = 0;
                    break;
            }
            return greenLight;
        }

        static int BlueColorShow(int blueDigit)
        {
            int blueLight;
            switch ((lightColors)blueDigit)
            {
                case lightColors.NONE:
                    blueLight = 0;
                    break;
                case lightColors.RED:
                    blueLight = 0;
                    break;
                case lightColors.ORANGE:
                    blueLight = 0;
                    break;
                case lightColors.YELLOW:
                    blueLight = 52;
                    break;
                case lightColors.GREEN:
                    blueLight = 0;
                    break;
                case lightColors.CYAN:
                    blueLight = 245;
                    break;
                case lightColors.BLUE:
                    blueLight = 255;
                    break;
                case lightColors.PURPLE:
                    blueLight = 245;
                    break;
                case lightColors.WHITE:
                    blueLight = 255;
                    break;
                default:
                    blueLight = 0;
                    break;
            }
            return blueLight;
        }
        //This method is for the Talent Show Dancing. It is the song from the Song of Storms method with dance.
        static void BustAMove(Finch finchRobot)
        {
            bool doneDance = false;
            while (!doneDance)
            {
                finchRobot.setMotors(-10, 155);
                //Note A in Octave 4 and color blue
                finchRobot.setLED(0, 0, 255);
                finchRobot.noteOn(440);
                finchRobot.wait(400);
                //Note C in Octave 5 and color green
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(523);
                finchRobot.wait(400);
                //Note A in Octave 5 and color yellow
                finchRobot.setLED(245, 239, 66);
                finchRobot.noteOn(880);
                finchRobot.wait(400);
                //A break
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.wait(100);

                finchRobot.setMotors(155, -10);
                //Note A in Octave 4 and color blue
                finchRobot.setLED(0, 0, 255);
                finchRobot.noteOn(440);
                finchRobot.wait(400);
                //Note C in Octave 5 and color green
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(523);
                finchRobot.wait(400);
                //Note A in Octave 5 and color yellow
                finchRobot.setLED(245, 239, 66);
                finchRobot.noteOn(880);
                finchRobot.wait(400);
                //A break
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.wait(100);

                finchRobot.setMotors(-30, 10);
                //Note B in Octave 4 and color red
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(494);
                finchRobot.wait(400);
                //A break
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.wait(100);
                //Note C in Octave 5 and color green
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(523);
                finchRobot.wait(400);
                finchRobot.setMotors(100, 100);
                //Note B in Octave 4 and color red
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(494);
                finchRobot.wait(400);
                //Note C in Octave 5 and color green
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(523);
                finchRobot.wait(400);
                //Note B in Octave 4 and color red
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(494);
                finchRobot.wait(400);
                //Note G in Octave 5 and color purple
                finchRobot.setLED(147, 66, 245);
                finchRobot.noteOn(784);
                finchRobot.wait(400);
                //Note E in Octave 5 and color cyan
                finchRobot.setLED(66, 182, 245);
                finchRobot.noteOn(659);
                finchRobot.wait(400);
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.setMotors(0, 0);
                doneDance = true;
            }
        }

        //This method is for a simple circle with random light colors for the Mixing It Up method.
        static void ForwardCircle(Finch finchRobot)
        {
            var Random = new Random();
            finchRobot.setMotors(200, 50);
            for (int count = 0; count < 10; count++)
            {
                int redLight = Random.Next(0, 255);
                int greenLight = Random.Next(0, 255);
                int blueLight = Random.Next(0, 255);
                finchRobot.setLED(redLight, greenLight, blueLight);
                finchRobot.wait(500);
            }
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);
        }
        //This method is for a simple circle with random light colors for the Mixing It Up method.
        static void ReverseCircle(Finch finchRobot)
        {
            var Random = new Random();
            finchRobot.setMotors(-50, -200);
            for (int count = 0; count < 10; count++)
            {
                int redLight = Random.Next(0, 255);
                int greenLight = Random.Next(0, 255);
                int blueLight = Random.Next(0, 255);
                finchRobot.setLED(redLight, greenLight, blueLight);
                finchRobot.wait(500);
            }
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);
        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;
            bool connectionWanted=true;
            string connectionResponse;
            string testWanted;
            

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();
            Console.WriteLine();
            
            robotConnected = finchRobot.connect();

            //I didn't have my Finch properly connected while practicing, so I made this loop to show that it wasn't connected.
            while (robotConnected != connectionWanted)
            {            
                Console.WriteLine("\tThere was an error with the connection.");
                Console.WriteLine("\tMake sure that the robot is properly connected to the computer.");
                Console.WriteLine("\tWould you like to try again? (Yes or No)");
                connectionResponse = Console.ReadLine().ToLower();
                Console.WriteLine();
                finchRobot.disConnect();
                while (connectionResponse != "no" && connectionResponse != "yes")
                    {
                        Console.WriteLine("\tPlease enter 'Yes' or 'No'.");
                        connectionResponse = Console.ReadLine().ToLower();
                    }
                if (connectionResponse == "yes")
                { 
                    Console.WriteLine("\tAttempting to connect to Finch robot.");
                    DisplayContinuePrompt();
                    robotConnected = finchRobot.connect();
                    connectionWanted = true;
                }
                else
                {
                    Console.WriteLine("\tThe Finch robot will not be connected.");
                    connectionWanted = false;

                }
        
                
            }

            // TODO test connection and provide user feedback - text, lights, sounds
            if (robotConnected)
            {
                Console.WriteLine("\tWould you like to test the Finch's lights and sounds? (Yes or No)");
                testWanted = Console.ReadLine().ToLower();
                Console.WriteLine();
                while (testWanted != "no" && testWanted != "yes")
                {
                    Console.WriteLine("\tPlease enter 'Yes' or 'No'.");
                    testWanted = Console.ReadLine().ToLower();
                }
                if (testWanted == "yes")
                {
                    Console.Clear();
                    Console.WriteLine("\tWould you like to test the sound? Yes or No");
                    testWanted = Console.ReadLine().ToLower();
                    Console.WriteLine();

                    //This is a loop that validates a yes or no response.
                    //A yes response would invoke the SoundTest method.
                    while (testWanted != "no" && testWanted != "yes")
                    {
                        Console.WriteLine("\tPlease enter 'Yes' or 'No'.");
                        testWanted = Console.ReadLine().ToLower();
                    }
                    if (testWanted == "yes")
                    {
                        SoundTest(finchRobot);
                        Console.WriteLine();
                    }

                    //This is a loop that validates a yes or no response.
                    //A yes response would invoke the LightTest method.
                    Console.WriteLine("\tWould you like to test the lights? Yes or No");
                    testWanted = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    while (testWanted != "no" && testWanted != "yes")
                    {
                        Console.WriteLine("\tPlease enter 'Yes' or 'No'.");
                        testWanted = Console.ReadLine().ToLower();
                    }
                    if (testWanted == "yes")
                    {
                        LightTest(finchRobot);
                        Console.WriteLine();
                    }
                }
            }
           
            

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }
        /// <summary>
        /// *****************************************************************
        /// *                     Testing The Finch's Sounds                *
        /// *****************************************************************
        /// This is a method in the form of a loop.
        /// This allows people to test their finch's sound by entering an integer.
        static void SoundTest(Finch finchRobot)
        {
            int soundNumber;
            string soundResponse;
            string tryAgain;
            bool soundBool = false;

            //This loop validates for numeral and string inputs to escape the loop.
            while (!soundBool)
            {
                Console.WriteLine("\tEnter an integer between 16 and 19913");
                soundResponse = Console.ReadLine();
                Console.WriteLine();
                if (Int32.TryParse(soundResponse, out soundNumber))
                {
                    if (soundNumber >= 16 && soundNumber <= 19913)
                    {
                        finchRobot.noteOn(soundNumber);
                        finchRobot.wait(500);
                        finchRobot.noteOff();
                        Console.WriteLine("\tWould you like to try a different number? Yes or No");
                        tryAgain = Console.ReadLine().ToLower();

                        while (tryAgain != "no" && tryAgain != "yes")
                        {
                            Console.WriteLine("\tPlease enter 'Yes' or 'No'.");
                            tryAgain = Console.ReadLine().ToLower();
                        }
                        if (tryAgain == "no")
                        {
                            soundBool = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\tPlease enter an integer between 16 and 19913. Press any key to retry.");
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }


        }

        /// *****************************************************************
        /// *                     Testing The Finch's Lights                *
        /// *****************************************************************
        /// This is a loop in the form of a loop.
        /// The loop is to allow people to enter integers between 0 and 255.
        /// The loop validates integers and 'yes' and 'no' responses.
        /// People can try different colors if they want to, before going back to the main menu.
        static void LightTest(Finch finchRobot)
        {
            int redNumber;
            int greenNumber;
            int blueNumber;
            string lightResponse;
            string tryAgain;
            bool lightBool = false;
            bool redPass = false;
            bool greenPass = false;
            bool bluePass = false;

            //These nested while decisions can only be escaped with integers between 0 and 255, and answering no to doing it again.
            while (!lightBool)
            {
                while (!redPass)
                {
                    Console.WriteLine("\tEnter an integer between 0 and 255 for the amount of red light");
                    lightResponse = Console.ReadLine();
                    Console.WriteLine();

                    if (Int32.TryParse(lightResponse, out redNumber))
                    {
                        if (redNumber >= 0 && redNumber <= 255)
                        {
                            redPass = true;
                            while (!greenPass)
                            {
                                Console.WriteLine("\tEnter an integer between 0 and 255 for the amount of green light");
                                lightResponse = Console.ReadLine();
                                Console.WriteLine();
                                if (Int32.TryParse(lightResponse, out greenNumber))
                                {
                                    if (greenNumber >= 0 && greenNumber <= 255)
                                    {
                                        greenPass = true;
                                        while (!bluePass)
                                        {
                                            Console.WriteLine("\tEnter an integer between 0 and 255 for the amount of blue light");
                                            lightResponse = Console.ReadLine();
                                            Console.WriteLine();
                                            if (Int32.TryParse(lightResponse, out blueNumber))
                                            {
                                                if (blueNumber >= 0 && blueNumber <= 255)
                                                {
                                                    bluePass = true;
                                                    finchRobot.setLED(redNumber, greenNumber, blueNumber);
                                                    finchRobot.wait(2500);
                                                    finchRobot.setLED(0, 0, 0);
                                                    Console.WriteLine("\tWould you like to try a different color? Yes or No");
                                                    tryAgain = Console.ReadLine().ToLower();
                                                    //Validates for a 'yes' or 'no' response.
                                                    while (tryAgain != "no" && tryAgain != "yes")
                                                    {
                                                        Console.WriteLine("\tPlease enter 'Yes' or 'No'.");
                                                        tryAgain = Console.ReadLine().ToLower();
                                                    }
                                                    //Answering 'no' allows on to escape the Color Test method.
                                                    if (tryAgain == "no")
                                                    {
                                                        lightBool = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\tPress any key to reenter RGB values.");
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\tPlease enter an integer between 0 and 255. Press any key to retry.");
                                                    Console.ReadKey();
                                                    Console.WriteLine();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\tPlease enter an integer, not letters. Press any key to retry.");
                                                Console.ReadKey();
                                                Console.WriteLine();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\tPlease enter an integer between 0 and 255. Press any key to retry.");
                                        Console.ReadKey();
                                        Console.WriteLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\tPlease enter an integer, not letters. Press any key to retry.");
                                    Console.ReadKey();
                                    Console.WriteLine();
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("\tPlease enter an integer between 0 and 255. Press any key to retry");
                            Console.ReadKey();
                            Console.WriteLine();
                        }


                    }
                    else
                    {
                        Console.WriteLine("\tPlease enter an integer, not letters. Press any key to retry.");
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                    //This resets the previous nested while loops if the user responds with 'yes' to entering a new color.
                    if (!lightBool)
                    {
                        redPass = false;
                        greenPass = false;
                        bluePass = false;
                    }
                }
            }

        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();
            Console.WriteLine("\tThe application to play with your Finch");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion

    }
}
