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
        public string apikey { get; set; }

        public int ts { get; set; }

        public string hash { get; set; }
    }


    interface ICharacters {
        [Get("/v1/public/characters")]
        Task<Character> GetCharacters(MyQueryParams keys);

        [Get("/v1/public/characters/{id}")]
        Task<Character> GetCharacterByID(int id, MyQueryParams keys);

    }
}
