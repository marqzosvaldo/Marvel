using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Marvel.Models {

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Thumbnail {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Item {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        // Pendiente para checar el valor
        public string Type { get; set; }
    }

    public class Comics {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Series {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Stories {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Events {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Url {
        public string Type { get; set; }
        public string url { get; set; }
    }

    public class Result {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string ResourceURI { get; set; }
        public Comics Comics { get; set; }
        public Series Series { get; set; }
        public Stories Stories { get; set; }
        public Events Events { get; set; }
        public ObservableCollection<Url> Urls { get; set; }
    }

    public class Data {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public ObservableCollection<Result> Results { get; set; }
    }

    public class Character {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHTML { get; set; }
        public string Etag { get; set; }
        public Data Data { get; set; }
    }




}
