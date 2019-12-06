using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Location
    {
        public double Latitude;
        public double Longitude;
    }

    public class ScanInMap
    {
        public string Barcode;
        public DateTime Time;
        public int ClassId;
        public Location Location;
    }

    public class ScanOutMap : Scan
    {
        public string Status;
    }

    public class ScanResponse {
        public string ActionPerformed;
        public string FirstName;
    }

    public class ClassMap
    {
        public int ClassId;
        public string Day;
        public TimeSpan StartTime;
        public TimeSpan EndTime;
        public string Name;
        public List<string> Labels;
    }

    public class ClassesMap
    {
        public List<ClassMap> Classes;

        public ClassesMap()
        {
            Classes = new List<ClassMap>();
        }
    }
}
