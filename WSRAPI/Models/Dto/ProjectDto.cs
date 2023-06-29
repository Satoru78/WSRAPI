using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRAPI.Models.Dto
{
    public class ProjectDto
    {
        public int ID { get; set; }
        public string FullTitle { get; set; }
        public string ShortTitle { get; set; }
        public string Icon { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> DeletedTime { get; set; }
        public Nullable<System.DateTime> StartScheduleDate { get; set; }
        public Nullable<System.DateTime> FinishScheduleDate { get; set; }
        public Nullable<System.DateTime> Description { get; set; }
        public Nullable<int> CreatorEmployeeID { get; set; }
        public Nullable<int> ResponsibleEmployeeId { get; set; }
    }
}