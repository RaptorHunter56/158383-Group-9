public class Church
{
    private int _id;
    private string _placeUrl;
    private string _title;
    private double _rating;
    private int _reviewCount;
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
    private POINT _location;

    public int id { get => _id; set => _id = value; }
    public string placeUrl { get => _placeUrl; set => _placeUrl = value; }
    public string title { get => _title; set => _title = value; }
    public double rating { get => _rating; set => _rating = value; }
    public int reviewCount { get => _reviewCount; set => _reviewCount = value; }
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
    public POINT location { get => _location; set => _location = value; }

    public Church() => this._dates = new List<Dates>();
    public Church(int id_, string placeUrl_, string title_, double rating_, int reviewCount_, string category_, string address_, string plusCode_, string website_, string phoneNumber_, string imgUrl_, double latitude_, double longitude_, string query_, List<Dates> dates_, POINT location_)
    {
        this.id = id_;
        this.placeUrl = placeUrl_;
        this.title = title_;
        this.rating = rating_;
        this.reviewCount = reviewCount_;
        this.category = category_;
        this.address = address_;
        this.plusCode = plusCode_;
        this.website = website_;
        this.phoneNumber = phoneNumber_;
        this.imgUrl = imgUrl_;
        this.latitude = latitude_;
        this.longitude = longitude_;
        this.query = query_;
        this.dates = dates_;
        this.location = location_;
    }

    public BasicData GetBasicData() => new BasicData(this);
    public struct BasicData
    {
        private int _id;
        private string _title;
        private string _category;
        private POINT _location;

        public int id { get => _id; set => _id = value; }
        public string title { get => _title; set => _title = value; }
        public string category { get => _category; set => _category = value; }
        public POINT location { get => _location; set => _location = value; }

        public BasicData(Church church)
        {
            this.id = church.id;
            this.title = church.title;
            this.category = church.category;
            this.location = church.location;
        }
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
    public Dates(int churchID_, string date_, string time_)
    {
        this.churchID = churchID_;
        this.date = date_;
        this.time = time_;
    }
}