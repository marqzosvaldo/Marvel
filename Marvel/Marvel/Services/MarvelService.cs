using Marvel.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Services {
    class MarvelService {

        string API_URL = "https://gateway.marvel.com";
        MyQueryParams Mykeys { get; set; }

        public MarvelService() {

            Mykeys = new MyQueryParams();
            Mykeys.apikey = "3349a20c3e4583673c06a2dc746410e5";
            Mykeys.ts = 1;
            Mykeys.hash = "d2aa1cbb95e0575ab0fcbd81e0480120";
        }
        public async Task<Character> GetCharacters() {          
            try {
                var apiResponse = RestService.For<ICharacters>("https://gateway.marvel.com");
                var characters = await apiResponse.GetCharacters(Mykeys);
                if (characters != null) {
                    return characters;
                }
                return null;
            } catch (Exception ex) {

                Debug.WriteLine($"GetCharacters Service ERROR=> {ex.Data}");

                Debug.WriteLine($"Message {ex.Message}");
            }
            return null;
          
        }

        public async Task<Character> GetCharacterByID(int id) {
            try {
                var apiResponse = RestService.For<ICharacters>("https://gateway.marvel.com");
                var characters = await apiResponse.GetCharacterByID(id,Mykeys);

                if(characters != null) {
                    return characters;
                }

                return null;

            } catch (Exception ex) {

                Debug.WriteLine($"GetCharacters Service ERROR=> {ex.Data}");
                Debug.WriteLine($"Message {ex.Message}");
            }
            return null;

        }
    }
}
