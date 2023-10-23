using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInvertory
{
    enum LogLevel
    {
        mTrace,
        mWarn, 
        mError,
        mInfo,
        mCritical,
        mDebug,
        mNone
    }

    internal interface ILogger
    {
        void Log(string message, LogLevel level);
    }
}
