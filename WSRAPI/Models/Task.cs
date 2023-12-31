//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSRAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string FullTitle { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public Nullable<int> ExecutiveEmployeeID { get; set; }
        public int StatusID { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public Nullable<System.DateTime> UpdatedTime { get; set; }
        public Nullable<System.DateTime> DeletedTime { get; set; }
        public string Deadline { get; set; }
        public Nullable<System.TimeSpan> StartActualTime { get; set; }
        public Nullable<System.TimeSpan> FinishActualTime { get; set; }
        public Nullable<int> PreviousTaskId { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Project Project { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
    }
}
