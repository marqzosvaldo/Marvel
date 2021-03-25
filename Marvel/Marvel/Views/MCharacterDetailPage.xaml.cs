using Marvel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvel.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MCharacterDetailPage : ContentPage {
        MCharacterDetailViewModel _vm;
        public int CharacterID { get; set; }

        public MCharacterDetailViewModel VM { get => _vm = new MCharacterDetailViewModel(this, CharacterID); }
        public MCharacterDetailPage(int CharacterID) {
            InitializeComponent();
            this.CharacterID = CharacterID;
            BindingContext = VM;

        }

        private async void Button_Clicked(object sender, EventArgs e) {
            await Navigation.PopModalAsync();

        }
    }
}