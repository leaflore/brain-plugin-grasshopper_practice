using System;
using System.Drawing;
using Grasshopper;
using Grasshopper.Kernel;

namespace brain_gh_plugin
{
    public class brain_gh_pluginInfo : GH_AssemblyInfo
    {
        public override string Name => "brain_gh_plugin";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("fcbe37ea-2048-49e1-9d18-601c4c90c6da");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";

        //Return a string representing the version.  This returns the same version as the assembly.
        public override string AssemblyVersion => GetType().Assembly.GetName().Version.ToString();
    }
}