using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataAccessLayer.XmlDatabaseContexts;
using DataTransferLayer.Locations;

namespace DataAccessLayer
{
    public static class LocationDao
    {
        //public static List<LocationDto> GetLocations(string path)
        //{
        //    List<LocationDto> results = new List<LocationDto>();

        //    if (File.Exists(path))
        //    {
        //        string[] texts = File.ReadAllLines(path, Encoding.UTF8);
        //        LocationDto location = null;
        //        for (int i = 0; i < texts.Length; i++)
        //        {
        //            if (i%5 == 0)
        //            {
        //                string[] parts = texts[i].Split(new[] {". "}, StringSplitOptions.None);
        //                if (parts.Length != 2)
        //                {
        //                    throw new Exception("Parse problem 1\n" + "Line: " + (i + 1) + "\n" + texts[i]);
        //                }

        //                location = new LocationDto();
        //                results.Add(location);
        //                location.Id = "BV" + parts[0].Replace(".", "");
        //                location.Name = parts[1].Replace(".", "");
        //            }
        //            else if (i%5 == 1)
        //            {
        //                string[] parts = texts[i].Split(new[] {"Địa chỉ: "}, StringSplitOptions.None);
        //                if (parts.Length != 2)
        //                {
        //                    throw new Exception("Parse problem 2\n" + "Line: " + (i + 1) + "\n" + texts[i]);
        //                }

        //                if (location != null)
        //                {
        //                    location.Address = parts[1].Replace(".", "");
        //                }
        //            }
        //            else if (i%5 == 2)
        //            {
        //                string[] parts = texts[i].Split(new[] {"Điện thoại: "}, StringSplitOptions.None);
        //                if (parts.Length != 2)
        //                {
        //                    throw new Exception("Parse problem 3\n" + "Line: " + (i + 1) + "\n" + texts[i]);
        //                }
                       
        //                if (location != null)
        //                {
        //                    string[] parts2 = parts[1].Split(new[] { " - Fax: " }, StringSplitOptions.None);
        //                    if (parts2.Length == 1)
        //                    {
        //                        location.PhoneNumbers = parts[1].Replace(".", "");
        //                    }
        //                    else if (parts2.Length == 2)
        //                    {
        //                        location.PhoneNumbers = parts2[0].Replace(".", "");
        //                        location.FaxNumbers = parts2[1].Replace(".", "");
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("Parse problem 4\n" + "Line: " + (i + 1) + "\n" + texts[i]);
        //                    }
        //                }
        //            }
        //            else if (i%5 == 3)
        //            {
        //                string[] parts = texts[i].Split(new[] { "Chuyên khoa: " }, StringSplitOptions.None);
        //                if (parts.Length != 2)
        //                {
        //                    throw new Exception("Parse problem 5\n" + "Line: " + (i + 1) + "\n" + texts[i]);
        //                }

        //                if (location != null)
        //                {
        //                    string[] parts2 = parts[1].Split(new[] { "; " }, StringSplitOptions.None);
        //                    foreach (var part in parts2)
        //                    {
        //                        if (!string.IsNullOrEmpty(part))
        //                        {
        //                            location.Specialists.Add(part.Replace(".", ""));
        //                        }
        //                    }                       
        //                }
        //            }
        //        }
        //    }                      

        //    return results;
        //}

        public static List<LocationDto> GetLocations2(string path)
        {
            var db = LocationXmlContext.GetInstance(path);
            return db.GetLocations();
        } 

        public static string AddLocation(string path, LocationDto location)
        {
            var db = LocationXmlContext.GetInstance(path);
            return db.AddLocation(location);
        }

        public static bool UpdateLocation(string path, LocationDto location)
        {
            return LocationXmlContext.GetInstance(path).UpdateLocation(location);
        }

        public static bool DeleteLocation(string path, string id)
        {
            return LocationXmlContext.GetInstance(path).DeleteLocation(id);
        }
    }
}
