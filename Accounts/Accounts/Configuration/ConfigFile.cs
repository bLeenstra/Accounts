using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Configuration {
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
