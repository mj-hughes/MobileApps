using System;
using Newtonsoft.Json;

namespace PersonalityQuizWithAPI
{


    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HeroAPI
    {

        // For picture, take the path, add orientation (e.g. /portrait_large or /portrait_medium), add extension

        [JsonProperty(PropertyName = "code")]
        public int code { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string status { get; set; }
        [JsonProperty(PropertyName = "copyright")]
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public string etag { get; set; }
        [JsonProperty(PropertyName = "data")]
        public Data data { get; set; }
    }

    public class Data
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        [JsonProperty(PropertyName = "results")]
        public Result[] results { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public string name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }
        public DateTime modified { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string resourceURI { get; set; }
        public Comics comics { get; set; }
        public Series series { get; set; }
        public Stories stories { get; set; }
        public Events events { get; set; }
        public Url[] urls { get; set; }
    }

    public class Thumbnail
    {
        public string path { get; set; }
        public string extension { get; set; }
    }

    public class Comics
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public Item[] items { get; set; }
        public int returned { get; set; }
    }

    public class Item
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Series
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public Item1[] items { get; set; }
        public int returned { get; set; }
    }

    public class Item1
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Stories
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public Item2[] items { get; set; }
        public int returned { get; set; }
    }

    public class Item2
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Events
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public Item3[] items { get; set; }
        public int returned { get; set; }
    }

    public class Item3
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Url
    {
        public string type { get; set; }
        public string url { get; set; }
    }


}
