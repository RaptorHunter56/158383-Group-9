using System.Data.SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Data.SqlClient;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Data;
using System.Data.Common;

namespace Website_Http.Models
{
    [Table("Church")]
    public class Church
    {
        private int _id;
        private string _placeUrl;
        private string _title;
        private double? _rating = null;
        private int? _reviewCount = null;
        private string _category;
        private string _address;
        private string _plusCode;
        private string _website;
        private string _phoneNumber;
        private string _imgUrl;
        private double _latitude;
        private double _longitude;
        private string _query;
        private List<Dates> _dates;
        private Point _location;

        public int id { get => _id; set => _id = value; }
        public string placeUrl { get => _placeUrl; set => _placeUrl = value; }
        public string title { get => _title; set => _title = value; }
        public double? rating { get => _rating; set => _rating = value; }
        public int? reviewCount { get => _reviewCount; set => _reviewCount = value; }
        public string category { get => _category; set => _category = value; }
        public string address { get => _address; set => _address = value; }
        public string plusCode { get => _plusCode; set => _plusCode = value; }
        public string website { get => _website; set => _website = value; }
        public string phoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string imgUrl { get => _imgUrl; set => _imgUrl = value; }
        public double latitude { get => _latitude; set => _latitude = value; }
        public double longitude { get => _longitude; set => _longitude = value; }
        public string query { get => _query; set => _query = value; }
        public List<Dates> dates { get => _dates; set => _dates = value; }
        //Update Point Type
        /// <summary>
        /// Spacial Point
        /// </summary>
        public Point location { get => _location; set => _location = value; }

        public Church() => this._dates = new List<Dates>();
        public Church(int id_, string placeUrl_, string title_, double rating_, int reviewCount_, string category_, string address_, string plusCode_, string website_, string phoneNumber_, string imgUrl_, double latitude_, double longitude_, string query_, List<Dates> dates_, Point location_)
        {
            _id = id_;
            _placeUrl = placeUrl_;
            _title = title_;
            _rating = rating_;
            _reviewCount = reviewCount_;
            _category = category_;
            _address = address_;
            _plusCode = plusCode_;
            _website = website_;
            _phoneNumber = phoneNumber_;
            _imgUrl = imgUrl_;
            _latitude = latitude_;
            _longitude = longitude_;
            _query = query_;
            _dates = dates_;
            _location = location_;
        }

        public BasicData GetBasicData() => new BasicData(this);
        public struct BasicData
        {
            private int _id;
            private string _title;
            private string _category;
            private Point _location;

            public int id { get => _id; set => _id = value; }
            public string title { get => _title; set => _title = value; }
            public string category { get => _category; set => _category = value; }
            public Point location { get => _location; set => _location = value; }

            public BasicData(Church church)
            {
                _id = church.id;
                _title = church.title;
                _category = church.category;
                _location = church.location;
            }
        }

        //"SELECT * FROM Church LIMIT 5"
        public static Church GetChurch(int id) => GetChurches("SELECT * FROM Church WHERE id = " + id.ToString())[0];
        public static List<Church> GetChurches(string command)
        {
            string cs = @$"data source={Path.Combine(Environment.CurrentDirectory, "Database\\SpatiaServer.sqlite")}";
            var templist = new List<Church>();

            using (SQLiteConnection conn = new SQLiteConnection(cs))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(command, conn))
                {
                    conn.Open();
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var Church = new Church()
                            {
                                _id = rdr.GetInt32(0),
                                _placeUrl = rdr.GetString(1),
                                _title = rdr.GetString(2),
                                _rating = (double?)(rdr.IsDBNull(3) || (rdr.GetFieldValue<decimal>(3) == 0) ? new decimal?() : rdr.GetFieldValue<decimal>(3)),
                                _reviewCount = (int?)(rdr.IsDBNull(3) || (rdr.GetFieldValue<decimal>(4) == 0) ? new int?() : Decimal.ToInt32(rdr.GetFieldValue<decimal>(4))),
                                _category = rdr.GetString(5),
                                _address = rdr.GetString(6),
                                _plusCode = rdr.GetString(7),
                                _website = rdr.GetString(8),
                                _phoneNumber = rdr.GetString(9),
                                _imgUrl = rdr.GetString(10),
                                _latitude = rdr.GetDouble(11),
                                _longitude = rdr.GetDouble(12),
                                _query = rdr.GetString(13)
                            };
                            templist.Add(Church);
                        }
                    }
                    conn.Close();
                }
            }
            return templist;
        }
    }

    public class Dates
    {
        private long _churchID;
        private long _date;
        private string _time;

        public long churchID { get => _churchID; set => _churchID = value; }
        public long date { get => _date; set => _date = value; }
        public string time { get => _time; set => _time = value; }

        public Dates() { }
        public Dates(int churchID_, long date_, string time_)
        {
            this.churchID = churchID_;
            this.date = date_;
            this.time = time_;
        }

        public static List<Dates> GetDates(int churchID) => GetDates(churchID.ToString());
        public static List<Dates> GetDates(string churchID)
        {
            string cs = @$"data source={Path.Combine(Environment.CurrentDirectory, "Database\\SpatiaServer.sqlite")}";
            var templist = new List<Dates>();

            using (SQLiteConnection conn = new SQLiteConnection(cs))
            {
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM OpenTime WHERE churchID = " + churchID, conn))
                {
                    conn.Open();
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var Date = new Dates()
                            {
                                _churchID = (long)rdr.GetDouble(0),
                                _date = (long)rdr.GetDouble(1),
                                _time = rdr.GetString(2)
                            };
                            templist.Add(Date);
                        }
                    }
                    conn.Close();
                }
            }
            return templist;
        }
    }
}