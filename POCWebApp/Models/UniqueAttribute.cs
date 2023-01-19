using System.ComponentModel.DataAnnotations;

namespace POCWebApp.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueAttribute : ValidationAttribute
    {
        public override Boolean IsValid(Object value)
        {
            // constraint implemented on database
            return true;
        }
    }
}