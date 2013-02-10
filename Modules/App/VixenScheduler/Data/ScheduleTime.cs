using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VixenModules.App.VixenScheduler.Data
{
    [DataContract]
    [KnownType(typeof(ScheduleTime))]
    public class ScheduleTime
    {
        [DataMember]
        public TimeSpan Start { get; set; }

        [DataMember]
        public TimeSpan End { get; set; }
        public TimeSpan[] ToTimeSpanArray()
        {
            return new TimeSpan[] { Start, End };
        }
    }

    [DataContract]
    [KnownType(typeof(ScheduleDateTime))]
    public class ScheduleDateTime 
    {
        public ScheduleDateTime() { }
        public ScheduleDateTime(ScheduleTime scheduleTime, DateTime schedDate) {
            Start = schedDate.AddTicks(scheduleTime.Start.Ticks);
            End = schedDate.AddTicks(scheduleTime.End.Ticks);
        }

        [DataMember]
        public DateTime Start { get; set; }
        
        [DataMember]
        public DateTime End { get; set; }
    }
}
