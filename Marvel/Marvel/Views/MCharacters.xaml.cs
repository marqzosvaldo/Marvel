using Marvel.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvel.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MCharacters : ContentPage {
        MCharactersViewModel _vm;

        public MCharactersViewModel VM { get => _vm = new MCharactersViewModel(this); }

        public MCharacters() {
            InitializeComponent();

            BindingContext = VM;
        }

        private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e) {


            Debug.WriteLine("Scrolling...");
            if(e.LastVisibleItemIndex ==_vm.CurrentOffset-1) {
                Debug.WriteLine("LAST ONE!!!!!!!!!!");
                Debug.WriteLine("Loading more");

                try {
                    //CollectionCharacter.ScrollTo(e.LastVisibleItemIndex-1);

                } catch (Exception ex) {

                    Debug.WriteLine($"Exception => {ex.Message}");
                }

                _vm.LoadMoreCharacters();


                Debug.WriteLine($"Characters Count => {_vm.Characters.Count()}");



            }

        }
    }
}