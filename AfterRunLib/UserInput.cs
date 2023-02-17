using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambiesoft.AfterRunLib
{
    public class UserInput
    {
        List<ExeArg> _exeargs = null;
        public List<ExeArg> ExeArgs
        {
            get
            {
                return _exeargs;
            }
        }
        List<string> _exes = null;

        public List<string> Exes
        {
            get
            {
                if (_exes != null)
                    return _exes;
                _exes = new List<string>();
                foreach (ExeArg ea in _exeargs)
                {
                    _exes.Add(ea.Exe);
                }
                return _exes;
            }
        }

        public int? _interval = null;
        public int? Interval
        {
            get
            {
                return _interval;
            }
            set
            {
                _interval = value;
            }
        }
        List<int> _pidsToWait = null;
        public List<int> PidsToWait
        {
            get { return _pidsToWait; }
        }
        
        bool _isShutdown = false;
        public bool IsShutdown
        {
            get { return _isShutdown; }
        }

        ProcessWindowStyle _launchingProcessWindowStyle;
        public ProcessWindowStyle LaunchingProcessWindowStyle
        {
            get { return _launchingProcessWindowStyle; }
        }
        public UserInput(
                    bool isShutdown,
                    List<ExeArg> exeargss,
                    int? interval,
                    List<int> pidsToWait,
                    ProcessWindowStyle pws)
        {
            this._isShutdown = isShutdown;
            this._exeargs = exeargss != null ? exeargss : new List<ExeArg>();
            this._interval = interval;
            this._pidsToWait = pidsToWait;
            this._launchingProcessWindowStyle = pws;
        }
        public UserInput(
                    bool isShutdown,
                    List<ExeArg> exeargss,
                    int? interval,
                    List<int> pidsToWait):
            this(isShutdown, exeargss, interval, pidsToWait, default(ProcessWindowStyle))
        { }
    }
}
