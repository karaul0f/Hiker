using Hiker_Editor.Models;

namespace Hiker_Editor.ViewModels
{
    public class ScriptViewModel
    {
        Script _script;
        public ScriptViewModel(ref Script script)
        {
            _script = script;
        }

        public Script CurrentScript
        {
            private set { }
            get { return _script; }
        }
    }
}
