using System;


namespace Poof.Model 
{
    public class Task : Abstract_Model.Base_Poof
    {
       public string Description { get; set; }
        
        //DateTime(int Year, int Month, int Day, int Hour, int Min, int Sec) will use this in the converter? Or cs file
        public Task(string name, string description)
        {
            Name = name;
            Description = description;
        }

        

    }
}
