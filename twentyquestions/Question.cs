using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twentyquestions
{
    class Question : IComparable<Question>
    {
        public string question;
        public int ID;
        public bool finalAnswer;
        public Question(string q, int id, bool finalanswer)
        {
            question = q;
            ID = id;
            finalAnswer = finalanswer;
        }

        public int CompareTo(Question other)
        {
            if(other.ID == ID)
            {
                return 0;
            }
            else if(other.ID > ID)
            {
                return -1;
            }
            else
            {
                return 1;
            }

        }

        public override string ToString()
        {
            return question;
        }
    }
}
