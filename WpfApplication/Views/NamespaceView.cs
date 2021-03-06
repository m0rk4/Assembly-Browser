using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Entities;

namespace WpfApplication.Views
{
    public class NamespaceView : INotifyPropertyChanged
    {
        private IEnumerable<ClassView> _classes;

        private string _name;

        public NamespaceView(NamespaceInformation namespaceInformation)
        {
            Name = namespaceInformation.Name;
            Classes = namespaceInformation.Classes.Select(type => new ClassView(type));
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<ClassView> Classes
        {
            get => _classes;
            set
            {
                _classes = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}