using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace InstrumentExpertSystem
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private KnowledgeBase knowledgeBase { get; set; }
        private FrequencyMaxParameter frequencyMaxParameter = new FrequencyMaxParameter();
        private FrequencyMinParameter frequencyMinParameter = new FrequencyMinParameter();
        private VolumeMaxParameter volumeMaxParameter = new VolumeMaxParameter();
        private VolumeMinParameter volumeMinParameter = new VolumeMinParameter();
        private CanGlissParameter canGlissParameter = new CanGlissParameter();
        private CanModulateFrequencyParameter canModulateParameter = new CanModulateFrequencyParameter();
        private SingleSoundSpectrumWidthParameter singleSoundSpectrumWidthParameter = new SingleSoundSpectrumWidthParameter();
        private AverageSoundDurationParameter averageSoundDurationParameter = new AverageSoundDurationParameter();
        private IsMelodicParameter isMelodicParameter = new IsMelodicParameter();
        private EnvelopeTypeParameter envelopeTypeParameter = new EnvelopeTypeParameter();

        private InferenceHistory inferenceHistory = new InferenceHistory();
        #region PublicProperties
        public EnvelopeType EnvelopeType
        {
            get
            {
                return envelopeTypeParameter.EnvelopeType;
            }
            set
            {
                envelopeTypeParameter.EnvelopeType = value;
            }
        }
        public bool EnvelopeTypeEnabled
        {
            get
            {
                return envelopeTypeParameter.Enabled;
            }
            set
            {
                envelopeTypeParameter.Enabled = value;
            }
        }
        public bool IsMelodicEnabled
        {
            get
            {
                return isMelodicParameter.Enabled;
            }
            set
            {
                isMelodicParameter.Enabled = value;
            }
        }
        public bool IsMelodic
        {
            get
            {
                return isMelodicParameter.IsMelodic;
            }
            set
            {
                isMelodicParameter.IsMelodic = value;
            }
        }
        public float AverageSoundDuration
        {
            get
            {
                return averageSoundDurationParameter.AverageSoundDuration;
            }
            set
            {
                averageSoundDurationParameter.AverageSoundDuration = value;
            }
        }
        public bool AverageSoundDurationEnabled
        {
            get
            {
                return averageSoundDurationParameter.Enabled;
            }
            set
            {
                averageSoundDurationParameter.Enabled = value;
            }
        }
        public float SingleSoundSpectrumWidth
        {
            get
            {
                return singleSoundSpectrumWidthParameter.SpectrumWidth;
            }
            set
            {
                singleSoundSpectrumWidthParameter.SpectrumWidth = value;
            }
        }
        public bool SingleSoundSpectrumWidthEnabled
        {
            get
            {
                return singleSoundSpectrumWidthParameter.Enabled;
            }
            set
            {
                singleSoundSpectrumWidthParameter.Enabled = value;
            }
        }
        public bool CanModulateFrequency
        {
            get
            {
                return canModulateParameter.CanModulateFrequency;
            }
            set
            {
                canModulateParameter.CanModulateFrequency = value;
            }
        }
        public bool CanModulateFrequencyEnabled
        {
            get
            {
                return canModulateParameter.Enabled;
            }
            set
            {
                canModulateParameter.Enabled = value;
            }
        }
        public bool CanGliss
        {
            get
            {
                return canGlissParameter.Can;
            }
            set
            {
                canGlissParameter.Can = value;
            }
        }
        public bool CanGlissEnabled
        {
            get
            {
                return canGlissParameter.Enabled;
            }
            set
            {
                canGlissParameter.Enabled = value;
            }
        }
        public float FrequencyMax
        {
            get
            {
                return frequencyMaxParameter.Frequency;
            }
            set
            {
                frequencyMaxParameter.Frequency = value;
            }
        }
        public bool FrequencyMaxEnabled
        {
            get
            {
                return frequencyMaxParameter.Enabled;
            }
            set
            {
                frequencyMaxParameter.Enabled = value;
            }
        }
        public float FrequencyMin
        {
            get
            {
                return frequencyMinParameter.Frequency;
            }
            set
            {
                frequencyMinParameter.Frequency = value;
            }
        }
        public bool FrequencyMinEnabled
        {
            get
            {
                return frequencyMinParameter.Enabled;
            }
            set
            {
                frequencyMinParameter.Enabled = value;
            }
        }
        public float VolumeMax
        {
            get
            {
                return volumeMaxParameter.Volume;
            }
            set
            {
                volumeMaxParameter.Volume = value;
            }
        }
        public bool VolumeMaxEnabled
        {
            get
            {
                return volumeMaxParameter.Enabled;
            }
            set
            {
                volumeMaxParameter.Enabled = value;
            }
        }
        public float VolumeMin
        {
            get
            {
                return volumeMinParameter.Volume;
            }
            set
            {
                volumeMinParameter.Volume = value;
            }
        }
        public bool VolumeMinEnabled
        {
            get
            {
                return volumeMinParameter.Enabled;
            }
            set
            {
                volumeMinParameter.Enabled = value;
            }
        }

        public string FilteredInstruments
        {
            get; set;
        }

        public string InferenceHistory
        {
            get; set;
        }
        #endregion

        #region PrivateProperties
        private List<InstrumentParameter> AllParameters
        {
            get
            {
                List<InstrumentParameter> allParameters = new List<InstrumentParameter>();
                allParameters.Add(frequencyMaxParameter);
                allParameters.Add(frequencyMinParameter);
                allParameters.Add(volumeMaxParameter);
                allParameters.Add(volumeMinParameter);
                allParameters.Add(canGlissParameter);
                allParameters.Add(canModulateParameter);
                allParameters.Add(singleSoundSpectrumWidthParameter);
                allParameters.Add(averageSoundDurationParameter);
                allParameters.Add(isMelodicParameter);
                allParameters.Add(envelopeTypeParameter);
                return allParameters;
            }
        }
        private List<InstrumentParameter> SelectedParameters
        {
            get
            {
                return AllParameters.Where(parameter => parameter.Enabled).ToList();
            }
        }
        #endregion

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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            IdentifyInstrument.Execute(null);
        }

        public MainWindowViewModel()
        {
            knowledgeBase = new KnowledgeBase(inferenceHistory);
        }

        public ICommand LoadKnowledgeBase { get { return new RelayCommand(LoadKnowledgeBaseExecute); } }
        private void LoadKnowledgeBaseExecute()
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
                knowledgeBase.InferenceHistory = inferenceHistory;
            }
            catch
            {
                MessageBox.Show("Cannot read file");
                knowledgeBase = new KnowledgeBase(inferenceHistory);
            }
            //    OnPropertyChanged("KnowledgeBaseInstrumentsCount");
        }
        public ICommand IdentifyInstrument { get { return new RelayCommand(IdentifyInstrumentExecute, () => KnowledgeBaseInstrumentsCount > 0); } }

        private void IdentifyInstrumentExecute()
        {
            inferenceHistory.Clear();
            knowledgeBase.InferenceHistory = inferenceHistory;
            inferenceHistory.AddLine("Looking for instrument with parameters: ");
            foreach (InstrumentParameter parameter in SelectedParameters)
            {
                inferenceHistory.AddLine(parameter.ToString());
            }
            inferenceHistory.AddSeparator();
            inferenceHistory.AddSeparator();
            List<Instrument> filteredInstruments = knowledgeBase.FindInstrumentsWithSpecifiedparameters(SelectedParameters);
            string instrumentsString = "";
            foreach (Instrument instrument in filteredInstruments)
            {
                instrumentsString += instrument.Name + "\n";
            }
            FilteredInstruments = instrumentsString;
            InferenceHistory = inferenceHistory.History;
        }
    }
}