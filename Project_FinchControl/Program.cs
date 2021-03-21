using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;
using System.Globalization;

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

    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        MAKENOISE,
        STOPNOISE,
        GETTEMPERATURE,
        GETLIGHTREADING,
        ALLON,
        ALLOFF,
        DANCE,
        DONE
    }
    public enum Note
    {
        C,
        D,
        E,
        F,
        G,
        A,
        B

    }
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
                
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice             
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                       break;

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
                Console.Write("\t\tEnter Choice: ");
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
            
            for (int count = 0; count < 10; count++)
            {
                finchRobot.setMotors(200, 50);
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
            
            for (int count = 0; count < 10; count++)
            {
                finchRobot.setMotors(-50, -200);
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

        /// <summary>
        /// A method for validating 'yes' and 'no' responses
        /// </summary>
        /// <param name="userResponse"></param>
        /// <returns></returns>
        static string YesOrNoValidation(string userResponse)
        {
            while (userResponse!="yes"&&userResponse!="no")
            {
                Console.WriteLine("\tPlease enter 'yes' or 'no'");
                userResponse = Console.ReadLine().ToLower();
                Console.WriteLine();
            }
            return userResponse;
        }

        /// <summary>
        /// Validates an integer
        /// </summary>
        /// <param name="numberResponse"></param>
        /// <returns></returns>
        static int IntNumberValidation(string numberResponse)
        {
            int numberOfDataPoints;
            while (!Int32.TryParse(numberResponse, out numberOfDataPoints))
            {
                Console.WriteLine("\tPlease enter an integer.");
                Console.Write("\tNumber: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return numberOfDataPoints;

        }

        //This validates an integert that is above zero.
        static int IntNumberValidationAboveZero(string numberResponse)
        {
            int numberOfDataPoints;
            while (!Int32.TryParse(numberResponse, out numberOfDataPoints) || numberOfDataPoints <= 0)
            {
                Console.WriteLine("\tPlease enter an integer above zero.");
                Console.Write("\tNumber: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return numberOfDataPoints;

        }

        //This validates an integer that is zero or above.
        static int IntNumberValidationZeroOrAbove(string numberResponse)
        {
            int numberOfDataPoints;
            while (!Int32.TryParse(numberResponse, out numberOfDataPoints) || numberOfDataPoints < 0)
            {
                Console.WriteLine("\tPlease enter an integer that is zero or above.");
                Console.Write("\tNumber: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return numberOfDataPoints;

        }

        //This validates for a number above zero.
        static double DoubleNumberValidationAboveZero(string numberResponse)
        {
           double numberOfDataPoints;
            while (!Double.TryParse(numberResponse, out numberOfDataPoints) || numberOfDataPoints <= 0)
            {
                Console.WriteLine("\tPlease enter a number above zero.");
                Console.Write("\tNumber: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return numberOfDataPoints;

        }

        //This validates a number that is 0 or above.
        static double DoubleNumberValidationZeroOrAbove(string numberResponse)
        {
            double numberOfDataPoints;
            while (!Double.TryParse(numberResponse, out numberOfDataPoints) || numberOfDataPoints < 0)
            {
                Console.WriteLine("\tPlease enter a number that is zero or above.");
                Console.Write("\tNumber: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return numberOfDataPoints;
        }

        //This validates a number.
        static double DoubleNumberValidation(string numberResponse)
        {
            double numberOfDataPoints;
            while (!Double.TryParse(numberResponse, out numberOfDataPoints))
            {
                Console.WriteLine("\tPlease enter a number.");
                Console.Write("\tNumber: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return numberOfDataPoints;
        }


        //This calculates the sum of an array.
        static double SumOfAnArray(double[] anArray)
        {
            double sum=0;
            foreach(double item in anArray)
            {
                sum += item;
            }
            return sum;
        }
        
        //This calculates the average of an array.
        static double AverageOfAnArray(double sum, int lengthArray)
        {
            double average=sum/lengthArray;
            return average;
        }

        #endregion

        #region DATA RECORDER

        //This is the method for the Data Recorder Menu.
        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            int numberOfDataPoints=0;
            double dataPointFrequency=0;
            double[] temperatures = null;
            Console.CursorVisible = true;
            bool quitMenu = false;
            string menuChoice;
            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Temperature Data");
                Console.WriteLine("\te) Light Recording");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints=DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency=DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures=DataRecorderDisplayGetData(numberOfDataPoints,dataPointFrequency,finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayShowData(temperatures);
                        break;

                    case "e":
                        DataRecordDisplayLightRecord(finchRobot);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

        }

        //This method is for collecting and displaying light recording.
        static void DataRecordDisplayLightRecord(Finch finchRobot)
        {
            int numberOfLeft = 0;
            double leftFrequency = 0;
            int numberOfRight = 0;
            double rightFrequency = 0;
            string userResponse;
            double[] leftLightAmounts = null;
            double[] rightLightAmounts = null;
            double leftSum = 0;
            double rightSum = 0;
            double bothSum = 0;
            double leftAverage = 0;
            double rightAverage = 0;
            double bothAverage = 0;
            string[] leftArray = null;
            string[] rightArray = null;


            DisplayScreenHeader("Light Recording");
            Console.WriteLine();

            //This requires the user to connect their finch for light recordings
            //I realize that I don't code if the Finch gets disconnected during recording. I don't know what would happen...
            if (!finchRobot.connect())
            {
                Console.WriteLine("\tPlease connect your Finch robot.");
                Console.WriteLine("\tWould you like to be taken to the Connect Finch menu? Yes or No");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                if (userResponse == "yes")
                {
                    DisplayConnectFinchRobot(finchRobot);
                }
            }
            else
            {
                Console.WriteLine("\tHow many light reading would you like to the left sensor to take?");
                userResponse = Console.ReadLine();
                numberOfLeft = IntNumberValidationZeroOrAbove(userResponse);
                Console.WriteLine();
                if (numberOfLeft > 0)
                {
                    Console.WriteLine("\tWhat frequency would you like the reading be taken?");
                    userResponse = Console.ReadLine();
                    leftFrequency = DoubleNumberValidationAboveZero(userResponse);
                    Console.WriteLine();
                    leftLightAmounts = DataRecordingLeftLightReading(numberOfLeft, leftFrequency, finchRobot);
                    leftArray = DataRecordingLightSensorDirection(leftLightAmounts.Length, "Left ");
                    leftSum = SumOfAnArray(leftLightAmounts);
                    leftAverage = AverageOfAnArray(leftSum, leftLightAmounts.Length);
                }
                DisplayContinuePrompt();

                //Clears the screen for the right light readings.
                DisplayScreenHeader("Light Recording");
                Console.WriteLine();
                Console.WriteLine("\tHow many light reading would you like to the right sensor to take?");
                userResponse = Console.ReadLine();
                numberOfRight = IntNumberValidationZeroOrAbove(userResponse);
                Console.WriteLine();
                if (numberOfRight > 0)
                {
                    Console.WriteLine("\tWhat frequency would you like the reading be taken?");
                    userResponse = Console.ReadLine();
                    rightFrequency = DoubleNumberValidationAboveZero(userResponse);
                    Console.WriteLine();
                    rightLightAmounts = DataRecordingRightLightReading(numberOfRight, rightFrequency, finchRobot);
                    rightArray = DataRecordingLightSensorDirection(rightLightAmounts.Length, "Right ");
                    rightSum = SumOfAnArray(rightLightAmounts);
                    rightAverage = AverageOfAnArray(rightSum, rightLightAmounts.Length);
                }
                DisplayContinuePrompt();

                //This section is if only one side took readings.
                if (rightLightAmounts == null || leftLightAmounts == null)
                {
                    //This displays only the right light readings because the no left readings were taken.
                    if (leftLightAmounts == null)
                    {
                        Console.WriteLine("\tWould you like to see a table of your data? Yes or No");
                        userResponse = Console.ReadLine().ToLower();
                        YesOrNoValidation(userResponse);
                        if (userResponse == "yes")
                        {
                            DisplayScreenHeader("Light Recording");
                            Array.Sort(rightLightAmounts,rightArray);
                            DataRecorderDisplayLightTable(rightArray, rightLightAmounts);
                            DataRecorderDisplaySumAndAverages("Right", rightSum, rightAverage);
                        }
                    }

                    //This displays only the left light readings because the no right readings were taken.
                    else if (rightLightAmounts == null)
                    {
                        Console.WriteLine("\tWould you like to see a table of your data? Yes or No");
                        userResponse = Console.ReadLine().ToLower();
                        YesOrNoValidation(userResponse);
                        if (userResponse == "yes")
                        {
                            DisplayScreenHeader("Light Recording");
                            Array.Sort(leftLightAmounts,leftArray);
                            DataRecorderDisplayLightTable(leftArray, leftLightAmounts);
                            DataRecorderDisplaySumAndAverages("Left", leftSum, leftAverage);
                        }
                    }
                }

                //This shows both  light readings together if the user wants to see a table.
                else
                {
                    Console.WriteLine("\tWould you like to see a table of your data? Yes or No");
                    userResponse = Console.ReadLine().ToLower();
                    YesOrNoValidation(userResponse);
                    if (userResponse == "yes")
                    {
                        DisplayScreenHeader("Light Recording");
                        //This combines both left and right light recordings into one array.
                        var myList = new List<double>();
                        myList.AddRange(leftLightAmounts);
                        myList.AddRange(rightLightAmounts);
                        double[] bothLightAmounts = myList.ToArray();
                        bothSum = SumOfAnArray(bothLightAmounts);
                        bothAverage = AverageOfAnArray(bothSum, bothLightAmounts.Length);

                        //This combines my left and right numbering into one array.
                        var myDir = new List<string>();
                        myDir.AddRange(leftArray);
                        myDir.AddRange(rightArray);
                        string[] bothDirectionArrays = myDir.ToArray();
                        DisplayScreenHeader("Light Recording");
                        Array.Sort(bothLightAmounts,bothDirectionArrays);
                        DataRecorderDisplayLightTable(bothDirectionArrays, bothLightAmounts);
                        DataRecorderDisplaySumAndAverages("Left", leftSum, leftAverage);
                        DataRecorderDisplaySumAndAverages("Right", rightSum, rightAverage);
                        DataRecorderDisplaySumAndAverages("Both", bothSum, bothAverage);
                    }
                    Console.WriteLine();
                }
            }
            DisplayContinuePrompt();
        }

        //This method turns on the left light sensor. I did not think of adding an if/else if statement to
        //to determine which side to use until after I finished the right side.
        static double[] DataRecordingLeftLightReading(int numberOfLeft, double leftFrequency, Finch finchRobot)
        {
            double[] lightAmounts = new double[numberOfLeft];

            for (int index = 0; index < numberOfLeft; index++)
            {
                lightAmounts[index] = finchRobot.getLeftLightSensor();
                Console.WriteLine($"\tReading {index + 1}: {lightAmounts[index].ToString("n2")}");
                int waitInSeconds = (int)(leftFrequency * 1000);
                finchRobot.wait(waitInSeconds);
            }
            return lightAmounts;
        }
        //This creates an array the labels which sensor recorded the light amount. 
        static string[] DataRecordingLightSensorDirection(int lengthOfArray, string direction)
        {
            //I needed to have an array size for it to work.
            string[] numberedDirections = new string[lengthOfArray];
            for (int index = 0; index < lengthOfArray; index++)
            {
                numberedDirections[index] = $"{direction}{index + 1}";
            }
            return numberedDirections;
        }

        //This method turns on the right light sensor.
        static double[] DataRecordingRightLightReading(int numberOfRight, double rightFrequency, Finch finchRobot)
        {
            double[] lightAmounts = new double[numberOfRight];

            for (int index = 0; index < numberOfRight; index++)
            {
                lightAmounts[index] = finchRobot.getRightLightSensor();
                Console.WriteLine($"\tReading {index + 1}: {lightAmounts[index].ToString("n2")}");
                int waitInSeconds = (int)(rightFrequency * 1000);
                finchRobot.wait(waitInSeconds);
            }
            return lightAmounts;
        }

        //This method shows a table of the temperature data collected.
        static void DataRecorderDisplayShowData(double[] temperatures)
        {

            DisplayScreenHeader("Show Temperature Data");
            Console.WriteLine();

            //This if statement makes the user have to record data to view the table
            if (temperatures == null)
            {
                Console.WriteLine("\tPlease go to Get Data to measure the temperature.");

            }

            //This displays the table of temperature readings.
            else
            {
                double tempSum = SumOfAnArray(temperatures);
                double tempAverage = AverageOfAnArray(tempSum, temperatures.Length);
                DataRecorderDisplayTable(temperatures);
                DataRecorderDisplaySumAndAverages("Temperature", tempSum, tempAverage);
            }
            DisplayContinuePrompt();
        }

        //This table is for displaying light recorded data.
        static void DataRecorderDisplayLightTable(string[] sensorArray, double[] lightAmounts)
        {
            //display table header
            Console.WriteLine("\tTable of Light Measured");
            Console.WriteLine();
            Console.WriteLine(
                "Sensor      ".PadLeft(15) +
                "Light Amount".PadLeft(15)
                );
            Console.WriteLine(
                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)
                );

            //display table data
            for (int index = 0; index < lightAmounts.Length; index++)
            {
                Console.WriteLine(
                sensorArray[index].PadLeft(15) +
                (lightAmounts[index].ToString()).PadLeft(15)
                );
            }

        }

        //This displays the average and sum for the arrays. 
        //The method is to be invoked after the the table method was called. 
        static void DataRecorderDisplaySumAndAverages(string forWhat,double sum, double average)
        {
            Console.WriteLine(
                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)
                );
            if(forWhat=="Temperature")
            {
                Console.WriteLine("\t{0} Sum: {1}", forWhat, sum.ToString("n2") + " °F");
                Console.WriteLine("\t{0} Average: {1}", forWhat, average.ToString("n2") + " °F");
            }
            else
            {
                Console.WriteLine("\t{0} Sum: {1}", forWhat, sum.ToString("n2"));
                Console.WriteLine("\t{0} Average: {1}", forWhat, average.ToString("n2"));
            }
            
        }
        
        //This table is for displaying temperature data.
        static void DataRecorderDisplayTable(double[] temperatures)
        {
            //display table header
            Console.WriteLine("\tTable of Temperatures");
            Console.WriteLine();
            Console.WriteLine(
                "Recording  ".PadLeft(15) +
                "Temp".PadLeft(15)
                );
            Console.WriteLine(
                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)
                );

            //display table data            
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                (temperatures[index].ToString("n2") + " °F").PadLeft(15)
                );
            }
        }

        //This method allows the user collect temperature readings in Fahrenheit. 
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];
            string userResponse;

            DisplayScreenHeader("Get Data");

            //This prevents the user from trying to collect data without inputting how many and how often of temperature readings taken.
            if (numberOfDataPoints==0||dataPointFrequency==0)
            {
                Console.WriteLine("\tPlease return to the Data Recorder Menu.");
                Console.WriteLine("\tYou need to enter the number of data points and the frequency for them to be recordered.");
            }

            //Prompts the user to connect the Finch if it is not already connected.
            else if(!finchRobot.connect())
            {
                Console.WriteLine("\tPlease connect your Finch robot.");
                Console.WriteLine("\tWould you like to be taken to the Connect Finch menu? Yes or No");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                if (userResponse == "yes")
                {
                    DisplayConnectFinchRobot(finchRobot);
                }
            }

            //An else statement that allows for the collection of temperatures.
            else 
            {                
                Console.WriteLine($"\tNumber of data points: {numberOfDataPoints}");
                Console.WriteLine($"\tData point frequency: {dataPointFrequency}");
                Console.WriteLine();
                Console.WriteLine("\tThe Finch robot is ready to begin recording the temperature data.");
                DisplayContinuePrompt();

                for (int index = 0; index < numberOfDataPoints; index++)
                {
                    temperatures[index] = finchRobot.getTemperature();

                    //Allows for the temperature[index] to be converted to Fahrenheit and saved to the array
                    double celsiusTemp = temperatures[index];
                    double fahrenheitTemp = ConvertCelsiusToFahrenheit(celsiusTemp);
                    temperatures[index] = fahrenheitTemp;
                    Console.WriteLine($"\tReading {index + 1}: {temperatures[index].ToString("n2")} °F");
                    int waitInSeconds = (int)(dataPointFrequency * 1000);
                    finchRobot.wait(waitInSeconds);
                }
                Console.WriteLine("\tWould you like to see temperatures in a table? (Yes or No)");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                Console.WriteLine();

                if (userResponse == "yes") 
                {
                    DisplayScreenHeader("Get Data");
                    Console.WriteLine();

                    //Gets the average and sum of the array for the table
                    double tempSum = SumOfAnArray(temperatures);
                    double tempAverage = AverageOfAnArray(tempSum, temperatures.Length);
                    DataRecorderDisplayTable(temperatures);
                    DataRecorderDisplaySumAndAverages("Temperature", tempSum, tempAverage);
                }                            
            }

            DisplayContinuePrompt();
            return temperatures;
        }

        /// <summary>
        /// Gets the frequency of data points from the user
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            string numberResponse;

            DisplayScreenHeader("Data Point Frequency");
            Console.Write("\tFrequency of data points: ");

            //validate user input
            numberResponse = Console.ReadLine();
            Console.WriteLine();
            while (!Double.TryParse(numberResponse, out dataPointFrequency) || dataPointFrequency <= 0)
            {
                Console.WriteLine("\tPlease enter a number above zero.");
                Console.Write("\tFrequency of data points: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return dataPointFrequency;
        }

        /// <summary>
        /// Gets the number of data points from the user
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string numberResponse;

            DisplayScreenHeader("Number of Data Points");
            Console.Write("\tNumber of data points: ");

            //validate user input
            numberResponse = Console.ReadLine();
            Console.WriteLine();
            while (!Int32.TryParse(numberResponse, out numberOfDataPoints)||numberOfDataPoints<=0)
            {
                Console.WriteLine("\tPlease enter an integer above zero.");
                Console.Write("\tNumber of data points: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
                return numberOfDataPoints;
        }

        //My method for converting Celsius to Fahrenheit.
        static double ConvertCelsiusToFahrenheit(double celsiusTemp)
        {
            double FahrenheitTemp = celsiusTemp * 9 / 5 + 32;
            return FahrenheitTemp;
        }
        #endregion

        #region Alarm System 

        /// <summary>
        /// Light Alarm Menu
        /// </summary>
        /// <param name="finchRobot"></param>
        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {
            
            Console.CursorVisible = true;
            bool quitMenu = false;
            string menuChoice;
            string menuSwith = "light";
            string sensorsToMonitor="";
            string rangeType="";
            int minMaxThresholdValue=0;
            int timeToMonitor=0;
            string rangeTypeTemperature = "";
            double minMaxThresholdValueTemperature = 0;
            

            do 
            {
                //This loop is for setting variables for the Light Alarm
                while (menuSwith == "light"&&!quitMenu)
                {
                    DisplayScreenHeader("Light Alarm Menu");
                    
                    Console.WriteLine("\ta) Set Sensors to Monitor");
                    Console.WriteLine("\tb) Set Range Type");
                    Console.WriteLine("\tc) Set Minimum/Maximum Threshold Value");
                    Console.WriteLine("\td) Set Time to Monitor for Light and Temperature");
                    Console.WriteLine("\te) Set Alarm");
                    Console.WriteLine("\tf) Switch to Temperature Alarm Menu");
                    Console.WriteLine("\tg) Set Alarm for Light and Temperature");
                    Console.WriteLine("\tq) Main Menu");

                    //This displaces the light reading after the user pick a light sensor
                    if (sensorsToMonitor != "")
                    {
                       LightAlarmLightLevelFixedLocation(sensorsToMonitor, finchRobot);
                        Console.SetCursorPosition(0, 11);
                    }
                    Console.Write("\t\tEnter Choice: ");
                   
                    menuChoice = Console.ReadLine().ToLower();
                    
                    
                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            sensorsToMonitor = LightAlarmDisplayMenuScreenSetSensorsToMonitor();
                            break;

                        case "b":
                            rangeType = LightAlarmDisplayMenuScreenSetRangeType();
                            break;

                        case "c":
                            minMaxThresholdValue = LightAlarmDisplayMenuScreenSetMinMaxThresholdValue(rangeType, finchRobot);
                            break;

                        case "d":
                            timeToMonitor = LightAlarmDisplayMenuScreenSetTimeToMonitor();
                            break;

                        case "e":
                            LightAlarmDisplayMenuScreenSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
                            break;

                        case "f":
                            menuSwith = "temperature";
                            break;

                        case "g":
                            LightAndTemperatureAlarmDisplayMenuScreenSetAlarm(finchRobot, sensorsToMonitor, rangeType, rangeTypeTemperature, minMaxThresholdValue, timeToMonitor, minMaxThresholdValueTemperature);
                            break;

                        case "q":
                            quitMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            break;
                    }
                }
                //This loop is for setting the variables for the Temperature Alarm
                while (menuSwith == "temperature"&&!quitMenu)
                {
                    DisplayScreenHeader("Temperature Alarm Menu");
                    Console.WriteLine("\ta) Set Range Type");
                    Console.WriteLine("\tb) Set Minimum/Maximum Threshold Value");
                    Console.WriteLine("\tc) Set Time to Monitor for Light and Temperautre");
                    Console.WriteLine("\td) Set Alarm");
                    Console.WriteLine("\te) Switch to Light Alarm Menu");
                    Console.WriteLine("\tf) Set Alarm for Light and Temperature");
                    Console.WriteLine("\tq) Main Menu");
                    Console.Write("\t\tEnter Choice: ");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            rangeTypeTemperature = TemperatureAlarmDisplayMenuScreenSetRangeType();
                            break;

                        case "b":
                            minMaxThresholdValueTemperature = TemperatureAlarmDisplayMenuScreenSetMinMaxThresholdValue(rangeTypeTemperature, finchRobot);
                            break;

                        case "c":
                            timeToMonitor = LightAlarmDisplayMenuScreenSetTimeToMonitor();
                            break;

                        case "d":
                            TemperatureAlarmDisplayMenuScreenSetAlarm(finchRobot, rangeTypeTemperature, minMaxThresholdValueTemperature, timeToMonitor);
                            break;

                        case "e":
                            menuSwith = "light";
                            break;

                        case "f":
                            LightAndTemperatureAlarmDisplayMenuScreenSetAlarm(finchRobot, sensorsToMonitor, rangeType, rangeTypeTemperature, minMaxThresholdValue, timeToMonitor,minMaxThresholdValueTemperature);
                            break;

                        case "q":
                            quitMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            break;
                    }
                }


            } while (!quitMenu);
        }

        //This is the method for the timer
        static void AlarmLevelFixedLocationForSeconds(int seconds)
        {
            Console.SetCursorPosition(60, 8);
            Console.WriteLine($"Time Elapse: {seconds} seconds");
            Console.SetCursorPosition(0, 10);
        }

        //Method that shows the light reading after the Sensors To Monitor method has been completed.
        static void LightAlarmLightLevelFixedLocation(string sensorsToMonitor, Finch finchRobot)
        {
            int currentLightValue = 0;
            if (finchRobot.connect() == true)
            {
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightValue = finchRobot.getLeftLightSensor();
                        break;
                    case "right":
                        currentLightValue = finchRobot.getRightLightSensor();
                        break;
                    case "both":
                        currentLightValue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
                        break;
                }
                Console.SetCursorPosition(70, 6);
                Console.WriteLine($"The light {sensorsToMonitor} sensor(s) is/are reading {currentLightValue}");
            }
        }

        //Method for the Alarm of both Light and Temperature readings
        static void LightAndTemperatureAlarmDisplayMenuScreenSetAlarm(
            Finch finchRobot,
            string sensorsToMonitor, string rangeType, string rangeTypeTemperature,
            int minMaxThresholdValue, int timeToMonitor,
            double minMaxThresholdValueTemperature)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            bool thresholdExceededTemperature = false;
            int currentLightValue = 0;
            double currentTemperatureValue = 0;
            string userResponse;

            DisplayScreenHeader("Set Alarm for Light and Temperature");

            //Checks if the user inputted important info
            if (sensorsToMonitor == "" || rangeType == "")
            {
                Console.WriteLine("\tPlease return to the Light Alarm menu and complete Set Sensors to Monitor and/or Set Range Type.");
            }

            else if (rangeTypeTemperature == "")
            {
                Console.WriteLine("\tPlease return to the Fire Alarm menu and complete Set Range Type.");
            }
            else if (timeToMonitor == 0)
                Console.WriteLine("\tPlease return the previous menu and complete Set Time to Monitor.");

            else if (!finchRobot.connect())
            {
                Console.WriteLine("\tPlease connect your Finch robot.");
                Console.WriteLine("\tWould you like to be taken to the Connect Finch menu? Yes or No");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                if (userResponse == "yes")
                {
                    DisplayConnectFinchRobot(finchRobot);
                }
            }
            else
            {
                Console.WriteLine($"\tLight Sensors to monitor {sensorsToMonitor}");
                Console.WriteLine($"\tLight Range Type: {rangeType}");
                Console.WriteLine($"\tLight Min/Max thershold value: {minMaxThresholdValue}");
                Console.WriteLine($"\tTemperature Range Type: {rangeTypeTemperature}");
                Console.WriteLine($"\tTemperature Min/Max thershold value: {minMaxThresholdValueTemperature} °F");
                Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
                Console.WriteLine();
                DisplayContinuePrompt();
                Console.WriteLine();
                while (secondsElapsed < timeToMonitor && (!thresholdExceeded || !thresholdExceededTemperature))
                {
                    switch (sensorsToMonitor)
                    {
                        case "left":
                            currentLightValue = finchRobot.getLeftLightSensor();
                            break;
                        case "right":
                            currentLightValue = finchRobot.getRightLightSensor();
                            break;
                        case "both":
                            currentLightValue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
                            break;
                    }

                    currentTemperatureValue = ConvertCelsiusToFahrenheit(finchRobot.getTemperature());

                    switch (rangeType)
                    {
                        case "minimum":
                            if (currentLightValue < minMaxThresholdValue)
                            {
                                thresholdExceeded = true;
                            }
                            break;
                        case "maximum":
                            if (currentLightValue > minMaxThresholdValue)
                            {
                                thresholdExceeded = true;
                            }
                            break;
                    }
                    switch (rangeTypeTemperature)
                    {
                        case "minimum":
                            if (currentTemperatureValue < minMaxThresholdValueTemperature)
                            {
                                thresholdExceededTemperature = true;
                            }
                            break;
                        case "maximum":
                            if (currentTemperatureValue > minMaxThresholdValueTemperature)
                            {
                                thresholdExceededTemperature = true;
                            }
                            break;
                    }
                    finchRobot.wait(1000);
                    //Shows the timer
                    AlarmLevelFixedLocationForSeconds(secondsElapsed);
                    secondsElapsed++;
                }

                //checks for which or if any of the alarms went off before the timer
                if (thresholdExceeded && !thresholdExceededTemperature)
                {
                    Console.WriteLine($"\tThe {rangeType} threshold values of {minMaxThresholdValue} was exceeded by the light sensor(s) value of {currentLightValue}.");
                    Console.WriteLine($"\tThe {rangeTypeTemperature} threshold values of {minMaxThresholdValueTemperature} °F was not exceeded.");
                }
                else if (!thresholdExceeded && thresholdExceededTemperature)
                {
                    Console.WriteLine($"\tThe {rangeTypeTemperature} threshold values of {minMaxThresholdValueTemperature} °F was exceeded by the temperature sensor value of {currentTemperatureValue} °F.");
                    Console.WriteLine($"\tThe {rangeType} threshold values of {minMaxThresholdValue} was not exceeded.");
                }
                else if (thresholdExceeded && thresholdExceededTemperature)
                {
                    Console.WriteLine($"\tThe {rangeType} threshold values of {minMaxThresholdValue} was exceeded by the light sensor(s) value of {currentLightValue}.");
                    Console.WriteLine($"\tThe {rangeTypeTemperature} threshold values of {minMaxThresholdValueTemperature} °F was exceeded by the temperature sensor value of {currentTemperatureValue} °F.");
                }
                else
                {
                    Console.WriteLine($"\tThe {rangeType} threshold values of {minMaxThresholdValue} was not exceeded.");
                    Console.WriteLine($"\tThe {rangeTypeTemperature} threshold values of {minMaxThresholdValueTemperature} °F was not exceeded.");
                }
            }
            DisplayMenuPrompt("Light Alarm");
        }

        //Method for Temperature Set Alarm
        static void TemperatureAlarmDisplayMenuScreenSetAlarm(
            Finch finchRobot,
            string rangeTypeTemperature,
            double minMaxThresholdValueTemperature, int timeToMonitor)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            double currentTemperatureValue = 0;
            string userResponse;

            DisplayScreenHeader("Set Alarm for Temperature");

            //checks to make sure the user has inputted important info and connected their Finch.
            if (rangeTypeTemperature == "")
            {
                Console.WriteLine("\tPlease return to the Fire Alarm menu and complete Set Range Type.");
            }
            else if (timeToMonitor == 0)
            {
                Console.WriteLine("\tPlease return the previous menu and complete Set Time to Monitor.");
            }

            else if (!finchRobot.connect())
            {
                Console.WriteLine("\tPlease connect your Finch robot.");
                Console.WriteLine("\tWould you like to be taken to the Connect Finch menu? Yes or No");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                if (userResponse == "yes")
                {
                    DisplayConnectFinchRobot(finchRobot);
                }
            }
            else
            {
                Console.WriteLine($"\tRange Type: {rangeTypeTemperature}");
                Console.WriteLine($"\tMin/Max thershold value: {minMaxThresholdValueTemperature}");
                Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
                Console.WriteLine();
                DisplayContinuePrompt();
                Console.WriteLine();
                while (secondsElapsed < timeToMonitor && !thresholdExceeded)
                {

                    currentTemperatureValue = ConvertCelsiusToFahrenheit(finchRobot.getTemperature());
                    switch (rangeTypeTemperature)
                    {
                        case "minimum":
                            if (currentTemperatureValue < minMaxThresholdValueTemperature)
                            {
                                thresholdExceeded = true;
                            }
                            break;
                        case "maximum":
                            if (currentTemperatureValue > minMaxThresholdValueTemperature)
                            {
                                thresholdExceeded = true;
                            }
                            break;
                    }
                    finchRobot.wait(1000);
                    //Shows the seconds as they occur
                    AlarmLevelFixedLocationForSeconds(secondsElapsed);
                    secondsElapsed++;

                }

                if (thresholdExceeded)
                {
                    Console.WriteLine($"\tThe {rangeTypeTemperature} threshold values of {minMaxThresholdValueTemperature} °F was exceeded by the temperature sensor value of {currentTemperatureValue} °F.");
                }
                else
                {
                    Console.WriteLine($"\tThe {rangeTypeTemperature} threshold values of {minMaxThresholdValueTemperature} °F was not exceeded.");
                }
            }
            DisplayMenuPrompt("Temperature Alarm");
        }

        
        //Method for setting the value for the max/min value.
        static double TemperatureAlarmDisplayMenuScreenSetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            double minMaxThresholdValue=0;
            string userResponse;
            
             DisplayScreenHeader("Minimum/Maximum Thershold Value for Temperature");
            if (rangeType == "")
            {
                Console.WriteLine("\tPlease return to the Temperature Alarm menu and complete Set Range Type.");
            }
            else if (!finchRobot.connect())
            {
                Console.WriteLine("\tPlease connect your Finch robot.");
                Console.WriteLine("\tWould you like to be taken to the Connect Finch menu? Yes or No");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                if (userResponse == "yes")
                {
                    DisplayConnectFinchRobot(finchRobot);
                }
            }
            else
            {
                //currentTemperatureValue = ConvertCelsiusToFahrenheit(finchRobot.getTemperature());
                Console.WriteLine($"\tThe temperature sensor value: {ConvertCelsiusToFahrenheit(finchRobot.getTemperature())} °F");

                Console.WriteLine();

                Console.Write($"\tEnter the {rangeType} temperature sensor value: ");
                minMaxThresholdValue = DoubleNumberValidation(Console.ReadLine());
                DisplayContinuePrompt();
                Console.WriteLine();
                Console.WriteLine($"\tThe {rangeType} thershold value is {minMaxThresholdValue} °F.");
            }
                DisplayMenuPrompt("Temperature Alarm");
            
            return minMaxThresholdValue;
        }

        //Method for determining which range to use for the temperature
        static string TemperatureAlarmDisplayMenuScreenSetRangeType()
        {
            string rangeType;

            DisplayScreenHeader("Set Range Type for Temperature");
            Console.Write("\tRange Type [minimum, maximum]: ");
            //Validates user input for max or min.
            rangeType = SetRangeTypeValiadation(Console.ReadLine().ToLower());

            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine($"\tThe temperature range has been set to {rangeType}.");
            DisplayMenuPrompt("Temperature Alarm");
            return rangeType;
        }

       //This is the method for Set Alarm for the light measured
        static void LightAlarmDisplayMenuScreenSetAlarm(
            Finch finchRobot, 
            string sensorsToMonitor, string rangeType, 
            int minMaxThresholdValue, int timeToMonitor)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightValue = 0;
            string userResponse;

            DisplayScreenHeader("Set Alarm for Ambient Light");

            //Checks to make sure everything important variables are set
            if (sensorsToMonitor == "" || rangeType == "")
            {
                Console.WriteLine("\tPlease return to the Light Alarm menu and complete Set Sensors to Monitor and/or Set Range Type.");
            }
            else if (timeToMonitor == 0)
                Console.WriteLine("\tPlease return the previous menu and complete Set Time to Monitor.");

            else if (!finchRobot.connect())
            {
                Console.WriteLine("\tPlease connect your Finch robot.");
                Console.WriteLine("\tWould you like to be taken to the Connect Finch menu? Yes or No");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                if (userResponse == "yes")
                {
                    DisplayConnectFinchRobot(finchRobot);
                }
            }
            else
            {
                Console.WriteLine($"\tSensors to monitor {sensorsToMonitor}");
                Console.WriteLine($"\tRange Type: {rangeType}");
                Console.WriteLine($"\tMin/Max thershold value: {minMaxThresholdValue}");
                Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
                Console.WriteLine();
                DisplayContinuePrompt();
                Console.WriteLine();
                while (secondsElapsed < timeToMonitor && !thresholdExceeded)
                {
                    //turns on certain sensors depending on user input for which sensor
                    switch (sensorsToMonitor)
                    {
                        case "left":
                            currentLightValue = finchRobot.getLeftLightSensor();
                            break;
                        case "right":
                            currentLightValue = finchRobot.getRightLightSensor();
                            break;
                        case "both":
                            currentLightValue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
                            break;
                    }
                    //checks to make sure if the minimum/maximum is passed.
                    switch (rangeType)
                    {
                        case "minimum":
                            if (currentLightValue < minMaxThresholdValue)
                            {
                                thresholdExceeded = true;
                            }
                            break;
                        case "maximum":
                            if (currentLightValue > minMaxThresholdValue)
                            {
                                thresholdExceeded = true;
                            }
                            break;
                    }
                    finchRobot.wait(1000);
                    //Shows the timer of the loop
                    AlarmLevelFixedLocationForSeconds(secondsElapsed);
                    secondsElapsed++;
                }

                if (thresholdExceeded)
                {
                    Console.WriteLine($"\tThe {rangeType} threshold values of {minMaxThresholdValue} was exceeded by the light sensor(s) value of {currentLightValue}.");
                }
                else
                {
                    Console.WriteLine($"\tThe {rangeType} threshold values of {minMaxThresholdValue} was not exceeded.");
                }
            }
            DisplayMenuPrompt("Light Alarm");
        }

        //Method for setting the time to run the alarms
        static int LightAlarmDisplayMenuScreenSetTimeToMonitor()
        {
            int timeToMonitor;
            DisplayScreenHeader("Time to Monitor");
           
            Console.WriteLine();

            Console.Write($"\tEnter the time to monitor in seconds: ");
            timeToMonitor = IntNumberValidationAboveZero(Console.ReadLine());
            Console.WriteLine();
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine($"\tThe monitor time is {timeToMonitor} seconds");

            DisplayMenuPrompt("Light Alarm");
            return timeToMonitor;
        }


        /// <summary>
        /// Method for the user to set the minimum or maximum value
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static int LightAlarmDisplayMenuScreenSetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue = 0;
            string userResponse;
            DisplayScreenHeader("Minimum/Maximum Thershold Value");

            //Checks to make sure the user input a range type and have the Finch connected.
            if (rangeType == "")
            {
                Console.WriteLine("\tPlease return to the Light Alarm menu and complet Set Range Type.");
            }

            else if (!finchRobot.connect())
            {
                Console.WriteLine("\tPlease connect your Finch robot.");
                Console.WriteLine("\tWould you like to be taken to the Connect Finch menu? Yes or No");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                if (userResponse == "yes")
                {
                    DisplayConnectFinchRobot(finchRobot);
                }
            }
            else
            {
                Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
                Console.WriteLine($"\tRight light sensor ambient value: {finchRobot.getRightLightSensor()}");
                Console.WriteLine();

                Console.Write($"\tEnter the {rangeType} light sensor value: ");
                minMaxThresholdValue = IntNumberValidationBetweenZeroandTwoHundredFiftyFive(Console.ReadLine());
                DisplayContinuePrompt();
                Console.WriteLine();
                Console.WriteLine($"\tThe {rangeType} thershold value is {minMaxThresholdValue}");
            }

            DisplayMenuPrompt("Light Alarm");
            return minMaxThresholdValue;
        }

        //Method for setting the range type
        static string LightAlarmDisplayMenuScreenSetRangeType()
        {
            string rangeType;

            DisplayScreenHeader("Set Range Type for Ambient Light");            
            Console.Write("\tRange Type [minimum, maximum]: ");
            //validates the user input maximum or minimum or max or min,
            rangeType = SetRangeTypeValiadation(Console.ReadLine().ToLower());

            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine($"\tThe range has been set to {rangeType}.");
            DisplayMenuPrompt("Light Alarm");
            return rangeType;
        }

        //Method to decide which light sensors to user.
        static string LightAlarmDisplayMenuScreenSetSensorsToMonitor()
        {
            string sensorsToMonitor;

            DisplayScreenHeader("Sensors to Monitor for Ambient Light");
            Console.Write("\tSensors to monitor [left, right, both]: ");
            sensorsToMonitor = Console.ReadLine().ToLower();
            //Validates the user entering left, right, or both
            sensorsToMonitor=SetSensorsToMonitorValiadation(sensorsToMonitor);
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine($"\tThe {sensorsToMonitor} sensor(s) was chosen.");
            DisplayMenuPrompt("Light Alarm");
            return sensorsToMonitor;
        }

        //Validation method for which light sensor to use
        static string SetSensorsToMonitorValiadation(string userResponse)
        {
            while (userResponse != "left" && userResponse != "right" && userResponse != "both")
            {
                Console.WriteLine("\tPlease enter 'left', 'right' or 'both'");
                userResponse = Console.ReadLine().ToLower();
                Console.WriteLine();
            }
            return userResponse;
        }

        //Validation method for range type.
        static string SetRangeTypeValiadation(string userResponse)
        {
            while (userResponse != "min" && userResponse != "minimum" && userResponse != "max" && userResponse != "maximum")
            {
                Console.WriteLine("\tPlease enter 'minimum' or 'maximum'");
                userResponse = Console.ReadLine().ToLower();
                Console.WriteLine();
            }
            if (userResponse=="min")
            {
                userResponse = "minimum";
            }
            else if (userResponse=="max")
            {
                userResponse = "maximum";
            }

            return userResponse;
        }

        //Validation for ambient light recorded between 0-255, the Finch's range
        static int IntNumberValidationBetweenZeroandTwoHundredFiftyFive(string numberResponse)
        {
            int numberOfDataPoints;
            while (!Int32.TryParse(numberResponse, out numberOfDataPoints) || numberOfDataPoints < 0 || numberOfDataPoints>255)
            {
                Console.WriteLine("\tPlease enter an integer that is between 0 and 255.");
                Console.Write("\tNumber: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return numberOfDataPoints;

        }

        #endregion

        #region User Programming

        /// <summary>
        /// This is the main menu for User Programming
        /// </summary>
        /// <param name="finchRobot"></param>
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = false;
            bool quitMenu = false;
            string menuChoice;
            //Tuple for paramates
            (int motorSpeed, int ledBrightness, int noiseLoudness, double waitSeconds,List<Command> commands) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.noiseLoudness = 0;
            commandParameters.waitSeconds = 0;
            commandParameters.commands = new List<Command>();

            do
            {
                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplayCommandParameters(commandParameters.commands);
                        break;

                    case "b":
                        UserProgrammingDisplayAddCommands(commandParameters.commands);
                        break;

                    case "c":
                        UserProgrammingDisplayViewCommands(commandParameters.commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteCommands(commandParameters,finchRobot);
                        break;
                                            
                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

        }

        /// <summary>
        /// This method allows for the input of the parameters.
        /// I needed to add the list to it so I could set it to the list in the tuple.
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        static (int motorSpeed, int ledBrightness, int noiseLoudness, double waitSeconds, List<Command> commands) UserProgrammingDisplayCommandParameters(List<Command> commands)
        {
            DisplayScreenHeader("Command Parameters");

            (int motorSpeed, int ledBrightness, int noiseLoudness, double waitSeconds, List<Command> commands) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.noiseLoudness = 0;
            commandParameters.waitSeconds = 0;
            commandParameters.commands = commands;

            (string noteInput, int noteFreq) noteParameters;
            noteParameters.noteInput  = "";
            noteParameters.noteFreq = 0;

            Console.WriteLine("\tEnter the motor speed: [1-255]");
            commandParameters.motorSpeed = IntNumberValidationBetweenOneandTwoHundredFiftyFive(Console.ReadLine());
            Console.WriteLine("\tEnter the LED brightness: [1-255]");
            commandParameters.ledBrightness = IntNumberValidationBetweenOneandTwoHundredFiftyFive(Console.ReadLine());
            Console.WriteLine("\tEnter one of the following notes.");

            foreach(string noteName in Enum.GetNames(typeof(Note)))
            {
                Console.Write($" {noteName} ");
            }
            Console.WriteLine();
            noteParameters = NoteValitations(Console.ReadLine().ToUpper());
            commandParameters.noiseLoudness = noteParameters.noteFreq;
            Console.WriteLine("\tEnter the amount of seconds for the command duration.");
            Console.WriteLine("\tIt is recommended that wait duration do not exceed 10 seconds");
            commandParameters.waitSeconds = DoubleNumberValidationAboveZero(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"\tThe motor speed was set to {commandParameters.motorSpeed}.");
            Console.WriteLine($"\tThe LED brightness was set to {commandParameters.ledBrightness}.");
            Console.WriteLine($"\tThe note was set to {noteParameters.noteInput}, at a frequency of {commandParameters.noiseLoudness}.");
            Console.WriteLine($"\tThe wait duration was set to {commandParameters.waitSeconds} seconds");
            DisplayMenuPrompt("User Programming");


            return commandParameters;
        }

        /// <summary>
        /// This is my validation for notes.
        /// I tried doing a switch case but it wasn't working.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static (string noteInput, int noteFreq) NoteValitations(string v)
        {
            (string noteInput, int noteFreq) noteParameters;
            noteParameters.noteInput = v;
            noteParameters.noteFreq = 0;
            bool trueNote = false;
            
            while (!trueNote)
            {
                if (v == "C")
                {
                    noteParameters.noteFreq = 523;
                    trueNote = true;
                }
                else if (v == "D")
                {
                    noteParameters.noteFreq = 587;
                    trueNote = true;
                }
                else if (v == "E")
                {
                    noteParameters.noteFreq = 659;
                    trueNote = true;
                }
                else if (v == "F")
                {
                    noteParameters.noteFreq = 698;
                    trueNote = true;
                }
                else if (v == "G")
                {
                    noteParameters.noteFreq = 784;
                    trueNote = true;
                }
                else if (v == "A")
                {
                    noteParameters.noteFreq = 880;
                    trueNote = true;
                }
                else if (v == "B")
                {
                    noteParameters.noteFreq = 988;
                    trueNote = true;
                }
                else
                {
                    Console.WriteLine("\tPlease enter in a note from above.");
                    v = Console.ReadLine().ToUpper();
                }                      
              
            }
            return noteParameters;

        }

        //I copied and changed the lowest value of a previous method.
        static int IntNumberValidationBetweenOneandTwoHundredFiftyFive(string numberResponse)
        {
            int numberOfDataPoints;
            while (!Int32.TryParse(numberResponse, out numberOfDataPoints) || numberOfDataPoints < 1 || numberOfDataPoints > 255)
            {
                Console.WriteLine("\tPlease enter an integer that is between 1 and 255.");
                Console.Write("\tNumber: ");
                numberResponse = Console.ReadLine();
                Console.WriteLine();
            }
            return numberOfDataPoints;

        }

        /// <summary>
        /// This method allows the input of commands into a list.
        /// </summary>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayAddCommands(List<Command> commands)
        {

            commands.Clear();
            Command command = Command.NONE;

            DisplayScreenHeader("Add Finch Commands");

            //list commands
            int commandCount = 1;
            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.Write("\t-");
            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                Console.Write($"- {ti.ToTitleCase(commandName.ToLower())}");
                if (commandCount % 5 == 0)
                    Console.Write("-\n\t-");
                commandCount++;               
            }
            Console.WriteLine();
            while(command != Command.DONE)
            {
                Console.Write("Enter Command: ");
                if (Enum.TryParse(ShortHandCommmandList(Console.ReadLine().ToUpper()), out command))
                {
                    commands.Add(command);
                }
                else
                    Console.WriteLine("\t Please enter a command from the list above.");
            }
            DisplayScreenHeader("View Commands");
            foreach (Command commandInput in commands)
            {
                Console.WriteLine($"\t{commandInput}");
            }

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// This method is for short hand notations of commands.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static string ShortHandCommmandList(string v)
        {
            if (v == "FOR" || v == "FORWARD")
                v = "MOVEFORWARD";
            else if (v == "BACK" || v == "BACKWARD")
                v = "MOVEBACKWARD";
            else if (v == "STOP")
                v = "STOPMOTORS";
            else if (v == "RIGHT")
                v = "TURNRIGHT";
            else if (v == "LEFT")
                v = "TURNLEFT";
            else if (v == "TEMP" || v == "TEMPERATURE")
                v = "GETTEMPERATURE";
            else if (v == "LIGHT" || v == "READING")
                v = "GETLIGHTREADING";
            else if (v == "ON")
                v = "ALLON";
            else if (v == "OFF")
                v = "ALLOFF";
            return v;
        }

        /// <summary>
        /// This method shows what is in the list for commands.
        /// </summary>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayViewCommands(List<Command> commands)
        {
            DisplayScreenHeader("View Commands");

            if (commands.Count==0)
            {
                Console.WriteLine("\tPlease complete Add Commands");
            }
            else
            {
                foreach (Command commandInput in commands)
                {
                    Console.WriteLine($"\t{commandInput}");
                }                
            }
            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// This method is for executing the commands.
        /// </summary>
        /// <param name="commandParameters"></param>
        /// <param name="finchRobot"></param>
       static void UserProgrammingDisplayExecuteCommands(
           (int motorSpeed, int ledBrightness, int noiseLoudness, double waitSeconds, List<Command> commands) commandParameters,
           Finch finchRobot)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int noiseLoudness = commandParameters.noiseLoudness;
            int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
            List <Command> commands = commandParameters.commands;
            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute Finch Commands");

            //This validates that the user added commands.
            if ( commands.Count == 0)
            {
                Console.WriteLine("\tPlease complete Add Commands");
            }

            //Validates that the Finch is connected.
            else if (!finchRobot.connect())
            {
                string userResponse;
                Console.WriteLine("\tPlease connect your Finch robot.");
                Console.WriteLine("\tWould you like to be taken to the Connect Finch menu? Yes or No");
                userResponse = Console.ReadLine().ToLower();
                YesOrNoValidation(userResponse);
                if (userResponse == "yes")
                {
                    DisplayConnectFinchRobot(finchRobot);
                }
            }
            else
            {
                Console.WriteLine("\tThe Finch robot is ready to execute the list of commands.");
                DisplayContinuePrompt();

                foreach(Command command in commands)
                {
                    switch(command)
                    {
                        case Command.NONE:
                            commandFeedback = Command.NONE.ToString();                           
                            break;
                        case Command.MOVEFORWARD:
                            finchRobot.setMotors(motorSpeed, motorSpeed);
                            commandFeedback = Command.MOVEFORWARD.ToString();                            
                            break;
                        case Command.MOVEBACKWARD:
                            finchRobot.setMotors(-motorSpeed, -motorSpeed);
                            commandFeedback = Command.MOVEBACKWARD.ToString();                            
                            break;
                        case Command.STOPMOTORS:
                            finchRobot.setMotors(0,0);
                            commandFeedback = Command.MOVEBACKWARD.ToString();
                            break;
                        case Command.WAIT:
                            finchRobot.wait(waitMilliSeconds);
                            commandFeedback = Command.WAIT.ToString();
                            break;
                        case Command.TURNLEFT:
                            finchRobot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                            commandFeedback = Command.TURNLEFT.ToString();
                            break;
                        case Command.TURNRIGHT:
                            finchRobot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                            commandFeedback = Command.TURNRIGHT.ToString();
                            break;
                        case Command.LEDON:
                            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                            commandFeedback = Command.LEDON.ToString();
                            break;
                        case Command.LEDOFF:
                            finchRobot.setLED(0,0,0);
                            commandFeedback = Command.LEDOFF.ToString();
                            break;
                        case Command.MAKENOISE:
                            finchRobot.noteOn(noiseLoudness);
                            commandFeedback = Command.MAKENOISE.ToString();
                            break;
                        case Command.STOPNOISE:
                            finchRobot.noteOff();
                            commandFeedback = Command.STOPNOISE.ToString();
                            break;
                        case Command.ALLOFF:
                            finchRobot.noteOff();
                            finchRobot.setLED(0, 0, 0);
                            finchRobot.setMotors(0, 0);
                            commandFeedback = Command.ALLOFF.ToString();
                            break;
                        case Command.ALLON:
                            finchRobot.setMotors(motorSpeed, motorSpeed);
                            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                            finchRobot.noteOn(noiseLoudness);
                            commandFeedback = Command.ALLON.ToString();
                            break;
                        case Command.GETTEMPERATURE:
                            commandFeedback= $"Temperature: {ConvertCelsiusToFahrenheit(finchRobot.getTemperature()).ToString("n")}°F\n";
                            break;
                        case Command.GETLIGHTREADING:
                            commandFeedback = $"Light Reading: {(finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2}\n";
                            break;
                        case Command.DANCE:
                            TalentShowDisplayDance(finchRobot);
                            commandFeedback = Command.DANCE.ToString();
                            break;
                        case Command.DONE:
                            finchRobot.noteOff();
                            finchRobot.setLED(0, 0, 0);
                            finchRobot.setMotors(0, 0);
                            commandFeedback = Command.DONE.ToString();
                            break;
                    }
                    Console.WriteLine($"\t{commandFeedback}");
                }
            }

            DisplayMenuPrompt("User Programming");
        }
        #endregion

    }
}
