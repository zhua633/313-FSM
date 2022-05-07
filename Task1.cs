using System;

namespace ASSIGNMENT2
{
    class FiniteStateTable
    {
        //setting variables
        private int _state = 0;
        private string _action = " ";

        //two dimensional array named FST
        private object[,] FST = new object[3, 3];

        //struct named cell_FST
        private struct cell_FST
        {
            int next_state;
            //void (*action)(void);
            string action;
        }

        //getter and setter for next state
        public int GetNextState()
        {
            return _state;
        }

        public void SetNextState(int state)
        {
            _state = state;
        }

        //getter and setter for actions
        public string GetActions()
        {
            return _action;
        }

        public void SetActions(string action)
        {
            _action = action;
        }

        //constructors
        public FiniteStateTable()
        {
            Console.WriteLine("Finite State Table Constructor Called");
        }

    }
}

