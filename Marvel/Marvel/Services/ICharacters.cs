using Marvel.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Services {
    public class MyQueryParams {
        [AliasAs("apikey")]
        public string APIKey { get; set; }
        [AliasAs("ts")]
        public int Ts { get; set; }
        [AliasAs("hash")]
        public string Hash { get; set; }
        [AliasAs("limit")]
        public int Limit { get; set; }
        [AliasAs("offset")]
        public int Offset { get; set; }
    }


    interface ICharacters {
        [Get("/v1/public/characters")]
        Task<Character> GetCharacters(MyQueryParams keys);

        [Get("/v1/public/characters/{characterid}")]
        Task<Character> GetCharacterByID(int characterid, MyQueryParams keys);

        [Get("/v1/public/characters/{characterid}/comics")]
        Task<Character> GetComicsByCharacterID(int characterid, MyQueryParams kyes);
    }
}
