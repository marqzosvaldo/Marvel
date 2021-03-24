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
    public partial class MCharacters : ContentPage {
        MCharactersViewModel _vm;

        public MCharactersViewModel VM { get => _vm = new MCharactersViewModel(this); }

        public MCharacters() {
            InitializeComponent();

            BindingContext = VM;
        }
    }
}