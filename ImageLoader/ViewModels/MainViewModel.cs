using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ImageLoader.Resources;

namespace ImageLoader.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Contacts = new ObservableCollection<ContactViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ContactViewModel> Contacts { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Contacts collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Contacts.Add(new ContactViewModel()
            {
                ID = "0",
                FirstName = "Bill",
                LastName = "Gates",
                ImageUrl =
                    "http://www.microsoft.com/global/en-us/news/PublishingImages/bod/billg/gates_web.jpg"
            });
            this.Contacts.Add(new ContactViewModel()
            {
                ID = "1",
                FirstName = "Steve",
                LastName = "Balmer",
                ImageUrl = "http://1.androidauthority.com/wp-content/uploads/2008/10/ballmer-1.jpg"
            });
            this.Contacts.Add(new ContactViewModel()
            {
                ID = "2",
                FirstName = "Paul",
                LastName = "Allen",
                ImageUrl = "http://tektype.files.wordpress.com/2010/08/paul_allen2.jpg?w=157&h=224"
            });

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}