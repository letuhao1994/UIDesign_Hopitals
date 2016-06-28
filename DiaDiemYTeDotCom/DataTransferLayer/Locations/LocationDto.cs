using System;
using System.Collections.Generic;
using HelperLayer;

namespace DataTransferLayer.Locations
{
    public class LocationDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumbers { get; set; }
        public string FaxNumbers { get; set; }
        public string LocationType { get; set; }
        public List<string> Specialists { get; set; }
        public double Rating { get; set; }
        public string Area1 { get; set; }
        public string Area2 { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LocationDto()
        {
            Specialists = new List<string>();
            Rating = (double)RandomHelper.Instance.Random.Next(0, 50) / 10;
        }

        public static List<string> ParseSpecialists(string specialists)
        {
            List<string> result = new List<string>();

            if (!string.IsNullOrEmpty(specialists))
            {
                string[] parts = specialists.Split(new[] {";"}, StringSplitOptions.None);
                result.AddRange(parts);
            }

            return result;
        }

        public static string SpecialistsToString(List<string> specialists)
        {
            string result = "";

            if (specialists != null)
            {
                for (int i = 0; i < specialists.Count - 1; i++)
                {
                    result += specialists[i] + ";";
                }

                if (specialists.Count > 0)
                {
                    result += specialists[specialists.Count - 1];
                }              
            }

            return result;
        }

        public bool Exists(string specialist)
        {
            if (!string.IsNullOrEmpty(specialist))
            {
                return Specialists.Exists(x => x == specialist);
            }

            return false;
        }
    }
}
