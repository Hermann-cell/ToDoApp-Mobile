using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppToDo.Data
{
    public class Enums
    {
        public enum Status
        {
            ToDo,          // correspond à "To do"
            InProgress,    // correspond à "In progress"
            Completed      // correspond à "Completed"
        };

        public enum Priority
        {
            Low,          // correspond à "To do"
            Medium,    // correspond à "In progress"
            High      // correspond à "Completed"
        }
    }
}
