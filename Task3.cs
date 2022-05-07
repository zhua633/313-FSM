using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace ASSIGNMENT2
{
    class SynchronousFST
    {
        public static List<string> stringList = new List<string>(); //make a list of strings which will log activity
        string timeStamp = DateTime.Now.ToLongTimeString(); //declare timeStamp variable which logs current time

        public void AddToString(string stringLine)
        {
            timeStamp = DateTime.Now.ToLongTimeString(); //take current time stamp
            stringList.Add(timeStamp + " "+ stringLine);//adding to stringList
        }

        //setting actions
        enum Actions
        {
            do_nothing,
            W,
            X_and_Y,
            X_and_Z
        }

        //setting variables 
        private int i_state = 0;
        private int i_action = (int)Actions.do_nothing;
        private int i_state2 = 1;
        private int i_action2 = (int)Actions.do_nothing;
        public string task_input = "default";
        public string checker = "default";

        //two dimensional array named i_FST (implemented FST)
        public object[,] i_FST = new object[9, 2]
        {               //S0                    //S1                       //S2
            /*a*/ { 1 , Actions.X_and_Y },{ 0 , Actions.W },         { 0 , Actions.W },
            /*b*/ { 0 , 0 }              ,{ 2 , Actions.X_and_Z },   { 2 , Actions.do_nothing },
            /*c*/ { 0 , 0 }              ,{ 1 , Actions.do_nothing },{ 1 , Actions.X_and_Y },
        };

        //two dimensional array named i_FST (implemented FST)
        public object[,] i_FST2 = new object[6, 2]
        {               //SA                    //SB                 
            /*a*/ { 1 , 0 }              ,{ 0 , 0 },
            /*b*/ { 0 , 0 }              ,{ 1 , 0 }, 
            /*c*/ { 0 , 0 }              ,{ 1 , 0 }, //no transition
        };

        //getter and setter for next state and actions
        public int GetNextState(){return i_state;}
        public void SetNextState(int state){ i_state = state;}
        public int GetActions(){return i_action;}
        public void SetActions(int action){i_action = action;}

        //getter and setter for next state and actions for the second finiste state table 
        public int GetNextState2() { return i_state2;}
        public void SetNextState2(int state){i_state2 = state;}
        public int GetActions2(){return i_action2;}
        public void SetActions2(int action){i_action2 = action;}

        //Define methodos action J, K, L
        private void ActionJ()
        {
            Console.WriteLine("Action J");
            AddToString("Action J"); //writing to list to be written on file
        }
        private void ActionK()
        {
            Console.WriteLine("Action K");
            AddToString("Action K");
        }
        private void ActionL()
        {
            Console.WriteLine("Action L");
            AddToString("Action L");
            Console.WriteLine("Please enter a,b,c. To exit the programme, enter q."); //ensuring printing instructions after the actions have completed
        }

        //constructors
        public SynchronousFST()
        {
            Console.WriteLine("Synchronous Finite State Table Constructor Called");
        }

        public void TestTask2()
        {
            AddToString("Application Task 2 Started: Machine is in state S0");
            Console.WriteLine("Application Task 2 Started: Machine is in state S0"); 
            bool programmeStatus = true;

            //while the programme is running(has not been exited).
            while (programmeStatus == true)
            {
                //print instructions for input only in default state or after task2 and task3 has been completed for one round.
                if (checker == task_input)
                {
                    Console.WriteLine("Please enter a,b,c. To exit the programme, enter q.");
                }
                task_input = Console.ReadLine();//reads user input
                checker = "triggered";//change the state fo the checker from default to triggered

                //operate actions and state changes according to user input
                switch (task_input)
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
        }

        public void TestTask3()
        {
            AddToString("Application Task 3 Started: Machine is in state SB");
            Console.WriteLine("Application Task 3 Started: Machine is in state S0");
            bool programmeStatus = true;

            while (programmeStatus == true)
            {
                if (checker != task_input)
                {
                    //if the current state is SAS1, and the task input is either a,b or c.
                    if (i_state == 1 && i_state2 == 1 && (task_input == "a" || task_input == "b" || task_input == "c"))
                    {
                        SetNextState2((int)i_FST2[2, 0]);
                        SetActions2((int)i_FST2[2, 1]);//switch to SB
                        Console.WriteLine("Now in State SA");
                        AddToString("Now in State SA");

                        //create thread class  instance action J, K and L
                        System.Threading.Thread actionj = new System.Threading.Thread(
                            new System.Threading.ThreadStart(ActionJ));

                        System.Threading.Thread actionk = new System.Threading.Thread(
                            new System.Threading.ThreadStart(ActionK));

                        System.Threading.Thread actionl = new System.Threading.Thread(
                            new System.Threading.ThreadStart(ActionL));

                        //run threads
                        actionj.Start();
                        actionk.Start();
                        actionl.Start();
                    }
                    else switch (task_input)
                        {
                            case "a":
                                if (i_state2 == 0) //means current state is SA
                                {
                                    SetNextState2((int)i_FST2[0, 0]);
                                    SetActions2((int)i_FST2[0, 1]);//switch to SB
                                    Console.WriteLine("Now in State SB");
                                    AddToString("Now in State SB");
                                }
                                else
                                {
                                    Console.WriteLine("Now in state SB");
                                    AddToString("Now in State SB");
                                }
                                break;
                            case "b":
                                break;
                            case "c":
                                break;
                            case "q":
                                programmeStatus = false;//exit task 3
                                break;

                            default:
                                Console.WriteLine("Task 3 Error: invalid input. Please enter a,b,c. To exit the programme, enter q.");
                                break;
                        }
                    checker = task_input; //set checker back to default(same as  task_input)
                }
            }
        }
    }


    class MainClass : SynchronousFST
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter which Task you would like to test (2 or 3):");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "2":
                    var task2table = new ImplementedFST();
                    _ = task2table.TestTask2();
                    break;

                case "3":
                    var figure2 = new SynchronousFST();

                    //create thread class  instances task2operate and task3operate
                    System.Threading.Thread task2operate = new System.Threading.Thread(
                        new System.Threading.ThreadStart(figure2.TestTask2));

                    System.Threading.Thread task3operate = new System.Threading.Thread(
                        new System.Threading.ThreadStart(figure2.TestTask3));

                    //run threads
                    task2operate.Start();
                    task3operate.Start();


                    bool fileWriteStatus = true;

                    while (fileWriteStatus)
                    {
                        //Loop until making sure both threads have ended, then write to file.
                        if (task2operate.IsAlive == false && task3operate.IsAlive == false)
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
                    break;

                default:
                    Console.WriteLine("Please run programme again and enter '2' or '3' when prompted.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

