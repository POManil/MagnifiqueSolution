using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.MVVM.ViewModels;

namespace MagnifiqueProjet.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ObservableCollection<PersonViewModel> _Items;
        private string _Nom, _Prenom;

        // rappel : Observeur : simple interface avec evenement (INotifyProp / INotifyColl / ICmd)
        public ObservableCollection<PersonViewModel> Items
        {
            get
            {
                return _Items ?? (_Items = new ObservableCollection<PersonViewModel>()); // = instancier à la premiere utilisation
            }
        }

        public string Nom
        {
            get
            {
                return _Nom;
            }

            set
            {
                if (_Nom != value)
                {
                    _Nom = value;
                    RaisePropertyChanged(nameof(Nom));
                }
            }
        }

        public string Prenom
        {
            get
            {
                return _Prenom;
            }

            set
            {
                if (_Prenom != value)
                {
                    _Prenom = value;
                    RaisePropertyChanged(nameof(Prenom));
                }
            }
        }

    }
}
