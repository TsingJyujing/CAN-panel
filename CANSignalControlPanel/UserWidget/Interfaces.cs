using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CANSignalControlPanel.UserWidget {
    public interface Ensureable {
        bool isModified();
    }
    public interface Modifiable {
        void ModifyObject();
    }
}
