using System;

namespace MyProject.Model
{
    public class User
    {
        public int ID { get; set; } // int, not null
        public string FirstName { get; set; } // nvarchar(80), not null
        public string LastName { get; set; } // nvarchar(80), not null
        public string UserName { get; set; } // nvarchar(20), not null
        public string Gender { get; set; } // char(1), not null
        public byte Age { get; set; } // tinyint, not null
        public bool IsActive { get; set; } // bit, not null
        public string Title { get; set; } // nvarchar(50), not null
        public int Approbation { get; set; } // int, not null
        public string TagInit { get; set; } // nvarchar(50), not null
        public string Email { get; set; } // nvarchar(100), not null
        public int idWorkShift { get; set; } // int, not null
        public int idWorkArea { get; set; } // int, not null
        public int idProfile { get; set; } // int, not null
        public string Password { get; set; }

        public bool IsConnected { get; set; }
        public int idLoginType { get; set; }

        public string LastLoginDevice { get; set; }

        //Stores a New Area Name
        public string NewAreaName { get; set; }

        //Stores a New Workshift Name
        public string NewWorkShiftName { get; set; }

        //Stores a new workshift starting time
        public TimeSpan? NewWorkShiftStartTime { get; set; }

        //Stores a new workshift ending time
        public TimeSpan? NewWorkshiftEndTime { get; set; }

        public string ERROR { get; set; }
    }
}