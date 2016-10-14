using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UseViewState
{
    [System.Serializable]
    public class PathNavigator
    {
        private Stack<string> Prevs = new Stack<string>();
        private Stack<string> Nexts = new Stack<string>();
        private string _currentPath;

        public PathNavigator()
        {
        }

        public PathNavigator(string current)
        {
            this._currentPath = current;
        }


        public string Path 
        { 
            get 
            { 
                return this._currentPath;
            }
        }

        public void Enter(string path) 
        {
            if (this._currentPath == null) 
            {
                this._currentPath = path;
                return;
            }
            this.Prevs.Push(path);
            this._currentPath = path;
            this.Nexts.Clear();
        }

        public string Next()
        {
            if (this.Nexts.Count == 0)
            {
                throw new InvalidOperationException("no more!");
            }
            this.Prevs.Push(this._currentPath);
            this._currentPath = this.Nexts.Pop();
            return this._currentPath;
        }

        public string Prev()
        {
            if (this.Prevs.Count == 0)
            {
                throw new InvalidOperationException("no more!");
            }
            this.Nexts.Push(this._currentPath);
            this._currentPath = this.Prevs.Pop();
            return this._currentPath;
        }


    }
}