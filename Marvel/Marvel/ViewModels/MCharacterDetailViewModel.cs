
using Marvel.Models;
using Marvel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Marvel.ViewModels {
    public class MCharacterDetailViewModel : ViewModelBase {
        Result _character;

        public Result Character {
            get => _character;
            set {
                _character = value;
                OnPropertyChanged("Character");
            }
        }
        string _characterName;
        public string CharacterName { get => _characterName; 
            set {
                _characterName = value; ;
                OnPropertyChanged("CharacterName");} 
        }
        string _characterDescription;
        public string CharacterDescription { get => _characterDescription; 
            set { _characterDescription = value;
                OnPropertyChanged("CharacterDescription");
            } 
        }

        string _characterPicture;
        public string CharacterPicture {
            get => _characterPicture;
            set {
                _characterPicture = value;
                OnPropertyChanged("CharacterPicture");
            }
        }
        ObservableCollection<Result> _comics;
        public ObservableCollection<Result> Comics { get => _comics;
            set { _comics = value;
                OnPropertyChanged("Comics");
            } 
        }
       

        public MCharacterDetailViewModel(Page page, int characterID) : base(page) {
            GetCharacterByID(characterID);
            GetComicsByCharacterID(characterID);
        }
        async void GetCharacterByID(int id) {
            MarvelService MS = new MarvelService();
            try {
                var response = await MS.GetCharacterByID(id);
                var Character  = (response as Character).Data.Results.FirstOrDefault() ;
                CharacterName = Character.Name;
                CharacterDescription = Character.Description;
                CharacterPicture = $"{Character.Thumbnail.Path}.{Character.Thumbnail.Extension}";
                

                var webImage = new Image { Source = ImageSource.FromUri(new Uri($"{Character.Thumbnail.Path}.{Character.Thumbnail.Extension}")) };
                

                Debug.WriteLine("");
            } catch (Exception ex) {
                Debug.WriteLine($"GetCharacters ERROR=> {ex.Message}");
            }
        }
        async void GetComicsByCharacterID(int characterid) {
            MarvelService MS = new MarvelService();
            try {
                var response = await MS.GetComicsByCharacterID(characterid);
                Comics = (response as Character).Data.Results;

           

                Debug.WriteLine("");
            } catch (Exception ex) {
                Debug.WriteLine($"GetCharacters ERROR=> {ex.Message}");
            }

        }
    }
}
