using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using DataTransferLayer.Locations;
using HelperLayer;

namespace DataAccessLayer.XmlDatabaseContexts
{
    class LocationXmlContext
    {
        #region Singleton

        private static LocationXmlContext _instance;
        private static readonly object Padlock = new object();

        public static LocationXmlContext GetInstance(string path)
        {
            if (_instance == null)
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new LocationXmlContext(path);
                    }
                }              
            }

            return _instance;
        }

        private LocationXmlContext(string assemblyPath)
        {
            _assemblyPath = assemblyPath;
            if (File.Exists(_assemblyPath + DbPath) == false)
            {
                CreateDatabase();
            }

            _doc = new XmlDocument();           
            _doc.Load(_assemblyPath + DbPath);
            _root = _doc.DocumentElement;
        }

        #endregion

        #region Attributes

        private string _assemblyPath;
        private const string DbPath = "Database\\LocationDB.Xml";
        private readonly XmlDocument _doc;
        private readonly XmlElement _root;

        #endregion

        #region Private Methods

        private void CreateDatabase()
        {
            if (Directory.Exists(_assemblyPath + "Database") == false)
                Directory.CreateDirectory(_assemblyPath + "Database");

            var doc = new XmlDocument();
            var root = XmlHelper.CreateRoot(doc, "LOCATION_DATABASE");
            XmlHelper.CreateAttribute(doc, root, "CreatedDate", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
            XmlHelper.CreateAttribute(doc, root, "LastLocationId", "0");

            doc.Save(_assemblyPath + DbPath);
        }

        private void Save()
        {
            if (_doc != null)
            {
                _doc.Save(_assemblyPath + DbPath);
            }
        }

        #endregion

        #region Methods

        public List<LocationDto> GetLocations()
        {
            List<LocationDto> results = new List<LocationDto>();

            var locations = XmlHelper.GetElements(_doc.DocumentElement, "Location");
            if (locations != null)
            {
                foreach (var item in locations)
                {
                    var location = new LocationDto
                    {
                        Id = item.GetAttribute("Id"),
                        Name = item.GetAttribute("Name"),
                        Address = item.GetAttribute("Address"),
                        PhoneNumbers = item.GetAttribute("PhoneNumbers"),
                        FaxNumbers = item.GetAttribute("FaxNumbers"),
                        LocationType = item.GetAttribute("LocationType"),
                        Specialists = LocationDto.ParseSpecialists(item.GetAttribute("Specialists")),
                        Rating = double.Parse(item.GetAttribute("Rating")),
                        Area1 = item.GetAttribute("Area1"),
                        Area2 = item.GetAttribute("Area2"),
                        Latitude = double.Parse(item.GetAttribute("Latitude")),
                        Longitude = double.Parse(item.GetAttribute("Longitude"))
                    };

                    results.Add(location);
                }
            }

            return results;
        }

        public string AddLocation(LocationDto data)
        {
            if (data != null)
            {
                int newId = int.Parse(_root.GetAttribute("LastLocationId")) + 1;
                _root.Attributes["LastLocationId"].Value = newId.ToString();
                string newIdStr = "BV" + newId;

                var newItem = XmlHelper.CreateElement(_doc, _root, "Location");
                XmlHelper.CreateAttribute(_doc, newItem, "Id", newIdStr);
                XmlHelper.CreateAttribute(_doc, newItem, "Name", data.Name);
                XmlHelper.CreateAttribute(_doc, newItem, "Address", data.Address);
                XmlHelper.CreateAttribute(_doc, newItem, "PhoneNumbers", data.PhoneNumbers);
                XmlHelper.CreateAttribute(_doc, newItem, "FaxNumbers", data.FaxNumbers);
                XmlHelper.CreateAttribute(_doc, newItem, "LocationType", data.LocationType);
                XmlHelper.CreateAttribute(_doc, newItem, 
                    "Specialists", LocationDto.SpecialistsToString(data.Specialists));
                XmlHelper.CreateAttribute(_doc, newItem, 
                    "Rating", data.Rating.ToString(CultureInfo.CurrentCulture));
                XmlHelper.CreateAttribute(_doc, newItem, "Area1", data.Area1);
                XmlHelper.CreateAttribute(_doc, newItem, "Area2", data.Area2);
                XmlHelper.CreateAttribute(_doc, newItem, 
                    "Latitude", data.Latitude.ToString(CultureInfo.CurrentCulture));
                XmlHelper.CreateAttribute(_doc, newItem, 
                    "Longitude", data.Longitude.ToString(CultureInfo.CurrentCulture));

                Save();
                return newIdStr;
            }

            return "-1";
        }

        public bool UpdateLocation(LocationDto data)
        {
            if (data != null)
            {
                var exists = XmlHelper.GetElementsWithAttribute(_root, "Location", "Id", data.Id);
                if (exists.Count <= 0) return false;

                var newItem = exists[0];
                XmlHelper.CreateAttribute(_doc, newItem, "Name", data.Name);
                XmlHelper.CreateAttribute(_doc, newItem, "Address", data.Address);
                XmlHelper.CreateAttribute(_doc, newItem, "PhoneNumbers", data.PhoneNumbers);
                XmlHelper.CreateAttribute(_doc, newItem, "FaxNumbers", data.FaxNumbers);
                XmlHelper.CreateAttribute(_doc, newItem, "LocationType", data.LocationType);
                XmlHelper.CreateAttribute(_doc, newItem,
                    "Specialists", LocationDto.SpecialistsToString(data.Specialists));
                XmlHelper.CreateAttribute(_doc, newItem,
                    "Rating", data.Rating.ToString(CultureInfo.CurrentCulture));
                XmlHelper.CreateAttribute(_doc, newItem, "Area1", data.Area1);
                XmlHelper.CreateAttribute(_doc, newItem, "Area2", data.Area2);
                XmlHelper.CreateAttribute(_doc, newItem,
                    "Latitude", data.Latitude.ToString(CultureInfo.CurrentCulture));
                XmlHelper.CreateAttribute(_doc, newItem,
                    "Longitude", data.Longitude.ToString(CultureInfo.CurrentCulture));

                Save();
                return true;
            }

            return false;
        }

        public bool DeleteLocation(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var exists = XmlHelper.GetElementsWithAttribute(_root, "Location", "Id", id);
                if (exists.Count <= 0) return false;

                _root.RemoveChild(exists[0]);
                Save();
                return true;
            }

            return false;
        }

        #endregion
    }
}
