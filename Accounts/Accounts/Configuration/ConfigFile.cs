using System;
using System.ComponentModel;

namespace CashFlowManager.Configuration {
    class ConfigFile {

        public void SetProperty(Properties property)
        {
            throw new InvalidEnumArgumentException();
        }

        public string GetProperty(){
            return String.Empty;

        }
        public enum Properties
        {
            DataSource,
            Port
        }
    }
}
