using Marvel.Models;
using Marvel.Services;
using Marvel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            GetCharacters();

        }

        int _currentOffset;
        public int CurrentOffset {
            get => _currentOffset;
            set {
                _currentOffset = value;
                OnPropertyChanged("CurrentOffset");
            }
        }
        bool _isRefreshing;
        public bool IsRefreshing { get => _isRefreshing; set { _isRefreshing = value; OnPropertyChanged("IsRefreshing"); } }

        private void Page_Appearing(object sender, EventArgs e) {
            Debug.WriteLine("OnAppearing...");
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
            var selected = SelectedItemCharacter as Result;
            //GetCharacterByID(selected.Id);
            await page.Navigation.PushModalAsync(new MCharacterDetailPage(selected.Id));
            Debug.WriteLine("Selected!");

        }));
        ICommand _refreshCommand;
        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new Command(async () => {
            //RefreshView.IsRefreshing = true;
            Debug.WriteLine("Refreshing...");
            GetCharacters();
            IsRefreshing = false;
        }));
        
        public async void GetCharacters() {
            MarvelService MS = new MarvelService();
            try {
                var response = await MS.GetCharacters();
                if(response.Code != 200) {

                   await  page.DisplayAlert($"Código {response.Code}", response.Status,"Ok");
                }

                Characters = (response as Character).Data.Results;

                CurrentOffset = Characters.Count();

            } catch (Exception ex) {

                Debug.WriteLine($"GetCharacters ERROR=> {ex}");
            }
        }

        public async void LoadMoreCharacters() {
            if(Characters != null) {
                CurrentOffset = Characters.Count();
            }
            MarvelService MS = new MarvelService();
            try {
                var response = await MS.GetMoreCharacters(CurrentOffset);
                if (response.Code != 200) {
                    await page.DisplayAlert($"Código {response.Code}", response.Status, "Ok");
                }

                await Task.Delay(2000);
                //Characters = (response as Character).Data.Results;
                foreach (var character in (response as Character).Data.Results) {
                    Characters.Add(character);
                }
            } catch (Exception ex) {

                Debug.WriteLine($"GetCharacters ERROR=> {ex}");
            }
        }

        
       
    }
}
