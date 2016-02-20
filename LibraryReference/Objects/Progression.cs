using Library.Resources.TextResources;
using System;

namespace Library.Resources.Objects
{
    public class Progression : IArtifact
    {
        #region Delegates + Events

        public event EventHandler Completed = delegate { };

        #endregion Delegates + Events

        #region Fields + Properties

        public int Current
        {
            get
            {
                return _Current;
            }
            set
            {
                _Current = value;
                if (Percentage >= 100) Completed(this, null);
            }
        }

        public int Percentage => 100 * Current / Total;
        public string Progress => Current + TextsPermanent.CountSeparator + Total;
        public string ProgressPercentage => Percentage + TextsPermanent.PercentSign;
        public int Total { get; set; }
        private int _Current;

        #endregion Fields + Properties
    }
}
