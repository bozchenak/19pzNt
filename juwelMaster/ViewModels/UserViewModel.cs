using juwelMaster.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.ViewModels
{
    internal class UserViewModel : BindableBase
    {
        private IUserRep _repository;
        public UserViewModel(IUserRep repository)
        {

            _repository = repository;
            Users = new ObservableCollection<User>();
            LoadUser();

            //PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            //AddCustomerCommand = new RelayCommand(OnAddCustomer);
            //EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
            //ClearSearchInput = new RelayCommand(OnClearSearch);
        }

        private ObservableCollection<User>? _users;
        public ObservableCollection<User>? Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private List<User>? _userList;
        public async void LoadUser()
        {
            _userList = await _repository.GetUser();
            Users = new ObservableCollection<User>(_userList);
        }

        public RelayCommand AddUserCommand { get; private set; }
        public RelayCommand ClearSearchInput { get; private set; }

        public event Action<User> AddUserRequested = delegate { };
        public event Action<User> EditUserRequested = delegate { };


        private void OnAddUser()
        {
            AddUserRequested(new User { });
        }
    }
}
