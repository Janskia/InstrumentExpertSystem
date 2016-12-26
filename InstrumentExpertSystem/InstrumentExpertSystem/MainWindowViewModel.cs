using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace InstrumentExpertSystem
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private KnowledgeBase knowledgeBase { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public int KnowledgeBaseInstrumentsCount
        {
            get
            {
                return knowledgeBase.Instruments == null ? 0 : knowledgeBase.Instruments.Count;
            }
            set
            { }
        }

        //public string FirstName
        //{
        //    get { return _person.FirstName; }
        //    set
        //    {
        //        _person.FirstName = value;
        //        OnPropertyChanged("FirstName");
        //    }
        //}

        //public string LastName
        //{
        //    get { return _person.LastName; }
        //    set
        //    {
        //        _person.LastName = value;
        //        OnPropertyChanged("LastName");
        //    }
        //}

        //public string Address
        //{
        //    get { return _person.Address; }
        //    set
        //    {
        //        _person.Address = value;
        //        OnPropertyChanged("Address");
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowViewModel()
        {
            knowledgeBase = new KnowledgeBase();
        }

        public ICommand LoadKnowledgeBase { get { return new RelayCommand(LoadKnowledgeBaseExcute); } }

        private void LoadKnowledgeBaseExcute()
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.ShowDialog();
            //if (fDialog.ShowDialog() != DialogResult.OK)
            //    return;

            System.IO.FileInfo fInfo = new System.IO.FileInfo(fDialog.FileName);
            string strFileName = fInfo.Name;
            string strFilePath = fInfo.DirectoryName;
            try
            {
                knowledgeBase = KnowledgeBaseSerialization.LoadKnowledgeBase(strFilePath + "\\" + strFileName);
            }
            catch
            {
                MessageBox.Show("Cannot read file");
                knowledgeBase = new KnowledgeBase();
            }
        //    OnPropertyChanged("KnowledgeBaseInstrumentsCount");
        }

        //private void SavePerosn(Person _person)
        //{
        //    //Some Database Logic
        //}

        //private bool CanSayHiExcute()
        //{
        //    return !PersonExists(_person);
        //}

        //private bool PersonExists(Person _person)
        //{
        //    //Some logic
        //    return false;
        //}

    }
}