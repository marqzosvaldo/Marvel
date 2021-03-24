using Marvel.Models;
using Marvel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvel.ViewModels {
    public class MCharactersViewModel : ViewModelBase {

        ObservableCollection<Result> _characters;

        public ObservableCollection<Result> Characters { get => _characters;
            set {
                _characters = value;
                OnPropertyChanged("Characters");
            }
        }
        public MCharactersViewModel(Page page) : base(page) {
            Title = "Marvel Characters";
            page.Appearing += Page_Appearing;
        }

        private void Page_Appearing(object sender, EventArgs e) {
            Debug.WriteLine("OnAppearing...");
            GetCharacters();
        }
        Result _selectedItemCharacter;
        public Result SelectedItemCharacter { get => _selectedItemCharacter;
            set {
                _selectedItemCharacter = value;
                OnPropertyChanged("SelectedItemCharacter");
            }
        }
        private ICommand _selectedCharacterCommand;
        public ICommand SelectedCharacterCommand => _selectedCharacterCommand ?? (_selectedCharacterCommand = new Command(async () => {
            var selected = SelectedItemCharacter;
            Debug.WriteLine("Selected!");
        }));
        
        async void GetCharacters() {
            MarvelService MS = new MarvelService();

            try {
                var response = await MS.GetCharacters();
                Characters = (response as Character).Data.Results;
                

               
            } catch (Exception ex) {

                Debug.WriteLine($"GetCharacters ERROR=> {ex}");
            }
        }
    }
}
