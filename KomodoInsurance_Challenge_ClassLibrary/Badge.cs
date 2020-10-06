using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Challenge_ClassLibrary
{
    public class Badge

    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; } = new List<string>();

        public Badge() { }

        public Badge(int badgeID, List<string> doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;
        }
    }
}
