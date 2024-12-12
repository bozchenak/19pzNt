using juwelMaster.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.ViewModels
{
    internal class AddClientViewModel : BindableBase
    {
        private IClientRep _repository;
        public AddClientViewModel()
        {
            _repository = new ClientRep();
            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
        }
        private bool _isEditeMode;
        public bool IsEditeMode
        {
            get => _isEditeMode;
            set => SetProperty(ref _isEditeMode, value);
        }

        private Client _editClient = null;
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done;

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void OnCancel()
        {
            Done?.Invoke();
        }

        private async void OnSave()
        {
            if (IsEditeMode)
            {
                await _repository.AddClient(_editClient);
            }
            Done?.Invoke();
        }
    }
}

