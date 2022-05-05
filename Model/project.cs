using System.ComponentModel.DataAnnotations;

namespace project.Model
{
    public class project
    {
     [Key]
     public int ProjectId{get; set;}
     public string ProjectName{get;set;}
     public bool IsActive { get; set; } = true;
     public int  DepartmentId{get;set;}
     [ForiegnKey("DepartmentId")]
     [InverseProperty("Projects")]
     public virtual Department? department { get; set; }
    }
}