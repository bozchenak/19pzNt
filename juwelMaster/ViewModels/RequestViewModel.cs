using juwelMaster.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.ViewModels
{
    internal class RequestViewModel : BindableBase
    {
        private IRequestRep _repository;
        public RequestViewModel(IRequestRep repository)
        {

            _repository = repository;
            Requests = new ObservableCollection<Request>();
            LoadClient();

            //AddCustomerCommand = new RelayCommand(OnAddCustomer);
            //EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
            //ClearSearchInput = new RelayCommand(OnClearSearch);
        }

        private ObservableCollection<Request>? _requests;
        public ObservableCollection<Request>? Requests
        {
            get => _requests;
            set => SetProperty(ref _requests, value);
        }

        private List<Request>? _requestsList;
        public async void LoadClient()
        {
            _requestsList = await _repository.GetRequest();
            Requests = new ObservableCollection<Request>(_requestsList);
        }


        public RelayCommand AddRequestCommand { get; private set; }

        public event Action<Request> AddRequestRequested = delegate { };
        public event Action<Request> EditRequestRequested = delegate { };


        private void OnAddClient()
        {
            AddRequestRequested(new Request { });
        }
    }
}
