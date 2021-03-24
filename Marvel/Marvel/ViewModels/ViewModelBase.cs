using Xamarin.Forms;

namespace Marvel.ViewModels {
    public class ViewModelBase : MvvmHelpers.BaseViewModel {

        protected Page page;

        public ViewModelBase(Page page) {
            this.page = page;
        }
    }
}
