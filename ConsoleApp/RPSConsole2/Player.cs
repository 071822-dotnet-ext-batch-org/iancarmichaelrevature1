using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSConsole2
{
    public class Player
    {
        public int myAge = 0;

        public DateTime myDoB { get; set; } = new DateTime(05/08/1990);
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool Gender { get; set; }
        private int wins;
        public int Wins 
        {
             get
             {
                return Wins;
             } 
             set
             {
                Wins++;
             }
        } 
        public int Losses { get; set; }
        private int myVar;
        public int MyProperty{
            get { return myVar; }
            set { myVar = value;}
        }

        public Player(){}
        public Player(string Fname){
            this.Fname= Fname;
        }

        public int GetAge()
        {
            return myAge;
        }
        public void SetAge(int myAge){
            if(myAge > 110 || myAge < 18){
                throw new FieldAccessException($"You can't set the age to {myAge}");
            }
            else
            {
                this.myAge = myAge;
            }
        
        }
        
    }
}
