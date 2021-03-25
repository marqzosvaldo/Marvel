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

        const string APIURL = "https://gateway.marvel.com";
        MyQueryParams Mykeys { get; set; }

        public MarvelService() {

            Mykeys = new MyQueryParams();
            Mykeys.APIKey = "3349a20c3e4583673c06a2dc746410e5";
            Mykeys.Ts = 1;
            Mykeys.Hash = "d2aa1cbb95e0575ab0fcbd81e0480120";
            Mykeys.Limit = 20;
            Mykeys.Offset = 0;
        }

    
        public async Task<Character> GetCharacters() {
            Mykeys.Offset = 0;
            try {
                var apiResponse = RestService.For<ICharacters>(APIURL);
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
        public async Task<Character> GetMoreCharacters(int Offset) {
            Mykeys.Offset = Offset;
            try {
                var apiResponse = RestService.For<ICharacters>(APIURL);
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

        public async Task<Character> GetCharacterByID(int characterid) {
            try {
                var apiResponse = RestService.For<ICharacters>(APIURL);
                var character = await apiResponse.GetCharacterByID(characterid, Mykeys);

                if(character != null) {
                    return character;
                }

                return null;

            } catch (Exception ex) {

                Debug.WriteLine($"GetCharacters Service ERROR=> {ex.Data}");
                Debug.WriteLine($"Message {ex.Message}");
            }
            return null;

        }

        public async Task<Character> GetComicsByCharacterID(int characterid) {
            try {
                var apiResponse = RestService.For<ICharacters>(APIURL);
                var comics = await apiResponse.GetComicsByCharacterID(characterid, Mykeys);
                if(comics != null) {
                    return comics;
                }
                return null;
            } catch (Exception ex) {
                Debug.WriteLine($"GetComicsByCharacterID Service ERROR=> {ex.Data}");
                Debug.WriteLine($"Message {ex.Message}");

            }
            return null;
        }
        
        
    }
}
