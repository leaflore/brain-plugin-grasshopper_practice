using System;
using System.Drawing;
using Grasshopper;
using Grasshopper.Kernel;

namespace Brain_GH_Plugin
{
    public class Brain_GH_PluginInfo : GH_AssemblyInfo
    {
        public override string Name => "Brain_GH_Plugin";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("58108464-30b7-4693-9ecf-6015301b63a9");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";

        //Return a string representing the version.  This returns the same version as the assembly.
        public override string AssemblyVersion => GetType().Assembly.GetName().Version.ToString();
    }
}