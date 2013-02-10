using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace VixenModules.App.VixenScheduler.Data
{
    [DataContract]
    [KnownType(typeof(ScheduleItem))]
    public class ScheduleItem
    {
        #region ctor
        public ScheduleItem()
        {
            Init();
        }

        public ScheduleItem(string name)
        {
            Init();

            this.Name = name;
        }

        void Init()
        {
            Monday = Tuesday = Wednesday = Thursday = Friday = Saturday = Sunday = new List<ScheduleTime>();
            ID = Guid.NewGuid();
            StartDate= EndDate = DateTime.Now;

        }
        #endregion

        public ScheduleItem(TimeSpan[][][] timeFrame)
        {
            for (int i = 0; i < timeFrame.Length; i++)
            {

                List<ScheduleTime> times = new List<ScheduleTime>();
                timeFrame[i].ToList().ForEach(b =>
                {
                    ScheduleTime t = new ScheduleTime();
                    t.Start = b[0];
                    t.End = b[1];
                    times.Add(t);

                });

                switch ((DayOfWeek)i)
                {
                    case DayOfWeek.Sunday:
                        Sunday = times;
                        Debug.WriteLine(string.Format("{0} Contains {1} Runtime", "Sunday", times.Count));
                        break;
                    case DayOfWeek.Monday:
                        Monday = times;
                        Debug.WriteLine(string.Format("{0} Contains {1} Runtime", "Monday", times.Count));
                        break;
                    case DayOfWeek.Tuesday:
                        Tuesday = times;
                        Debug.WriteLine(string.Format("{0} Contains {1} Runtime", "Tuesday", times.Count));
                        break;
                    case DayOfWeek.Wednesday:
                        Wednesday = times;
                        Debug.WriteLine(string.Format("{0} Contains {1} Runtime", "Wednesday", times.Count));
                        break;
                    case DayOfWeek.Thursday:
                        Thursday = times;
                        Debug.WriteLine(string.Format("{0} Contains {1} Runtime", "Thursday", times.Count));
                        break;
                    case DayOfWeek.Friday:
                        Friday = times;
                        Debug.WriteLine(string.Format("{0} Contains {1} Runtime", "Friday", times.Count));
                        break;
                    case DayOfWeek.Saturday:
                        Saturday = times;
                        Debug.WriteLine(string.Format("{0} Contains {1} Runtime", "Saturday", times.Count));
                        break;
                    default:
                        break;
                }


            }
        }

        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public List<ScheduleTime> Monday { get; set; }
        [DataMember]
        public List<ScheduleTime> Tuesday { get; set; }
        [DataMember]
        public List<ScheduleTime> Wednesday { get; set; }
        [DataMember]
        public List<ScheduleTime> Thursday { get; set; }
        [DataMember]
        public List<ScheduleTime> Friday { get; set; }
        [DataMember]
        public List<ScheduleTime> Saturday { get; set; }
        [DataMember]
        public List<ScheduleTime> Sunday { get; set; }


        public IList<ScheduleDateTime> ScheduledTimes
        {
            get
            {
                List<ScheduleDateTime> scheduledTimes = new List<ScheduleDateTime>();
                var startDateID = (int)StartDate.DayOfWeek;
                for (int i = 0; i < EndDate.Subtract(StartDate).Days; i++)
                {
                    startDateID += i;
                    DateTime workingDay = StartDate.AddDays(i);
                    switch ((DayOfWeek)startDateID)
                    {
                        case DayOfWeek.Friday:
                            Friday.ToList().ForEach(a =>
                            {
                                scheduledTimes.Add(new ScheduleDateTime(a, workingDay));
                            });

                            break;
                        case DayOfWeek.Monday:
                            Monday.ToList().ForEach(a =>
                            {
                                scheduledTimes.Add(new ScheduleDateTime(a, workingDay));
                            });
                            break;
                        case DayOfWeek.Saturday:
                            Saturday.ToList().ForEach(a =>
                            {
                                scheduledTimes.Add(new ScheduleDateTime(a, workingDay));
                            });
                            break;
                        case DayOfWeek.Sunday:
                            Sunday.ToList().ForEach(a =>
                            {
                                scheduledTimes.Add(new ScheduleDateTime(a, workingDay));
                            });
                            break;
                        case DayOfWeek.Thursday:
                            Thursday.ToList().ForEach(a =>
                            {
                                scheduledTimes.Add(new ScheduleDateTime(a, workingDay));
                            });
                            break;
                        case DayOfWeek.Tuesday:
                            Tuesday.ToList().ForEach(a =>
                            {
                                scheduledTimes.Add(new ScheduleDateTime(a, workingDay));
                            });
                            break;
                        case DayOfWeek.Wednesday:
                            Wednesday.ToList().ForEach(a =>
                            {
                                scheduledTimes.Add(new ScheduleDateTime(a, workingDay));
                            });
                            break;
                        default:
                            break;
                    }
                }
                return scheduledTimes;
            }
        }

        public bool IsScheduled()
        {
            return IsScheduled(DateTime.Now);
        }

        public bool IsScheduled(DateTime runTime)
        {

            var currentTS = new TimeSpan(runTime.Hour, runTime.Minute, runTime.Second);

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return Friday.Where(m => m.Start <= currentTS && m.End > currentTS).Count() > 0;

                case DayOfWeek.Monday:
                    return Monday.Where(m => m.Start <= currentTS && m.End > currentTS).Count() > 0;

                case DayOfWeek.Saturday:
                    return Saturday.Where(m => m.Start <= currentTS && m.End > currentTS).Count() > 0;

                case DayOfWeek.Sunday:
                    return Sunday.Where(m => m.Start <= currentTS && m.End > currentTS).Count() > 0;

                case DayOfWeek.Thursday:
                    return Thursday.Where(m => m.Start <= currentTS && m.End > currentTS).Count() > 0;

                case DayOfWeek.Tuesday:
                    return Tuesday.Where(m => m.Start <= currentTS && m.End > currentTS).Count() > 0;

                case DayOfWeek.Wednesday:
                    return Wednesday.Where(m => m.Start <= currentTS && m.End > currentTS).Count() > 0;

                default:
                    return false;
            }

        }

        /// <summary>
        /// First date when the entry is valid.
        /// </summary>
        [DataMember]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Last date when the entry is valid.
        /// </summary>
        [DataMember]
        public DateTime EndDate { get; set; }


        [DataMember]
        public List<string> Programs { get; set; }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public bool Random { get; set; }

        public bool IsExecuting;
        
        [DataMember]
        public DateTime LastExecutedAt { get; set; }

        public TimeSpan[][][] ToTimeSpanArray()
        {
            List<TimeSpan[][]> results = new List<TimeSpan[][]>();
            List<TimeSpan[]> workArray = new List<TimeSpan[]>();

            if (Sunday != null)
                Sunday.ToList().ForEach(d =>
                {
                    workArray.Add(d.ToTimeSpanArray());
                });
            results.Add(workArray.ToArray());
            workArray.Clear();

            if (Monday != null)
                Monday.ToList().ForEach(d =>
                {
                    workArray.Add(d.ToTimeSpanArray());
                });
            results.Add(workArray.ToArray());
            workArray.Clear();

            if (Tuesday != null)
                Tuesday.ToList().ForEach(d =>
                {
                    workArray.Add(d.ToTimeSpanArray());
                });

            results.Add(workArray.ToArray());
            workArray.Clear();

            if (Wednesday != null)
                Wednesday.ToList().ForEach(d =>
                {
                    workArray.Add(d.ToTimeSpanArray());
                });

            results.Add(workArray.ToArray());
            workArray.Clear();

            if (Thursday != null)
                Thursday.ToList().ForEach(d =>
                {
                    workArray.Add(d.ToTimeSpanArray());
                });
            results.Add(workArray.ToArray());
            workArray.Clear();


            if (Friday != null)
                Friday.ToList().ForEach(d =>
                {
                    workArray.Add(d.ToTimeSpanArray());
                });
            results.Add(workArray.ToArray());
            workArray.Clear();

            if (Saturday != null)
                Saturday.ToList().ForEach(d =>
                {
                    workArray.Add(d.ToTimeSpanArray());
                });
            results.Add(workArray.ToArray());
            workArray.Clear();


            return results.ToArray();

        }

    }




}
