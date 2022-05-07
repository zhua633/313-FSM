# MECHENG313-FSM
Simple FSM design with C# and .NET Core

**Task One**<br />
Defines the class FiniteStateTable. Within this basic class there is a two-dimensional array named FST, and a struct which groups a next state variable (_state) and the associated action variable (_action).  There are also setters and getters for these two variables that make up any cell within the finite state table FST. Lastly, a constructor is explicitly defined with no functionality. In this task, there is no implementation of an actual finite-state machine, but rather just definitions/declarations for the respective methods and variables.


**Task Two**<br />
Now, the FiniteStateTable class defined in Task 1 is developed to implement an actual finite-state machine as represented in Figure 1 of the Assignment 2 handout. This means the two-dimensional array FST will contains 9 rows and 2 columns to accomodate the associated next state and action variables per user input(0 corresponds to state S0, 1 corresponds to state S1, and 2 corresponds to state S2). The actions are declared as enumeration types for better readability of code, listed in the following order: do_nothing, W, X_and_Y, and X_and_Z. This task uses a switch case to recognise and respond to user input. Finally, the activity of both the finite state machine and the user is logged to a text file (specified by the user) upon the termination of the task. 

**Task Three**<br />
Implements two concurrent, dependent and synchronous finite-state machines as depicted by Figure 1 and Figure 2 of the Assignment 2 handout. So in addition to the FSM defined in Task 2, another FSM (called i_FST2) is created with 6 rows and 2 columns to store the next state and action variables. Both finite-state machines are ensured to be operating concurrently using multithreading. Multithreading is also utilised to execute actions J, K and L. Similar to Task 2, both the user and machine activity is logged and written to a text file upon the termination of this task. 
