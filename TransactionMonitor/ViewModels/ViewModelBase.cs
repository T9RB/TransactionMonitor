using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace TransactionMonitor.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        
        public event PropertyChangedEventHandler PropertyChangedparam;
        protected void NotifyOfPropertyChange(string name)
        {           
            PropertyChangedEventHandler handler = PropertyChangedparam;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        
    }
    
}