using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnitupFramework.Word
{

    public class GeneratorGenerateEventArgs : EventArgs
    {

        #region public enums

        public enum ProgressCounterType
        {
            none = 0,
            indeterminate = 1,
            limited = 2
        }

        #endregion

        #region public properties

        public ProgressCounterType CounterType { get; set; }

        public Int32 CounterValue { get; set; }

        public Int32 CounterLimit { get; set; }
        
        public String Message { get; set; }

        public String SubMessage { get; set; }

        #endregion

    }

}
