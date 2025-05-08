using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace brain_gh_plugin.UtilComps
{
    public class HTTPPostRequestComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the HTTPPostRequestComponent class.
        /// </summary>
        public HTTPPostRequestComponent()
          : base("HTTPPostRequestComponent", "POST",
              "Creates a generic HTTP POST request",
              "AI - ML", "Utils")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            // active
            pManager.AddBooleanParameter("Send", "S", "Perform the request?", GH_ParamAccess.item, false);
            // url (endpoint)
            pManager.AddTextParameter("URL", "U", "Url for the request", GH_ParamAccess.item);
            // body
            pManager.AddTextParameter("Body", "B", "Body of the request", GH_ParamAccess.item);
            // context/type
            pManager.AddTextParameter("Content Type", "T", "Content type for the request, such as \"application/json\", \"text/html\", etc.", 
                GH_ParamAccess.item, "application/json");

            // custom header (later in time)
            // custom headers would be nice here: how to handhl key-value pairs in GH? take in a tree?

            // auth
            int authId = pManager.AddTextParameter("Authorization", "A", "If this request requires authorization, input your formatted token here as an Auth strin, e.g. \"Bearer h1g23g1fdg3d1\"", 
                GH_ParamAccess.item);
            // timeout
            pManager.AddIntegerParameter("Timeout", "T", "Timeout for the request in ms. If the request takes longer than this, it will fail.",
                 GH_ParamAccess.item, 10000);

            pManager[authId].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            // response
            pManager.AddTextParameter("Response", "R", "Response from the server", GH_ParamAccess.item);
        }


        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // inputs
            bool send = false;
            string url = "";
            string body = "";
            string contentType = "";
            string authToken = "";
            int timeout = 0;

            if (!DA.GetData(0, ref send)) return;
            if (!DA.GetData(1, ref url)) return;
            if (!DA.GetData(2, ref body)) return;
            if (!DA.GetData(3, ref contentType)) return;
            if (!DA.GetData(4, ref auth)) return;
            if (!DA.GetData(5, ref timeout)) return;
            // do the work
            if (send)
            {
                // make the request
                var response = HTTPRequestHelper.SendPostRequest(url, body, contentType, auth, timeout);
                DA.SetData(0, response);
            }
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("121587BE-70DB-4363-A9BA-E228A845714E"); }
        }
    }
}