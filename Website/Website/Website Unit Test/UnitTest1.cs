using System.Data.Entity.Infrastructure;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using Website_Http.Models;
using static System.Net.WebRequestMethods;

namespace Website_Unit_Test
{
    [TestClass]
    public class DatabaseUnitTest
    {
        [TestMethod]
        public void TestMethodGetChurch()
        {
            Church baseChurch = new Church()
            {
                id = 1,
                placeUrl = "https://www.google.com/maps/place/Anglican+Church/data=!4m7!3m6!1s0x6d09810c664bf8f1:0x4d15dc392b3e82d0!8m2!3d-34.9901111!4d173.5349054!16s%2Fg%2F1w346sz3!19sChIJ8fhLZgyBCW0R0II-KzncFU0",
                title = "Anglican Church",
                rating = 5,
                reviewCount = 1,
                category = "Anglican church",
                address = "9 Colonel Mould Drive, Mang≈\u008dnui 0420, New Zealand",
                plusCode = "2G5M+XX Mang≈\u008dnui, New Zealand",
                phoneNumber = "",
                website = "https://www.anglican.org.nz/",
                imgUrl = "https://lh5.googleusercontent.com/p/AF1QipP-c-qzFtWedP1idbmWcJvD8cszvamhrHDdtBWd=w408-h306-k-no",
                latitude = -34.9900625,
                longitude = 173.5349375,
                query = "https://www.google.com/maps/search/churches/@-35.3014678,173.5876911,10.5z/data=!4m2!2m1!6e1"
            };
            Church church = Church.GetChurch(1);
            List<Variance> rt = church.DetailedCompare(baseChurch);
            Assert.AreEqual(1, rt.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodGetNullChurch()
        {
            Church church = Church.GetChurch(-0);
        }

        [TestMethod]
        public void TestMethodGetChurchList()
        {
            List<Church> baseChurch = new List<Church>(){ 
                new Church() {
                    id = 1,
                    placeUrl = "https://www.google.com/maps/place/Anglican+Church/data=!4m7!3m6!1s0x6d09810c664bf8f1:0x4d15dc392b3e82d0!8m2!3d-34.9901111!4d173.5349054!16s%2Fg%2F1w346sz3!19sChIJ8fhLZgyBCW0R0II-KzncFU0",
                    title = "Anglican Church",
                    rating = 5,
                    reviewCount = 1,
                    category = "Anglican church",
                    address = "9 Colonel Mould Drive, Mang≈\u008dnui 0420, New Zealand",
                    plusCode = "2G5M+XX Mang≈\u008dnui, New Zealand",
                    phoneNumber = "",
                    website = "https://www.anglican.org.nz/",
                    imgUrl = "https://lh5.googleusercontent.com/p/AF1QipP-c-qzFtWedP1idbmWcJvD8cszvamhrHDdtBWd=w408-h306-k-no",
                    latitude = -34.9900625,
                    longitude = 173.5349375,
                    query = "https://www.google.com/maps/search/churches/@-35.3014678,173.5876911,10.5z/data=!4m2!2m1!6e1"
                } 
            };
            List<Church> church = Church.GetChurches("SELECT * FROM Church LIMIT 1;");
            List<Variance> rt = church[0].DetailedCompare(baseChurch[0]);
            Assert.AreEqual(1, rt.Count());
        }

        [TestMethod]
        public void TestMethodGetDate()
        {
            List<Dates> basedates = new List<Dates>(){
                new Dates() { churchID = 67, date = 1, time = "Open 24 hours"},
                new Dates() { churchID = 67, date = 2, time = "Open 24 hours"},
                new Dates() { churchID = 67, date = 3, time = "Open 24 hours"},
                new Dates() { churchID = 67, date = 4, time = "Open 24 hours"},
                new Dates() { churchID = 67, date = 5, time = "Open 24 hours"},
                new Dates() { churchID = 67, date = 6, time = "Open 24 hours"},
                new Dates() { churchID = 67, date = 7, time = "5AM-3PM"}
            };
            List<Dates> dates = Dates.GetDates(67);
            List<Variance> rt = dates[0].DetailedCompare(basedates[0]);
            List<Variance> rt2 = dates[1].DetailedCompare(basedates[1]);
            List<Variance> rt3 = dates[2].DetailedCompare(basedates[2]);
            List<Variance> rt4 = dates[3].DetailedCompare(basedates[3]);
            List<Variance> rt5 = dates[4].DetailedCompare(basedates[4]);
            List<Variance> rt6 = dates[5].DetailedCompare(basedates[5]);
            List<Variance> rt7 = dates[6].DetailedCompare(basedates[6]);

            Assert.AreEqual(0, rt.Count());
            Assert.AreEqual(0, rt2.Count());
            Assert.AreEqual(0, rt3.Count());
            Assert.AreEqual(0, rt4.Count());
            Assert.AreEqual(0, rt5.Count());
            Assert.AreEqual(0, rt6.Count());
            Assert.AreEqual(0, rt7.Count());
        }

        [TestMethod]
        public void TestMethodGetNullDate()
        {
            List<Dates> dates = Dates.GetDates(-0);
        }
    }
}