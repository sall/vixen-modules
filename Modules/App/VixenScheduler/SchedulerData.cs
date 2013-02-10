using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Vixen.Module;
using VixenModules.App.VixenScheduler.Data;

namespace VixenModules.App.VixenScheduler
{
    [DataContract]
    [KnownType(typeof(SchedulerData))]
    public class SchedulerData : ModuleDataModelBase
    {
        private int _interval = 2;

        public SchedulerData()
        {
            Initialize();
            IsEnabled = false;
            Schedules = new List<ScheduleItem>();
            CheckIntervalInSeconds = 10;
        }

        [DataMember]
        public bool IsEnabled;

        [DataMember]
        public List<ScheduleItem> Schedules { get; set; }

        public List<ScheduleDateTime> AllScheduledDateTimes
        {
            get
            {
                List<ScheduleDateTime> retVal = new List<ScheduleDateTime>();
                Schedules.ToList().ForEach(a => retVal.AddRange(a.ScheduledTimes));
                return retVal;
            }
        }


        [DataMember]
        public int CheckIntervalInSeconds
        {
            get { return _interval; }
            set
            {
                if (_interval != value && value != 0)
                {
                    _interval = value;
                }
            }
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            Initialize();
        }



        private void Initialize()
        {
            Schedules = new List<ScheduleItem>();

        }

        public override IModuleDataModel Clone()
        {

            var newData = (SchedulerData)MemberwiseClone();
            newData.Schedules = Schedules;
            return newData;
        }
    }
}