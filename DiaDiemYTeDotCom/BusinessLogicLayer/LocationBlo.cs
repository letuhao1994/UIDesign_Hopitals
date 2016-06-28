using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataTransferLayer.Locations;

namespace BusinessLogicLayer
{
    public enum SortOption
    {
        Name = 0,
        SpectialistAndName = 1,
        Rating = 2
    }

    public enum SearchOption
    {
        Id = -1,
        Name = 0,
        Address = 1,
        Specialist = 2
    }

    public static class LocationBlo
    {
        private static string ToAscii(string data)
        {
            string result = data;

            result = result.Replace("à", "a").Replace("À", "A");
            result = result.Replace("á", "a").Replace("Á", "A");
            result = result.Replace("ạ", "a").Replace("Ạ", "A");
            result = result.Replace("ả", "a").Replace("Ả", "A");
            result = result.Replace("ã", "a").Replace("Ã", "A");

            result = result.Replace("â", "a").Replace("Â", "A");
            result = result.Replace("ầ", "a").Replace("Ầ", "A");
            result = result.Replace("ấ", "a").Replace("Ấ", "A");          
            result = result.Replace("ậ", "a").Replace("Ậ", "A");
            result = result.Replace("ẩ", "a").Replace("Ẩ", "A");
            result = result.Replace("ẫ", "a").Replace("Ẫ", "A");

            result = result.Replace("ă", "a").Replace("Ă", "A");
            result = result.Replace("ằ", "a").Replace("Ằ", "A");
            result = result.Replace("ắ", "a").Replace("Ắ", "A");
            result = result.Replace("ặ", "a").Replace("Ặ", "A");
            result = result.Replace("ẳ", "a").Replace("Ẳ", "A");
            result = result.Replace("ẵ", "a").Replace("Ẵ", "A");

            result = result.Replace("è", "e").Replace("È", "E");
            result = result.Replace("é", "e").Replace("É", "E");
            result = result.Replace("ẹ", "e").Replace("Ẹ", "E");
            result = result.Replace("ẻ", "e").Replace("Ẻ", "E");
            result = result.Replace("ẽ", "e").Replace("Ẽ", "E");

            result = result.Replace("ê", "e").Replace("Ê", "E");
            result = result.Replace("ề", "e").Replace("Ề", "E");
            result = result.Replace("ế", "e").Replace("Ế", "E");
            result = result.Replace("ệ", "e").Replace("Ệ", "E");
            result = result.Replace("ể", "e").Replace("Ể", "E");
            result = result.Replace("ễ", "e").Replace("Ễ", "E");

            result = result.Replace("ù", "u").Replace("Ù", "U");
            result = result.Replace("ú", "u").Replace("Ú", "U");
            result = result.Replace("ụ", "u").Replace("Ụ", "U");
            result = result.Replace("ủ", "u").Replace("Ủ", "U");
            result = result.Replace("ũ", "u").Replace("Ũ", "U");

            result = result.Replace("ư", "u").Replace("Ư", "U");
            result = result.Replace("ừ", "u").Replace("Ừ", "U");
            result = result.Replace("ứ", "u").Replace("Ứ", "U");
            result = result.Replace("ự", "u").Replace("Ự", "U");
            result = result.Replace("ử", "u").Replace("Ử", "U");
            result = result.Replace("ữ", "u").Replace("Ữ", "U");

            result = result.Replace("ò", "o").Replace("Ò", "O");
            result = result.Replace("ó", "o").Replace("Ó", "O");
            result = result.Replace("ọ", "o").Replace("Ọ", "O");
            result = result.Replace("ỏ", "o").Replace("Ỏ", "O");
            result = result.Replace("õ", "o").Replace("Õ", "O");

            result = result.Replace("ô", "o").Replace("Ô", "O");
            result = result.Replace("ồ", "o").Replace("Ồ", "O");
            result = result.Replace("ố", "o").Replace("Ố", "O");
            result = result.Replace("ộ", "o").Replace("Ộ", "O");
            result = result.Replace("ổ", "o").Replace("Ổ", "O");
            result = result.Replace("ỗ", "o").Replace("Ỗ", "O");

            result = result.Replace("ơ", "o").Replace("Ơ", "O");
            result = result.Replace("ờ", "o").Replace("Ờ", "O");
            result = result.Replace("ớ", "o").Replace("Ớ", "O");
            result = result.Replace("ợ", "o").Replace("Ợ", "O");
            result = result.Replace("ỏ", "o").Replace("Ở", "O");
            result = result.Replace("ỡ", "o").Replace("Ỡ", "O");

            result = result.Replace("ì", "i").Replace("Ì", "I");
            result = result.Replace("í", "i").Replace("Í", "I");
            result = result.Replace("ị", "i").Replace("Ị", "I");
            result = result.Replace("ỉ", "i").Replace("Ỉ", "I");
            result = result.Replace("ĩ", "i").Replace("Ĩ", "I");

            result = result.Replace("ỳ", "y").Replace("Ỳ", "Y");
            result = result.Replace("ý", "y").Replace("Ý", "Y");
            result = result.Replace("ỵ", "y").Replace("Ỵ", "Y");
            result = result.Replace("ỷ", "y").Replace("Ỷ", "Y");
            result = result.Replace("ỹ", "y").Replace("Ỹ", "Y");

            result = result.Replace("đ", "d").Replace("Đ", "D");

            return result;
        }

        private static void SortByName(List<LocationDto> data, bool isAscending)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (isAscending)
                    {
                        if (string.Compare(data[i].Name, data[j].Name, StringComparison.CurrentCulture) == 1)
                        {
                            var temp = data[i];
                            data[i] = data[j];
                            data[j] = temp;
                        }
                    }
                    else
                    {
                        if (string.Compare(data[i].Name, data[j].Name, StringComparison.CurrentCulture) == -1)
                        {
                            var temp = data[i];
                            data[i] = data[j];
                            data[j] = temp;
                        }
                    }
                }
            }
        }

        private static void SortBýpecialistAndName(List<LocationDto> data, bool isAscending)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (isAscending)
                    {
                        if (string.Compare(data[i].Specialists[0], data[j].Specialists[0],
                            StringComparison.CurrentCulture) == 1)
                        {
                            var temp = data[i];
                            data[i] = data[j];
                            data[j] = temp;
                        }
                        else
                        {
                            if (string.Compare(data[i].Specialists[0], data[j].Specialists[0],
                                StringComparison.CurrentCulture) == 0)
                            {
                                if (string.Compare(data[i].Name, data[j].Name,
                                    StringComparison.CurrentCulture) == 1)
                                {
                                    var temp = data[i];
                                    data[i] = data[j];
                                    data[j] = temp;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (string.Compare(data[i].Specialists[0], data[j].Specialists[0],
                            StringComparison.CurrentCulture) == -1)
                        {
                            var temp = data[i];
                            data[i] = data[j];
                            data[j] = temp;
                        }
                        else
                        {
                            if (string.Compare(data[i].Specialists[0], data[j].Specialists[0],
                                StringComparison.CurrentCulture) == 0)
                            {
                                if (string.Compare(data[i].Name, data[j].Name,
                                    StringComparison.CurrentCulture) == 1)
                                {
                                    var temp = data[i];
                                    data[i] = data[j];
                                    data[j] = temp;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void SortByRating(List<LocationDto> data, bool isAscending)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (isAscending)
                    {
                        if (data[i].Rating > data[j].Rating)
                        {
                            var temp = data[i];
                            data[i] = data[j];
                            data[j] = temp;
                        }
                    }
                    else
                    {
                        if (data[i].Rating < data[j].Rating)
                        {
                            var temp = data[i];
                            data[i] = data[j];
                            data[j] = temp;
                        }
                    }
                }
            }
        }

        //public static List<LocationDto> GetLocations(string path)
        //{
        //    var result = LocationDao.GetLocations(path);
        //    SortBýpecialistAndName(result, true);

        //    return result;
        //}

        public static List<LocationDto> GetLocations2(string path)
        {
            var result = LocationDao.GetLocations2(path);
            return result;
        }

        public static string Add(string path, LocationDto location)
        {
            return LocationDao.AddLocation(path, location);
        }

        public static bool Update(string path, LocationDto location)
        {
            return LocationDao.UpdateLocation(path, location);
        }

        public static bool Delete(string path, string id)
        {
            return LocationDao.DeleteLocation(path, id);
        }

        public static void Sort(List<LocationDto> data, SortOption sortOption, bool isAscending)
        {
            if (data != null)
            {
                switch (sortOption)
                {
                    case SortOption.Name:
                        SortByName(data, isAscending);
                        break;

                    case SortOption.SpectialistAndName:
                        SortBýpecialistAndName(data, isAscending);
                        break;

                    case SortOption.Rating:
                        SortByRating(data, isAscending);
                        break;
                }
            }
        }

        public static List<LocationDto> Search(List<LocationDto> data, SearchOption searchOption, string input)
        {
            List<LocationDto> result = new List<LocationDto>();           
            if (data != null)
            {
                foreach (var location in data)
                {
                    string value;
                    switch (searchOption)
                    {
                        case SearchOption.Id:
                            if (location.Id == input)
                            {
                                result.Add(location);
                            }
                            break;

                        case SearchOption.Name:
                            input = ToAscii(input).ToLower();
                            value = ToAscii(location.Name).ToLower();
                            if (value.Contains(input))
                            {
                                result.Add(location);
                            }
                            break;

                        case SearchOption.Address:
                            input = ToAscii(input).ToLower();
                            value = ToAscii(location.Address).ToLower();
                            if (value.Contains(input))
                            {
                                result.Add(location);
                            }
                            break;

                        case SearchOption.Specialist:
                            input = ToAscii(input).ToLower();
                            value = "";

                            foreach (var sp in location.Specialists)
                            {
                                value += ToAscii(sp).ToLower() + "; ";
                            }

                            if (value.Contains(input))
                            {
                                result.Add(location);
                            }
                            break;
                    }
                }
            }

            return result;
        } 
    }
}
