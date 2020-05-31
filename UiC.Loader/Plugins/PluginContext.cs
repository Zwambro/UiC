﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UiC.Loader.Plugins
{
    public class PluginContext
    {
        public PluginContext(string assemblyPath, Assembly pluginAssembly)
        {
            AssemblyPath = assemblyPath;
            PluginAssembly = pluginAssembly;
        }

        internal void Initialize(Type pluginType)
        {
            Plugin = (IPlugin)Activator.CreateInstance(pluginType, this);

            if (Plugin == null)
                return;

            Plugin.Initialize();
        }

        public string AssemblyPath
        {
            get;
            private set;
        }

        public Assembly PluginAssembly
        {
            get;
            private set;
        }

        public IPlugin Plugin
        {
            get;
            private set;
        }

        public override string ToString()
        {
            if (Plugin == null)
            {
                return PluginAssembly.FullName;
            }
            return Plugin.Name + " : " + Plugin.Description;
        }
    }
}
