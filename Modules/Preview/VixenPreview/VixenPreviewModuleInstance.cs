using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vixen.Execution.Context;
using Vixen.Module.Preview;
using Vixen.Data.Value;
using Vixen.Sys;
using VixenModules.Preview.VixenPreview.Shapes;
using System.Diagnostics;

namespace VixenModules.Preview.VixenPreview
{
    public partial class VixenPreviewModuleInstance : FormPreviewModuleInstanceBase
    {
        VixenPreviewSetup previewForm;
        //VixenPreviewSetup setupForm;
        //VixenPreviewData _data;

        public VixenPreviewModuleInstance()
        {
        }

        //public override Vixen.Module.IModuleDataModel ModuleData
        //{
        //    get
        //    {
        //        return _data;
        //    }
        //    set
        //    {
        //        _data = value as VixenPreviewData;
        //    }
        //}

        private void VixenPreviewModuleInstance_Load(object sender, EventArgs e)
        {

        }

        public override void Stop()
        {
            Console.WriteLine("Stop");
            base.Stop();
        }

        public override void Resume()
        {
            Console.WriteLine("Resume");
            base.Resume();
        }

        public override void Pause()
        {
            Console.WriteLine("Pause");
            base.Pause();
        }

        public override bool IsRunning
        {
            get
            {
                return base.IsRunning;
            }
        }

        public delegate void RefreshDelegate();
        public void RefreshDelegateMethod()
        {
            //DebugTimer t2 = new DebugTimer();
            previewForm.RefreshPreview();
            //t2.StopDebugTimer("t2");
        }

        public override bool HasSetup
        {
            get
            {
                return base.HasSetup;
            }
        }

        protected override Form Initialize()
        {
            //Execution.NodesChanged += ExecutionNodesChanged;
            VixenSystem.Contexts.ContextCreated += ProgramContextCreated;
            VixenSystem.Contexts.ContextReleased += ProgramContextReleased;
            //Preferences.CurrentPreferences = GetDisplayPreviewModuleDataModel().Preferences;
            ResetColors(false);


            previewForm = new VixenPreviewSetup();
            previewForm.Data = GetDataModel();
            previewForm.Setup();
            return previewForm;
            //setupForm = new VixenPreviewSetup();
            //setupForm.Data = GetDataModel();
            //return setupForm;
        }

        private VixenPreviewData GetDataModel()
        {
            return ModuleData as VixenPreviewData;
        }

        public override void Start()
        {
            Console.WriteLine("Start");
            var dataModel = GetDataModel();
            base.Start();
        }

        public override bool Setup()
        {
            //setupForm = new VixenPreviewSetup();
            //setupForm.Data = GetDataModel();
            //setupForm.ShowDialog();
            return base.Setup();
        }


        private void ProgramContextCreated(object sender, ContextEventArgs contextEventArgs)
        {
            Console.WriteLine("Context Created");
            var programContext = contextEventArgs.Context as IProgramContext;
            if (programContext != null)
            {
                //_programContexts.Add(programContext);
                programContext.ProgramStarted += ProgramContextProgramStarted;
                programContext.ProgramEnded += ProgramContextProgramEnded;
            }
        }

        private void ProgramContextProgramEnded(object sender, ProgramEventArgs e)
        {
            ResetColors(false);
            Console.WriteLine("Stopped");
            Stop();
        }

        private void ProgramContextProgramStarted(object sender, ProgramEventArgs e)
        {
            Console.WriteLine("Started");
            ResetColors(true);
            Start();
        }

        private void ProgramContextReleased(object sender, ContextEventArgs contextEventArgs)
        {
            Console.WriteLine("Context Released");
            previewForm.Save();
            var programContext = contextEventArgs.Context as IProgramContext;
            if (programContext != null)
            {
                programContext.ProgramStarted -= ProgramContextProgramStarted;
                programContext.ProgramEnded -= ProgramContextProgramEnded;
                //_programContexts.Remove(programContext);
            }
        }

        private void ResetColors(bool isRunning)
        {
            var data = GetDataModel();
            foreach (DisplayItem displayItem in data.DisplayItems)
            {
                displayItem.ResetColors(isRunning);
            }
        }


        //bool _updating = false;
        protected override void Update()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Vixen tells us when to turn lights ON, but not when to turn them off.
            // We turn all the lights OFF and then turn just the ones one that Vixen tells us to
            // in the next step. 
            // This takes some time -- and there's got to be a better way!
            //previewForm.ResetColors();

            PreviewPixel.IntentNodeToColor.Clear();

            foreach (var channelIntentState in ElementStates)
            {
                var elementId = channelIntentState.Key;
                Element element = VixenSystem.Elements.GetElement(elementId);
                if (element == null) continue;
                ElementNode node = VixenSystem.Elements.GetElementNodeForElement(element);
                if (node == null) continue;

                foreach (IIntentState<LightingValue> intentState in channelIntentState.Value)
                {
                    //Color c = intentState.GetValue().GetAlphaChannelIntensityAffectedColor();
                    //previewForm.UpdateColors(node, c);

                    if (!PreviewPixel.IntentNodeToColor.ContainsKey(node))
                        PreviewPixel.IntentNodeToColor.Add(node, intentState.GetValue().GetAlphaChannelIntensityAffectedColor());
                }
            }

            //previewForm.RefreshPreview();
            timer.Stop();

            VixenPreviewControl.updateCount += 1;
            VixenPreviewControl.lastUpdateTime = timer.ElapsedMilliseconds;
            VixenPreviewControl.totalUpdateTime += timer.ElapsedMilliseconds;
            VixenPreviewControl.averageUpdateTime = VixenPreviewControl.totalUpdateTime / VixenPreviewControl.updateCount;
        }

    }
}
