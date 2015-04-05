using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel.Helpers;
using System.Windows.Input;
using Hospital.ViewModel.General.Patients;
using Hospital.ViewModel.General.Appointments;
using Hospital.ViewModel.General.Cases;

namespace Hospital.ViewModel.DoctorsArea
{
    public class DoctorsAreaViewModel : ObservableObject
    {
 
        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }


        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public DoctorsAreaViewModel()
        {
            // Add available pages
            PageViewModels.Add(new PatientsPageViewModel());
            PageViewModels.Add(new AppointmentsPageViewModel());
            PageViewModels.Add(new CasesPageViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
    }
    }

