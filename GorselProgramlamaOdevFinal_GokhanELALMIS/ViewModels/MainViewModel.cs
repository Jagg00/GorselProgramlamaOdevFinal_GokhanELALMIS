using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GorselProgramlamaOdevFinal_GokhanELALMIS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateToGiris => new Command(() => NavigateToPage(new MainPage()));
        public ICommand NavigateToKurlar => new Command(() => NavigateToPage(new KurlarPage()));
        public ICommand NavigateToHaberler => new Command(() => NavigateToPage(new Haberler()));
        public ICommand NavigateToHavaDurumu => new Command(() => NavigateToPage(new HavaDurumu()));
        public ICommand NavigateToYapilacaklar => new Command(() => NavigateToPage(new YapilacaklarPage()));
        public ICommand NavigateToAyarlar => new Command(() => NavigateToPage(new AyarlarPage()));

        private async void NavigateToPage(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
