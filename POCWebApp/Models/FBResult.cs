using Microsoft.Build.Framework;

namespace POCWebApp.Models
{
    public class FBResult
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid FormID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool IsFromSet { get; set; }
        [Required]
        public bool IsUsedForSaveOnly { get; set; }
        [Required]
        public bool IsStageSubmitted { get; set; }
        [Required] 
        public Guid ResultSetID { get; set; }
        public Guid UserCreated { get; set; }
        public string Status { get; set; }
        public Guid FormWorkflowStageID { get; set; }
        [Required]
        public Guid ApplicationID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        [Required]
        public bool IsCollaborationStage { get; set; }
        public Guid TokenGroupId { get; set; }
        [Required]
        public int Revision { get; set; }
        [Required]
        public int TimeSpentonStatus { get; set; }

    }
}
