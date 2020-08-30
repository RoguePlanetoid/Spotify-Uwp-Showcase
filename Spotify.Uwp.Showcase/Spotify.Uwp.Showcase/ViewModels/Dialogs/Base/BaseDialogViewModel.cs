using Spotify.NetStandard.Sdk;
using System;
using System.Windows.Input;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Base Dialog View Model
    /// </summary>
    public abstract class BaseDialogViewModel<TResult> : BaseNotifyPropertyChanged, IDisposable
        where TResult : class
    {
        #region Private Members
        private bool _loading;
        private string _title;
        private string _primaryLabel;
        private string _secondaryLabel;
        private bool _isPrimaryVisible;
        private bool _isSecondaryVisible;
        #endregion Private Members

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public BaseDialogViewModel(
            ISpotifySdkClient client) =>
            Client = client;
        #endregion Constructor

        #region Protected Methods
        /// <summary>
        /// Spotify Sdk Client
        /// </summary>
        public ISpotifySdkClient Client { get; protected set; }
        #endregion Protected Methods

        #region Public Properties
        /// <summary>
        /// Result
        /// </summary>
        public TResult Result  { get; set; }

        /// <summary>
        /// Loading Indicator
        /// </summary>
        public bool Loading
        {
            get => _loading;
            set { _loading = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get => _title;
            set { _title = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Primary Label
        /// </summary>
        public string PrimaryLabel
        {
            get => _primaryLabel;
            set { _primaryLabel = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Secondary Label
        /// </summary>
        public string SecondaryLabel
        {
            get => _secondaryLabel;
            set { _secondaryLabel = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Is Primary Visible
        /// </summary>
        public bool IsPrimaryVisible
        {
            get => _isPrimaryVisible;
            set { _isPrimaryVisible = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Is Secondary Visible
        /// </summary>
        public bool IsSecondaryVisible
        {
            get => _isSecondaryVisible;
            set { _isSecondaryVisible = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Primary Command
        /// </summary>
        public ICommand PrimaryCommand { get; set; }

        /// <summary>
        /// Cancel Command
        /// </summary>
        public ICommand SecondaryCommand { get; set; }
        #endregion Public Properties

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            Client = null;
        #endregion Public Methods
    }
}