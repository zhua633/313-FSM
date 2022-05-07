using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASSIGNMENT2
{
    class ImplementedFST
    {
        public static List<string> stringList = new List<string>(); //make a list of strings which will log activity
        string timeStamp = DateTime.Now.ToLongTimeString(); //declare timeStamp variable which logs current time

        public void AddToString(string stringLine)
        {
            timeStamp = DateTime.Now.ToLongTimeString(); //take current time stamp
            stringList.Add(timeStamp + " " + stringLine);//adding to stringList
        }

        //setting variables
        enum Actions
        {
            do_nothing,
            W,
            X_and_Y,
            X_and_Z
        }

        private int i_state = 0;
        private int i_action = (int)Actions.do_nothing;

        //two dimensional array named i_FST (implemented FST)
        public object[,] i_FST = new object[9, 2]
        {               //S0                    //S1                       //S2
            /*a*/ { 1 , Actions.X_and_Y },{ 0 , Actions.W },         { 0 , Actions.W },
            /*b*/ { 0 , 0 }              ,{ 2 , Actions.X_and_Z },   { 2 , Actions.do_nothing },
            /*c*/ { 0 , 0 }              ,{ 1 , Actions.do_nothing },{ 1 , Actions.X_and_Y },
        };

        //getter and setter for next state
        public int GetNextState()
        {
            return i_state;
        }

        public void SetNextState(int state)
        {
            i_state = state;
        }

        //getter and setter for actions
        public int GetActions()
        {
            return i_action;
        }

        public void SetActions(int action)
        {
            i_action = action;
        }

        //constructors
        public ImplementedFST()
        {
            Console.WriteLine("Implemented Finite State Table Constructor Called");
        }

        //TESTING  TASK 2
        public async Task TestTask2()
        {
            bool programmeStatus = true;

            //while the programme is running(has not been exited).
            while (programmeStatus == true)
            {
                Console.WriteLine("Please enter a,b,c. To exit the programme, enter q.");
                string task_2_input = Console.ReadLine();//reads user input
                //operate actions and state changes according to user input
                switch (task_2_input)
                {
                    case "a":
                        AddToString("Trigger event 'a' occured");
                        if (i_state == 0) //means current state is S0
                        {
                            SetNextState((int)i_FST[0, 0]);
                            SetActions((int)i_FST[0, 1]); //switches to S1
                            Console.WriteLine("Now in State S1");
                            Console.WriteLine("Action X");
                            Console.WriteLine("Action Y");
                            AddToString("Now in State S1");
                            AddToString("Action X");
                            AddToString("Action Y");
                        }
                        else if (i_state == 1) //means current state is S1
                        {
                            SetNextState((int)i_FST[1, 0]);
                            SetActions((int)i_FST[1, 1]); //switches to S0
                            Console.WriteLine("Now in State S0");
                            Console.WriteLine("Action W");
                            AddToString("Now in State S0");
                            AddToString("Action W");
                        }
                        else //means current state is S2
                        {
                            SetNextState((int)i_FST[2, 0]);
                            SetActions((int)i_FST[2, 1]);//switches to S0
                            Console.WriteLine("Now in State S0");
                            Console.WriteLine("Action W");
                            AddToString("Now in State S0");
                            AddToString("Action W");
                        }
                        break;

                    case "b":
                        AddToString("Trigger event 'b' occured");
                        if (i_state == 0) //means current state is S0
                        {
                            SetNextState((int)i_FST[3, 0]);
                            SetActions((int)i_FST[3, 1]);
                        }
                        else if (i_state == 1) //means current state is S1
                        {
                            SetNextState((int)i_FST[4, 0]);
                            SetActions((int)i_FST[4, 1]);//change state to S2
                            Console.WriteLine("Now in State S2");
                            Console.WriteLine("Action X");
                            Console.WriteLine("Action Z");
                            AddToString("Now in State S2");
                            AddToString("Action X");
                            AddToString("Action Z");
                        }
                        else //means current state is S2
                        {
                            SetNextState((int)i_FST[5, 0]);
                            SetActions((int)i_FST[5, 1]);
                        }
                        break;


                    case "c":
                        AddToString("Trigger event 'c' occured");
                        if (i_state == 0) //means current state is S0
                        {
                            SetNextState((int)i_FST[6, 0]);
                            SetActions((int)i_FST[6, 1]);
                        }
                        else if (i_state == 1) //means current state is S1
                        {
                            SetNextState((int)i_FST[7, 0]);
                            SetActions((int)i_FST[7, 1]);
                        }
                        else //means current state is S2
                        {
                            SetNextState((int)i_FST[8, 0]);
                            SetActions((int)i_FST[8, 1]);//change to S1
                            Console.WriteLine("Now in State S1");
                            Console.WriteLine("Action X");
                            Console.WriteLine("Action Y");
                            AddToString("Now in State S1");
                            AddToString("Action X");
                            AddToString("Action Y");
                        }
                        break;

                    case "q":
                        AddToString("Trigger event 'q' occured");
                        AddToString("Quit Application");
                        programmeStatus = false; //exit task 2
                        break;

                    default:
                        Console.WriteLine("Task 2 Error: invalid input. Please enter a, b or c. To exit the programme, enter q.");
                        break;
                }
            }
            bool fileWriteStatus = true;

            while (fileWriteStatus)
            {
                    Console.WriteLine("Programme has quit. Please enter a valid file name to save the logged data: ");
                    string fileName = Console.ReadLine();
                    string fileDirectory = fileName;
                    string fileExtension = fileName;
                    int fileExtensionLength = 0;
                    int fileLength = 0;

                    //check if user input has a correct directory path  (use "\\" for windows, use "/" for mac)
                    int backSlash = fileName.LastIndexOf("\\");
                    if (backSlash > 0)
                    {
                        fileDirectory = fileName.Substring(0, backSlash); //removes everything after the last backslash
                        fileLength = fileName.Length;
                        fileExtension = fileName.Substring((backSlash + 1), (fileLength - backSlash - 1)); //removes everything before the last backslash
                        fileExtensionLength = fileExtension.Length;
                    }

                    if (Directory.Exists(fileDirectory) && fileName.EndsWith(".txt") && fileExtensionLength > 4) //means a valid file name was inputted by user***************************
                    {
                        // Write the string array to a new file named "WriteLines.txt".
                        using (StreamWriter outputFile = new StreamWriter(fileName))
                        {
                            foreach (string line in stringList)
                                outputFile.WriteLine(line);
                        }
                        Console.WriteLine("Successfully written logged activity to selected file.");
                        Console.ReadKey();//end the console application once the user pressed any keys
                        fileWriteStatus = false;
                    }

                    else //means an invalid file name was inputted by user
                    {
                        Console.WriteLine("Error: invalid input.");
                    }
                }
            }
        }
    }


